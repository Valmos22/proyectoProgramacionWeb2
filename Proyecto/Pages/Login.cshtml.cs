using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto.Code;
using Proyecto.Entities;

namespace Proyecto.Pages
{
    public class LoginModel : PageModel
    {
        Login lg_login;

        private readonly Proyecto.Data.ProyectoPDCContext _context;
        [BindProperty]
        public Login Lg_login { get => lg_login; set => lg_login = value; }

        public LoginModel(IHttpContextAccessor httpContextAccessor, Proyecto.Data.ProyectoPDCContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public IActionResult OnGet()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToPage("/IndexPage");
            }
            return this.Page();
        }

        public async Task<IActionResult> OnPostLogIn()
        {
            if (ModelState.IsValid)
            {
                var loginInfo = _context.RolUsuario
                    .Include(S => S.Rol)
                    .Include(S => S.Usuario)
                    .Where(s => s.Usuario.Usuario1 == lg_login.Username.Trim() && s.Usuario.Password == lg_login.Password.Trim()).ToList();

                if (loginInfo != null && loginInfo.Count() > 0)
                {
                    var logindetails = loginInfo.First();

                    int rolid = logindetails.Rol.Id;

                    var lstpermissions = _context.PermisosRol.Where(s => s.RolId == rolid).ToList<PermisosRol>();

                    string strpermissions = "";
                    foreach (var perm in lstpermissions)
                    {
                        if (perm.Active == 1)
                        {
                            strpermissions += perm.CodigoFuncion + ",";
                        }
                    }

                    await this.SignInUser(logindetails.Usuario.Usuario1, false);
                    HttpContext.Session.SetString("UserName", logindetails.Usuario.Usuario1);
                    HttpContext.Session.SetString("RolName", logindetails.Rol.Nombre);
                    HttpContext.Session.SetString("Permissions", strpermissions);
                    //_session.SetString("Permissions", strpermissions);
                    return this.RedirectToPage("/IndexPage");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid username or password.");
                }
            }

            return this.Page();
        }

        private async Task SignInUser(string username, bool isPersistent)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, username));
            var claimIdenties = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimPrincipal = new ClaimsPrincipal(claimIdenties);
            var authenticationManager = Request.HttpContext;
            await authenticationManager.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, new AuthenticationProperties() { IsPersistent = isPersistent });

        }
    }
}