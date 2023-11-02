using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mock2.Models;
using Microsoft.EntityFrameworkCore;

namespace mock2.Controllers
{
    public class BloodDonorController : Controller
    {
        

        // private MockDbContext db;

        // public BloodDonorController(MockDbContext db){
        //     this.db=db;
        // }


























        private MockDbContext db;
        public BloodDonorController(MockDbContext db){
            this.db=db;
        }




        [HttpGet]
        public IActionResult Create(){
            return View();
        }



        [HttpPost]
        public IActionResult Create(BloodDonor bd){
            db.BloodDonors.Add(bd);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id){
            var e=db.BloodDonors.Find(id);
            if(e!=null) return View(e);
            else return NotFound();
            
        }

        [HttpPost]
        public IActionResult Delete(BloodDonor b){
            db.BloodDonors.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id){
            var e=db.BloodDonors.FirstOrDefault(d=>d.ID==id);
            return View(e);
        }

        [HttpPost]
        public IActionResult Edit(BloodDonor b){
            db.Update(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            // var bd=db.BloodDonors.OrderBy(e=>e.Name);
            var bd=db.BloodDonors.OrderBy(e=>e.Name).ToList();
            ViewBag.sum=db.BloodDonors.Sum(e=>e.ID);
            ViewBag.count=db.BloodDonors.Count();
            ViewBag.max=db.BloodDonors.Max(e=>e.ID);
            var i=db.BloodDonors.FirstOrDefault(e=>e.Name=="ankit");
            if(i!=null) ViewBag.name=i;
            return View(bd);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}