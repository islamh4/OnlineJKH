﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineJKH.BLL;
using OnlineJKH.DAL.EF;
using OnlineJKH.DAL.Entities;
using System.Data;
using System.Diagnostics.Metrics;

namespace OnlineJKH.Controllers
{
    public class UserController : Controller
    {
        private DataManager _dataManager;
        private EFDBContext _db;
        public UserController(DataManager dataManager, EFDBContext db)
        {
            _dataManager = dataManager;
            _db = db;
        }
        [Authorize(Roles = "admin")]

        public IActionResult Index()
        {
            return View(_dataManager.UserService.GetUsers());
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult EditForm(int id = -1)
        {
            ViewBag.Role = new SelectList(_db.Roles.ToList(), "Id", "Name");
            if (id == -1)
            {
                ViewBag.Button = "Добавить";
                return View();
            }
            ViewBag.Button = "Сохранить";
            ViewBag.NameView = "Изменение";
            return View(_dataManager.UserService.Get(id));
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult EditForm(User user, IFormFile? Image)
        {
            if (Image != null)
            {
                user.Photo = _dataManager.UserService.Image(Image);
            }
            else
            {
                user.Photo = _db.Users.FirstOrDefault(m => m.Id == user.Id)?.Photo;
            }
            if (_db.Users.Any(m => m.Account.Login == user.Account.Login))
            {
                ModelState.AddModelError("", "Пользователь с таким логином уже существует!");
            }
            if (ModelState.IsValid)
            {
                if (user.Id == 0)
                {
                    _dataManager.UserService.Create(user);
                    return RedirectToAction("Index");
                }
                _dataManager.AccountService.Update(user);
                _dataManager.UserService.Update(user);
                return RedirectToAction("Index");

            }
            if (user.Id == 0)
            {
                ViewBag.Button = "Добавить";
                ViewBag.Role = new SelectList(_db.Roles.ToList(), "Id", "Name");
                return View(user);
            }
            ViewBag.Button = "Сохранить";
            ViewBag.NameView = "Изменение";
            ViewBag.Role = new SelectList(_db.Roles.ToList(), "Id", "Name");
            return View(user);
        }
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            _dataManager.AccountService.Delete(_db.Users.FirstOrDefault(m => m.Id==id));
            _dataManager.UserService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
