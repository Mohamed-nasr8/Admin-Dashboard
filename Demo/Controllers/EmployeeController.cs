using AutoMapper;
using Demo.BL.Helper;
using Demo.BL.Interface;
using Demo.BL.Models;
using Demo.DAL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [Authorize]

    public class EmployeeController : Controller
    {
        private readonly ICityRep city;
        private readonly IDistrictRep district;
        private readonly IEmployeeRep employee;
        private readonly IMapper mapper;
        private readonly IDepartmentRep department;

        public EmployeeController(ICityRep city ,IDistrictRep district,IEmployeeRep employee, IMapper mapper , IDepartmentRep  department)
        {
            this.city = city;
            this.district = district;
            this.employee = employee;
            this.mapper = mapper;
            this.department = department;
        }




        public IActionResult Index( string SearchValue = "")
        {
            if (SearchValue == "")
            {
                var data = employee.Get();
                var model = mapper.Map<IEnumerable<EmployeeVM>>(data);
                return View(model);
            }
            else
            {
                var data = employee.SearchByName(SearchValue);
                var model = mapper.Map<IEnumerable<EmployeeVM>>(data);
                return View(model);
            }
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeVM model)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    model.PhotoName = FileUploader.UploadFile("/wwwroot/Files/Imgs", model.Photo);
                    model.CvName = FileUploader.UploadFile("/wwwroot/Files/Docs", model.Cv);
                    var data = mapper.Map<Employee>(model);

                    employee.Creat(data);

                    return RedirectToAction("Index");
                }
                ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name");

                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name");

                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var data = employee.GetById(id);
            var model = mapper.Map<EmployeeVM>(data);
            ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name", model.DepartmentId);

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = employee.GetById(id);
            var model = mapper.Map<EmployeeVM>(data);
            ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name", model.DepartmentId);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeVM model)
        {

            try
            {

                if (ModelState.IsValid)


                {

                    model.PhotoName = FileUploader.UploadFile("/wwwroot/Files/Imgs", model.Photo);
                    model.CvName = FileUploader.UploadFile("/wwwroot/Files/Docs", model.Cv);
                    var data = mapper.Map<Employee>(model);
                    employee.Edit(data);
                    return RedirectToAction("Index");
                }


                ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name", model.DepartmentId);
                return View(model);
            }
            catch (Exception ex)
            {

                ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name", model.DepartmentId);
                return View(model);
            }
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = employee.GetById(id);

            var model = mapper.Map<EmployeeVM>(data);
            ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name", model.DepartmentId);


            return View(model);
        }


        [HttpPost]
        public IActionResult Delete(EmployeeVM model)
        {

            try
            {

                var data = mapper.Map<Employee>(model);



                employee.Delet(data);



                FileUploader.RemoveFile("/wwwroot/Files/Imgs/", model.PhotoName);
                FileUploader.RemoveFile("/wwwroot/Files/Docs/", model.CvName);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name", model.DepartmentId);

                return View(model);
            }
        }

        [HttpPost]
        public JsonResult GetCityDataByCountryId(int CtryId)
        {

            var data = city.Get(a => a.CountryId == CtryId);

            var model = mapper.Map<IEnumerable<CityVM>>(data);
            return Json(model);
        }


        [HttpPost]
        public JsonResult GetDistrictDataByCityId(int CtyId)
        {

            var data = district.Get(a =>a.CityId == CtyId);
            var model = mapper.Map<IEnumerable<DistrictVM>>(data);

            return Json(model);
        }
    }
}
