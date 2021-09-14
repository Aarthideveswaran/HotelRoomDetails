using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using RoomDetails.Models;

namespace RoomDetails.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room
        public ActionResult Index()
        {
            IEnumerable<Room_Details> details;
            HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("Room_Details").Result;
            details = response.Content.ReadAsAsync<IEnumerable<Room_Details>>().Result;

            return View(details);
        }

        public ActionResult AddRoom(int id = 0)
        {

            return View(new Room_Details());


        }

        [HttpPost]
        public ActionResult AddRoom(Room_Details room_Details)
        {
            HttpResponseMessage response = GlobalVariable.WebApiClient.PostAsJsonAsync("Room_Details", room_Details).Result;
            TempData["successMessage"] = "Saved Successfully";
            return RedirectToAction("Index");

        }

        public ActionResult EditRoomDetails(int id)
        {
            HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("Room_Details/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<Room_Details>().Result);

        }

        [HttpPost]
        public ActionResult EditRoomDetails(Room_Details room_Details)
        {
            HttpResponseMessage response = GlobalVariable.WebApiClient.PutAsJsonAsync("Room_Details/" + room_Details.Room_Id, room_Details).Result;
            TempData["SuccessMessage"] = "Updated Successfully";
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariable.WebApiClient.DeleteAsync("Room_Details/" + id.ToString()).Result;
            TempData["successMessage"] = "Deletion is successful";
            return RedirectToAction("Index");
        }

    }
}