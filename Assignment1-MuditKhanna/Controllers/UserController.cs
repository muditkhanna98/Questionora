using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Assignment1_MuditKhanna.Models;

namespace Assignment1_MuditKhanna.Controllers
{
    public class UserController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private RoleManager<IdentityRole> roleManager;

        public UserController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Manage()
        {
            UserViewModel userViewModel = new UserViewModel();
            userViewModel.Users = userManager.Users.ToList();
            userViewModel.Roles = roleManager.Roles.ToList();
            foreach (IdentityUser user in userViewModel.Users)
            {
                var listOfRoles = await userManager.GetRolesAsync(user);
                userViewModel.UserRoles.Add(user.UserName, listOfRoles);
            }
            return View(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                await userManager.DeleteAsync(user);
            }
            return RedirectToAction("Manage");
        }

        public async Task<IActionResult> AddToAdmin(string id)
        {
            IdentityRole adminRole = await roleManager.FindByNameAsync("Admin");
            IdentityUser user = await userManager.FindByIdAsync(id);
            await userManager.AddToRoleAsync(user, adminRole.Name);
            return RedirectToAction("Manage");

        }
        public async Task<IActionResult> RemoveFromAdmin(string id)
        {
            IdentityRole adminRole = await roleManager.FindByNameAsync("Admin");
            IdentityUser user = await userManager.FindByIdAsync(id);
            await userManager.RemoveFromRoleAsync(user, adminRole.Name);
            return RedirectToAction("Manage");
        }
        public async Task<IActionResult> DeleteRole(string id)
        {
            IdentityRole adminRole = await roleManager.FindByIdAsync(id);
            await roleManager.DeleteAsync(adminRole);
            return RedirectToAction("Manage");
        }

        public async Task<IActionResult> CreateAdminRole(string id)
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            return RedirectToAction("Manage");
        }
    }
}
