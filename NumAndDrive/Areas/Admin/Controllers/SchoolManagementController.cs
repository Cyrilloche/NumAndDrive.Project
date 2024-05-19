﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NumAndDrive.Areas.Admin.ViewModels.Role;
using NumAndDrive.Areas.Admin.ViewModels.SchoolManagement;
using NumAndDrive.Models;
using NumAndDrive.Repository.Interfaces;

namespace NumAndDrive.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SchoolManagementController : Controller
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IAddressRepository _addressRepository;

        public SchoolManagementController(IAddressRepository addressRepository, ISchoolRepository schoolRepository)
        {
            _addressRepository = addressRepository;
            _schoolRepository = schoolRepository;
        }

        // GET: SchoolManagementController
        public async Task<IActionResult> Index()
        {
            var schools = await _schoolRepository.GetAllSchoolsAsync();
            if (schools != null)
            {
                var datasToReturn = new IndexSchoolManagementViewModel
                {
                    Schools = schools.ToList()
                };
            return View(datasToReturn);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: SchoolManagementController/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: SchoolManagementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSchoolManagementViewModel datas)
        {
            if (!ModelState.IsValid)
                return View(datas);

            var address = new Address
            {
                Street = datas.Street,
                PostalCode = datas.PostalCode,
                City = datas.City
            };

            var schoolAdress = await _addressRepository.CreateAddressAsync(address);
            var newSchool = new School
            {
                Name = datas.SchoolName,
                AddressId = schoolAdress.AddressId
            };

            await _schoolRepository.CreateSchoolAsync(newSchool);

            return RedirectToAction("Index");
        }

        // POST: SchoolManagementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IndexSchoolManagementViewModel datas)
        {
            if (!ModelState.IsValid)
                return View(datas);

            var updatedSchool = new School
            {
                SchoolId = id,
                Name = datas.NewSchoolName,
                SchoolAddress = datas.SchoolAddress
            };
            await _schoolRepository.UpdateSchoolAsync(updatedSchool);
            return RedirectToAction("Index");
        }

        // POST: SchoolManagementController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            var school = await _schoolRepository.GetSchoolByIdAsync(id);

            if (school != null)
            {
                await _schoolRepository.DeleteSchoolAsync(id);
                return RedirectToAction("Index");
            }
            else
            return View("Index",_schoolRepository.GetAllSchoolsAsync());
        }
    }
}