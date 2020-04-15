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
        private ApplicationUserManager _userManager; 
        private readonly RoleManager<IdentityRole> roleManager;
        public AdminController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public ApplicationUserManager UserManager
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
        
        [HttpPost]
        [Route("CreateRole")]
        public ActionResult CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };
                
                IdentityResult result = roleManager.Create(identityRole);               
            }

            return View(model);
        }

        [HttpPost]
        [Route("AddUserToRole")]
        public ActionResult AddUserToRole(AddUserToRoleViewModel model)
        {
            model.UserId = User.Identity.GetUserId();  
            if (model.UserId == null)
            {
                return View("Not Found");
            }

            var result = UserManager.AddToRole(model.UserId, model.RoleName); 
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
            model.UserId = User.Identity.GetUserId();  
            if (model.UserId == null)
            {
                return View("Not Found");
            }
            var result = UserManager.RemoveFromRole(model.UserId, model.RoleName); 
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

    