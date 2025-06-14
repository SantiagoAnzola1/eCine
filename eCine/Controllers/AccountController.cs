using eCine.Data;
using eCine.Data.Static;
using eCine.Data.ViewModels;
using eCine.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eCine.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AplicationUser> _userManager;
        private readonly SignInManager<AplicationUser> _signInManger;
        private readonly AppDbContext _context;
        public AccountController(UserManager<AplicationUser> userManager, SignInManager<AplicationUser> signInManger, AppDbContext context)
        {
            _userManager= userManager;
            _signInManger = signInManger;
            _context = context;
        }

        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Users()
        {
            var users= await _context.Users.ToListAsync();

            var userViewModels = new List<UserVM>();
            ViewData["PreviousUrl"] = Request.Headers["Referer"].ToString();

            foreach (var user in users)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var userVM = new UserVM
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    UserName = user.UserName,
                    Email = user.Email,
                    Role = userRoles.FirstOrDefault() ?? "No Role"
                };
                userViewModels.Add(userVM);
            }

            return View(userViewModels);
        }

        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> EditUsers(string id)
        {
            var ids = id;
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return View("NotFound");
            }

            var userRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

            var userVM = new UserVM
            {
                Id = user.Id,
                FullName = user.FullName,
                UserName = user.UserName,
                Email = user.Email,
                Role = userRole,
            };
            ViewBag.Roles = new SelectList(userVM.Roles);
            return View(userVM);
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> EditUsers(string id, UserVM model)
        {
            if (!ModelState.IsValid)
            {
                model.Roles = UserRoles.Roles.ToList();
                return View(model);
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return View("NotFound");
            }

            // Update basic user information
            user.FullName = model.FullName;
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.NormalizedUserName = model.UserName.ToUpper();
            user.NormalizedEmail = model.Email.ToUpper();

            // Update user role
            var currentRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            if (currentRole != model.Role && UserRoles.Roles.Contains(model.Role))
            {
                if (currentRole != null)
                    await _userManager.RemoveFromRoleAsync(user, currentRole);

                await _userManager.AddToRoleAsync(user, model.Role);
            }

            var result = await _userManager.UpdateAsync(user);
            ViewBag.Roles = new SelectList(model.Roles);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);

                model.Roles = UserRoles.Roles.ToList();
                return View(model);
            }

            return RedirectToAction(nameof(Users));

        }
        public IActionResult Login()
        {
            return View(new LoginVM());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) 
            { 
                return View(loginVM); 
            }

            var user = await _userManager.FindByEmailAsync(loginVM.Email);

            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManger.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Movies");
                    }
                }
                TempData["Error"] = "Wrong Credentials. Please try again.";
                return View(loginVM);
            }

            TempData["Error"] = "Wrong Credentials. Please try again.";
            return View(loginVM);
        }


        public IActionResult SignUp()
        { 
            return View(new SignUpVM());
        }


        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpVM signUpVM)
        {
            if (!ModelState.IsValid)
                return View(signUpVM);

            if (await _userManager.FindByEmailAsync(signUpVM.Email) != null)
            {
                TempData["Error"] = "This email is already in use";
                return View(signUpVM);
            }

            var newUser = new AplicationUser
            {
                FullName = signUpVM.FullName,
                Email = signUpVM.Email,
                UserName = signUpVM.Email
            };

            var result = await _userManager.CreateAsync(newUser, signUpVM.Password);
            if (!result.Succeeded)
            {
                // Añadimos cada error de Identity al ModelState
                foreach (var err in result.Errors)
                    ModelState.AddModelError(string.Empty, $"{err.Code}: {err.Description}");
                return View(signUpVM);
            }

            await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            return View("RegisterCompleted");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManger.SignOutAsync();
            return RedirectToAction("Index", "Movies");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
