﻿using HotelsBG.Data;
using HotelsBG.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsBG.Controllers
{
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext context;
        public ClientController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public ActionResult AllClients()
        {
            List<ClientBindingAllViewModel> users = context.Users.Select(
                clients => new ClientBindingAllViewModel
                {
                    Id = clients.Id,
                    UserName = clients.UserName,
                    FirstName = clients.FirstName,
                    LastName = clients.LastName,
                    Email = clients.Email,
                    PhoneNumber = clients.PhoneNumber

                }).ToList();
            return View(users);
        }
        // GET: ClientController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
