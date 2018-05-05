using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_VueJS_CRUD.Models;
using WebAPI_VueJS_CRUD.Models.Service;

namespace WebAPI_VueJS_CRUD.Controllers
{
    public class UserController : ApiController
    {

        private UserProfileDAL db = new UserProfileDAL();

        // GET: api/User
        public IEnumerable<UserProfile> Get()
        {           
            IEnumerable<UserProfile> data = db.GetDataList();
            return data;
        }

        public UserProfile Get(string Email)
        {
           return db.GetData(Email);
        }
     
        // POST: api/User
        public IHttpActionResult Post(UserProfile userProfile)
        {
            db.Add(userProfile);
            return CreatedAtRoute("DefaultApi", null , userProfile);
        }

        // PUT: api/User/5
        public IHttpActionResult Put(UserProfile userProfile)
        {
            if (userProfile.Email==null)
            {
                return BadRequest();
            }

            db.Update(userProfile);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/User/5
        public IHttpActionResult Delete(string Email)
        {
            db.Delete(Email);
            return Ok();
        }
    }
}
