using Michael.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Michael.Controllers
{
    [RoutePrefix("Api/Admin")]
    public class AdminController : Controller
    {
        private ApplicationUserManager _userManager; //here is our userManager field
        private readonly RoleManager<IdentityRole> roleManager;
        public AdminController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public ApplicationUserManager UserManager // this is our User Manager property -- copied from Account Controller
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        //[HttpGet] -- for asp.net web mvc
        //public IHttpActionResult CreateRole()
        //{
        //    return Ok();
        //}
        [HttpPost]
        [Route("CreateRole")]
        public ActionResult CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                // We just need to specify a unique role name to create a new role
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                // Saves the role in the underlying AspNetRoles table
                IdentityResult result = roleManager.Create(identityRole);



                //foreach (IdentityError error in result.Errors)
                //{
                //    ModelState.AddModelError("", error.Description);
                //}
            }

            return View(model);
        }

        [HttpPost]
        [Route("AddUserToRole")]
        public ActionResult AddUserToRole(AddUserToRoleViewModel model)
        {
            model.UserId = User.Identity.GetUserId();  // what if a user doesn't exist
            if (model.UserId == null)
            {
                return View("Not Found");
            }

            var result = UserManager.AddToRole(model.UserId, model.RoleName); // what if a Role doesn't exist
            if (model.RoleName == null)
            {
                return View("Not Found");
            }
            if (!result.Succeeded)
            {
                return View("Unsuccessful");
            }
            return View(model);

        }

        [HttpPost]
        [Route("RemoveUserFromRole")]
        public ActionResult RemoveUserFromRole(AddUserToRoleViewModel model)
        {
            model.UserId = User.Identity.GetUserId();  // what if a user doesn't exist
            if (model.UserId == null)
            {
                return View("Not Found");
            }
            var result = UserManager.RemoveFromRole(model.UserId, model.RoleName); // what if a Role doesn't exist
            if (model.RoleName == null)
            {
                return View("Not Found");
            }
            if (!result.Succeeded)
            {
                return View("Unsuccessful");
            }
            return View(model);
        }
    }
}

    