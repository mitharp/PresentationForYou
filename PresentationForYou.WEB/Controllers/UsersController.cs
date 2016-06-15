using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PresentationForYou.WEB.Models;
using PresentationForYou.BLL.DTO;
using PresentationForYou.BLL.Interfaces;

namespace PresentationForYou.WEB.Controllers
{
    public class UsersController : Controller
    {
        IService<UserDTO> userService;
        IEnumerable<User> Users;
        public UsersController(IService<UserDTO> userService)
        {
            this.userService = userService;
            IEnumerable<UserDTO> user = userService.GetAll();
            Users = user.Select(a => new User
            {
                Id = a.Id,
                BirthDay = a.BirthDay,
                Email = a.Email,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Phone = a.Phone,
                RegistrationDateTime = a.RegistrationDateTime,
                Role = a.Role
            }).ToList();
        }
        // GET: Users
        public ActionResult Index()
        {
            return View(Users);
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userDTO = userService.Get(id);
            if (userDTO == null)
            {
                return HttpNotFound();
            }
            return View(new User
            {
                Id = userDTO.Id,
                BirthDay = userDTO.BirthDay,
                Email = userDTO.Email,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Phone = userDTO.Phone,
                RegistrationDateTime = userDTO.RegistrationDateTime,
                Role = userDTO.Role
            });
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Role,BirthDay,RegistrationDateTime,Phone,Email")] User user)
        {
            if (ModelState.IsValid)
            {
                userService.Add(new UserDTO
                {
                    Id = user.Id,
                    BirthDay = user.BirthDay,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Phone = user.Phone,
                    RegistrationDateTime = user.RegistrationDateTime,
                    Role = user.Role
                });
                List<SelectListItem> roles = new List<SelectListItem>();
                roles.Add(new SelectListItem { Text = "Administrator", Value = "Administrator" });
                roles.Add(new SelectListItem { Text = "Manager", Value = "Manager" });
                roles.Add(new SelectListItem { Text = "User", Value = "User", Selected = true });
                ViewBag.roles = roles;x
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userDTO = userService.Get(id);
            User user = new Models.User
            {
                Id = userDTO.Id,
                BirthDay = userDTO.BirthDay,
                Email = userDTO.Email,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Phone = userDTO.Phone,
                RegistrationDateTime = userDTO.RegistrationDateTime,
                Role = userDTO.Role
            };
            List<SelectListItem> roles = new List<SelectListItem>();
            roles.Add(new SelectListItem { Text = "Administrator", Value = "Administrator" });
            roles.Add(new SelectListItem { Text = "Manager", Value = "Manager" });
            roles.Add(new SelectListItem { Text = "User", Value = "User", Selected = true });
            ViewBag.roles = roles;
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Role,BirthDay,RegistrationDateTime,Phone,Email")] User user)
        {
            if (ModelState.IsValid)
            {
                userService.Edit(new UserDTO
                {
                    Id = user.Id,
                    BirthDay = user.BirthDay,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Phone = user.Phone,
                    RegistrationDateTime = user.RegistrationDateTime,
                    Role = user.Role
                });
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDTO userDTO = userService.Get(id);
            User user = new User()
            {
                Id = userDTO.Id,
                BirthDay = userDTO.BirthDay,
                Email = userDTO.Email,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Phone = userDTO.Phone,
                RegistrationDateTime = userDTO.RegistrationDateTime,
                Role = userDTO.Role
            };
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            userService.Remove(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                userService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
