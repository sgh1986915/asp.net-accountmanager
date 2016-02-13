using System;
using System.Linq;
using System.Web.Http;
using FaunaNet.Subscription;

namespace AccountManager.Controllers.Api
{


    /// <summary>
    /// Information related with payments, prices and credits
    /// </summary>
    [Route("api/billing")]
    public class BillingController : ApiController
    {


        // GET: api/billing?profile=por
        /// <summary>
        /// Get parameters to calculate the price of a new subscription. 
        /// Also, it provides information about intervals and maximums for subscriptionoptions.
        /// </summary>
        /// <returns></returns>
        public SubscriptionPriceScheme Get(string profile)
        {

            // Defineixo els preus i els escalats que s'apliquen per a cada servei d'una subscripció
            var porcitec = new SubscriptionPriceScheme
            {
                ProEditionPrice = 230,
                StudioEditionPrice = 900,
                FemalesPriceUnits =
                    new PriceUnits[]
                    {
                        new PriceUnits {Units = 10, Cost = 100}, new PriceUnits {Units = 20, Cost = 180},
                        new PriceUnits {Units = 50, Cost = 200}
                    },
            
                ServerAndDesktopPrice = new PriceScheme {Rate = 200, Max = 100, Included = 1},
                DesktopPrice = new PriceScheme {Rate = 20, Max = 100, Included = 10},
                ConsultantPrice = new PriceScheme {Rate = 200, Max = 20},
                MobilePrice = new PriceScheme {Rate = 90, Max = 20},
                UltimateTierMinPrice = 100,
                UltimateTierPercentPrice = 20,
                OwnWebServerUserPrice = new PriceScheme {Rate = 10, Max = 100, Included = 20, Interval = 5},
                AgritecWebServerUserPrice = new PriceScheme {Rate = 20, Max = 100, Interval = 5},
                RemoteAppUserPrice = new PriceScheme {Rate = 200, Max = 20},

            };

            porcitec.GroupPriceUnits =
                porcitec.FemalesPriceUnits.Select(fprice => new PriceUnits {Units = fprice.Units*30}).ToArray();
            return porcitec;
        }

        /// <summary>
        /// Get billing information about a specific enterprise
        /// </summary>
        /// <param name="enterprise"></param>
        /// <returns></returns>
        [Route("api/billing")]
        public PriceSubscription Get(int enterprise)
        {
            var s = new PriceSubscription
            {
                Currency = "EUR",
                CostToRenovation = 100,
                Credit = 55,
                
                CurrencyRates = new Currency[]
                {
                    new Currency{ Code="EUR", Symbol="€", Rate = 1.00},
                    new Currency{ Code="USD", Symbol="$", Rate = 1.45},
                    new Currency{ Code="GBP", Symbol="£", Rate = 0.82},
                }
            };

            return s;
        }
    }


}
