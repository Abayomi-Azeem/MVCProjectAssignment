using MVCProjectAssignment.Models.DB_Model;
using MVCProjectAssignment.Models.View_Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectAssignment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult MakePayment()
        {
            return View();
        }
        public ActionResult MemberReg()
        {
            return View();
        }
        public ActionResult VehicleReg()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MakePayment(Payments payment)
        {
            try
            {
                var db = new owodaInfo();
                var allPayments = new Payment();
                allPayments.MemberId = payment.MemberId;
                allPayments.VehicleId = payment.VehicleId;
                allPayments.AmountPaid = payment.Amount;
                allPayments.PaymentDate = DateTime.UtcNow.AddHours(1);
                db.Payments.Add(allPayments);
                db.SaveChanges();
                ViewBag.Successful = "Payment Successful";
                return View();
            }
            catch (Exception Ex)
            {

                ViewBag.ErrorMessage = "Error During Payment";
                return View();
            }
        }
        [HttpPost]
        public ActionResult MemberReg(Members member)
        {
            try
            {
                var db = new owodaInfo();
                var allmembers = new NURTWMember();
                allmembers.Age = (int)member.Age;
                allmembers.FirstName = member.FirstName;
                allmembers.LastName = member.LastName;
                var regDate = DateTime.UtcNow.AddHours(1);
                allmembers.RegistrationDate = regDate;
                db.NURTWMembers.Add(allmembers);
                db.SaveChanges();
                ViewBag.Successful = "Member Registration Successful";
                var rowList = db.NURTWMembers.Where(x => x.LastName==member.LastName &&  x.FirstName == member.FirstName).Select(x => x.Id).ToList();
                if (rowList.Count < 1)
                {
                    ViewBag.ErrorMessage = "Error During Registration";
                    return View();
                }
                ViewBag.MemberId = rowList[rowList.Count()-1];
               

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error During Registration";
                return View();

            }
        }
        [HttpPost]
        public ActionResult VehicleReg(Vehicles vehicle)
        {
            try
            {
                var db = new owodaInfo();
                var allvehicles = new NURTWVehicle();
                allvehicles.VehicleMake = vehicle.Make;
                allvehicles.VehicleModel = vehicle.Model;
                allvehicles.VehicleStatus = vehicle.Status;
                allvehicles.OwnerId = vehicle.MemberId;
                db.NURTWVehicles.Add(allvehicles);
                db.SaveChanges();
                ViewBag.Successful = "Vehicle Registration Successful";
                ViewBag.VehicleId = db.NURTWVehicles.Where(x => x.VehicleMake == vehicle.Make && x.VehicleModel == vehicle.Model && x.OwnerId == vehicle.MemberId).Select(x => x.Id).Take(1);
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error During Registration";
                return View();

            }
        }
    }
}