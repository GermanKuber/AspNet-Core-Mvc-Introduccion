﻿using System.Threading.Tasks;
using AdminNetBaires.Entities;
using AdminNetBaires.Services;
using AdminNetBaires.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AdminNetBaires.Controllers
{
   
    public class MembersController : Controller
    {
        private readonly IMembersService _membersService;
        
        public MembersController(IMembersService membersService)
        {
            _membersService = membersService;
        }


        public ViewResult Index()
        {

            var homeViewModel = new MembersIndexViewModel
            {
                Members = _membersService.GetAll()

            };
            return View(homeViewModel);
        }


        public IActionResult Details(int id)
        {
           
            var result = this._membersService.GetById(id);
            if (result == null)
            {
                return RedirectToAction("Index");
            }
       
            return View(result);
        }
        public IActionResult Create()
        {
            //TODO : Paso 1 - Creo Metodo de Get
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create([Bind("Id,Calification,Email,ExternaId,LastName,Name")] Member member)
        {
            //TODO : Paso 2 - Creo Metodo de Post
            if (ModelState.IsValid)
            {
                this._membersService.Create(member);
              
                return RedirectToAction("Index");
            }
            return View(member);
            //TODO: Paso 5 - Implemento la vista
            //Install-Package Microsoft.AspNetCore.Mvc.TagHelpers
        }
    }
}