using System.Collections.Generic;
using System.Web.Http;
using FaunaNet.Subscription;

namespace AccountManager.Controllers.Api
{
 
    /// <summary>
    /// Information about subscriptions. It includes limits, configurations, etc
    /// It does not include any financial information like prices or costs.
    /// </summary>
    [Route("api/subscription")]
    public class SubscriptionController : ApiController
    {
        /// <summary>
        /// Enterprise subscription data for a specific user order.
        /// </summary>
        /// <param name="orderId">Order Id</param>
        /// <returns>Subscription of the enterprise</returns>
        public Subscription Get(int orderId)
        {
            var s = new Subscription
            {
              
                ServerAndDesktopLicenses = 2,
                TotalFemaleLimit = 1000,
                Databases = new List<FarmDatabase>
                {
                    new FarmDatabase{Id=5,Females = 400, Groups = 100, Name="Farm A"},
                    new FarmDatabase{Id=6,Females = 600, Groups = 23, Name="Farm B"}

                },


            };

            return s;

        }

        // PUT: api/Default/5
        public void Put(int orderId, [FromBody]Subscription value)
        {
        }



    }
}
