using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Security;
using AccountManager.Models;
using FaunaNet.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebMatrix.WebData;

namespace AccountManager.Controllers.Api
{
    /// <summary>
    /// User management. It includes create new user accounts, update addresses, etc.
    /// </summary>
    [RoutePrefix("api")]
    [Authorize]
    public class UserController : ApiController
    {
        private SubscriptionEntities db = new SubscriptionEntities();

        /// <summary>
        /// Creates a new user account. If exists then it returns error
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("register")]
        public HttpResponseMessage Post(RegisterModel register)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            var user = new ApplicationUser() { UserName = register.Email, Email = register.Email };

            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            IdentityResult result = userManager.Create(user, register.Password);
            return Request.CreateResponse(result.Succeeded ? HttpStatusCode.OK : HttpStatusCode.BadRequest);

        }

        
        // DELETE: api/User/5
        /// <summary>
        /// Deletes a user and its related data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = ApplicationRoles.AdministratorRole)]
        [ResponseType(typeof(UserAddress))]
        public IHttpActionResult DeleteUser(int id)
        {
           // var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

          //  userManager.Delete()
            string username = UserHelper.CurrentPrincial.Identity.Name;

            UserAddress userAddress = db.UserAddress.Find(id);
            if (userAddress != null)
            {
                db.UserAddress.Remove(userAddress);
                db.SaveChanges();
    
            }

            if (Roles.GetRolesForUser(username).Any())
            {
                Roles.RemoveUserFromRoles(username, Roles.GetRolesForUser(username));
            }
            ((SimpleMembershipProvider)Membership.Provider).DeleteAccount(username); // deletes record from webpages_Membership table
            //((SimpleMembershipProvider)Membership.Provider).DeleteUser(userName, true); // deletes record from UserProfile table


            return Ok(userAddress);
        }


        /*
        // GET: api/User
        public IQueryable<UserAddress> GetUserAddress()
        {
            return db.UserAddress;
        }
        */

        // GET: api/User/5
        /// <summary>
        /// Get information from a user (address, billing address, ...)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(UserAddress))]
        public IHttpActionResult GetUserAddress(int id)
        {
            UserAddress userAddress = db.UserAddress.Find(id);
            if (userAddress == null)
            {
                return NotFound();
            }

            return Ok(userAddress);
        }

       
        // PUT: api/User/5
        /// <summary>
        /// Update user information (address, billing address, ...)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userAddress"></param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserAddress(int id, UserAddress userAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userAddress.UserId)
            {
                return BadRequest();
            }

            db.Entry(userAddress).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAddressExists(id))
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

        // POST: api/User
        /// <summary>
        /// Add user information (address, billing address, ...)
        /// </summary>
        /// <param name="userAddress"></param>
        /// <returns></returns>
        [ResponseType(typeof(UserAddress))]
        public IHttpActionResult PostUserAddress(UserAddress userAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserAddress.Add(userAddress);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UserAddressExists(userAddress.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = userAddress.UserId }, userAddress);
        }
        

    
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserAddressExists(int id)
        {
            return db.UserAddress.Count(e => e.UserId == id) > 0;
        }
    }
}