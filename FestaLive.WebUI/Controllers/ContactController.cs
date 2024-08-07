﻿using FestaLive.Business.Abstract;
using FestaLive.Entities.Concrete;
using FestaLive.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestaLive.WebUI.Controllers
{
    public class ContactController(IContactFormService contactFormService) : Controller
    {
        private readonly IContactFormService _contactFormService = contactFormService;

        [HttpPost]
        public IActionResult Submit(ContactForm contactForm)
        {
            _contactFormService.Add(contactForm);
            return RedirectToAction("Index", "Default");
        }
        public IActionResult MessageList()
        {
            var result = _contactFormService.GetAll().Data;
            return View(result);
        }
        public IActionResult DeleteContact(int id)
        {
            var result = _contactFormService.Delete(id);
            return RedirectToAction("MessageList");
        }
    }
}
