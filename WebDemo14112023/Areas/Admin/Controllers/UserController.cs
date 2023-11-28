﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstDemo.Models;
using DatabaseFirstDemo.Repository;
using WebDemo14112023.Areas.Admin.Models;

namespace WebDemo14112023.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : BaseController
    {
        IUsersRepository userRepository = null;
        IRolesRepository roleRepository = null;
        public UsersController()
        {
            userRepository = new UsersRepository();
            roleRepository = new RolesRepository();
        }
        public IActionResult Index()
        {
            // Lấy danh sách quyền truy cập từ Repository hoặc Database
            IEnumerable<Role> roles = roleRepository.GetAll();

            // Tạo SelectList từ danh sách quyền truy cập
            SelectList selectList = new SelectList(roles, "Id", "Name");

            // Lưu SelectList vào ViewBag để sử dụng trong View
            ViewBag.Roles = selectList;

            IEnumerable<User> users = userRepository.GetAll();
            IEnumerable<UserDetail> usersdetail = userRepository.GetUserDetailAll();
            return View(new RoleUser
            {
                Roles = (ICollection<Role>)roles,
                Users = (ICollection<User>)users,
                UserDetails = (ICollection<UserDetail>)usersdetail,
            });
            //return View(users);
        }

        // GET: Admin/Roles/Create
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(userRepository.GetAllRoles(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public JsonResult Create(User users, UserDetail userDetails)
        {
            try
            {
                // Lấy giá trị từ các trường thuộc tính của user trong form
                var user = new User
                {
                    UserName = users.UserName,
                    Password = Common.Common.EncryptMD5(users.Password),
                    RoleId = users.RoleId,
                    Status = users.Status
                };

                // Lấy giá trị từ các trường thuộc tính của userDetail trong form
                var userDetail = new UserDetail
                {
                    FullName = userDetails.FullName,
                    Address = userDetails.Address,
                    Email = userDetails.Email
                };
                /*  if (ModelState.IsValid)
                  {*/
                userRepository.InsertUser(user);
                // Gán giá trị UserId mới tạo cho thuộc tính UserId của userDetail
                userDetail.UserId = user.UserId;
                userRepository.InsertUserDetail(userDetail);
                SetAlert("Insert Data is success!", "success");
                return Json(new { success = true });
                /* }*/
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            return Json(new { success = false });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            User user = userRepository.GetById(id);
            UserDetail userDetail = userRepository.GetByUserDetailId(id);
            ViewBag.Roles = new SelectList(roleRepository.GetAll(), "Id", "Name", user.RoleId);
            var data = new
            {
                Id = user.UserId,
                UserName = user.UserName,
                //Password = user.Password,
                Status = user.Status,
                RoleId = user.RoleId,
                FullName = userDetail.FullName,
                Address = userDetail.Address,
                Email = userDetail.Email
                // Các trường khác
            };

            return new JsonResult(new { success = true, data = data });
        }

        [HttpPost]
        public JsonResult Edit(User users, UserDetail userDetails)
        {
            try
            {
                // Lấy giá trị từ các trường thuộc tính của user trong form
                var user = new User
                {
                    UserId = users.UserId,
                    UserName = users.UserName,
                    RoleId = users.RoleId,
                    Status = users.Status
                };
                if (users.Password != null)
                {
                    user.Password = Common.Common.EncryptMD5(users.Password);
                }
                else
                {
                    user.Password = userRepository.GetById(users.UserId).Password;
                }
                // Lấy giá trị từ các trường thuộc tính của userDetail trong form
                var userDetail = new UserDetail
                {
                    UserId = userDetails.UserId,
                    FullName = userDetails.FullName,
                    Address = userDetails.Address,
                    Email = userDetails.Email
                };
                userRepository.UpdateUser(user);
                userRepository.UpdateUserDetail(userDetail);
                SetAlert("Update Data is success!", "success");
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public JsonResult Delete(User user)
        {
            try
            {
                userRepository.Delete(user);
                SetAlert("Delete Data is success!", "success");
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var result = userRepository.ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}
