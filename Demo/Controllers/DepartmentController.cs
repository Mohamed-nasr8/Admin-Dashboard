using AutoMapper;
using Demo.BL.Interface;
using Demo.BL.Models;
using Demo.BL.Repository;
using Demo.DAL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [Authorize]

    public class DepartmentController : Controller
    {
        private readonly IDepartmentRep d;
        private readonly IMapper mapper;




        public DepartmentController(IDepartmentRep department , IMapper mapper)
        {
            d = department;
            this.mapper = mapper;
        }




        public IActionResult Index()
        {
            var data = d.Get();
            var model = mapper.Map<IEnumerable<DepratmentVM>>(data);
            return View(model);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepratmentVM model)
        {

            try
            {

                if (ModelState.IsValid)
                {


                    var data = mapper.Map<Department>(model);

                    d.Creat(data);
                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var data = d.GetById(id);
            var model = mapper.Map<DepratmentVM>(data);
            return View(model);
        }


        public IActionResult Edit(int id)


        {
            var data = d.GetById(id);

            var model = mapper.Map<DepratmentVM>(data);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(DepratmentVM model)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Department>(model);


                    d.Edit(data);


                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = d.GetById(id);

            var model = mapper.Map<DepratmentVM>(data);
            
            return View(model);
        }


        [HttpPost]
        public IActionResult Delete(DepratmentVM model)
        {

            try
            {

                var data = mapper.Map<Department>(model);

                d.Delet(data );
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }



    }




}
