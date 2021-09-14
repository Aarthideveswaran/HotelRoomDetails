using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RoomDetails.Models;

namespace RoomDetails.Controllers
{
    public class Room_DetailsController : ApiController
    {
        private HotelEntities db = new HotelEntities();

        // GET: api/Room_Details
        public IQueryable<Room_Details> GetRoom_Details()
        {
            return db.Room_Details;
        }

        // GET: api/Room_Details/5
        [ResponseType(typeof(Room_Details))]
        public IHttpActionResult GetRoom_Details(int id)
        {
            Room_Details room_Details = db.Room_Details.Find(id);
            if (room_Details == null)
            {
                return NotFound();
            }

            return Ok(room_Details);
        }

        // PUT: api/Room_Details/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoom_Details(int id, Room_Details room_Details)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (id != room_Details.Room_Id)
            {
                return BadRequest();
            }

            db.Entry(room_Details).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Room_DetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Room_Details
        [ResponseType(typeof(Room_Details))]
        public IHttpActionResult PostRoom_Details(Room_Details room_Details)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            db.Room_Details.Add(room_Details);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = room_Details.Room_Id }, room_Details);
        }

        // DELETE: api/Room_Details/5
        [ResponseType(typeof(Room_Details))]
        public IHttpActionResult DeleteRoom_Details(int id)
        {
            Room_Details room_Details = db.Room_Details.Find(id);
            if (room_Details == null)
            {
                return NotFound();
            }

            db.Room_Details.Remove(room_Details);
            db.SaveChanges();

            return Ok(room_Details);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Room_DetailsExists(int id)
        {
            return db.Room_Details.Count(e => e.Room_Id == id) > 0;
        }
    }
}