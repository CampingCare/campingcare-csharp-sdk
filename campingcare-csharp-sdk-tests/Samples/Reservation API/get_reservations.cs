using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using campingcare;
using Newtonsoft.Json.Linq;


namespace campingcare_csharp_sdk_tests
{
    public static class reservations
    {
        /*
         * Example get reservations - How to get a specific reservation from the Camping.care API
         * https://camping.care/developer/reservations/get_reservations
         */

        public static async void get_reservations()
        {
            try
            {
                Console.WriteLine("*************************************");
                Console.WriteLine("***       GET RESERVATIONS        ***");
                Console.WriteLine("*************************************");

                /*
                * Initialize the Camping.care API SDK with your API key.
                *
                * See: https://camping.care/settings/api
                */

                campingcare_api camping_care = new campingcare_api();
                camping_care.set_api_key("YOUR API KEY");


                /*
                * Parameters:
                * start_date:		The arrival date where reservations have to be inbetween (required)
                * end_date:	        The departure date where reservations have to be inbetween (required)
                *
                */

                var send_data = new List<KeyValuePair<string, string>>();
                send_data.Add(new KeyValuePair<string, string>("start_date", "2017-01-01")); // (required)
                send_data.Add(new KeyValuePair<string, string>("end_date", "2018-12-31")); // (required)


                /*
                * All data is returned in a reservation object
                * The structure can be found here: https://camping.care/developer/reservations/get_reservation.
                */

                var data = await camping_care.get_reservations(send_data);



                /*
                * In this example we print the oprions in json format in the console
                */

                JObject json = JObject.Parse(data.ToString());

                foreach (var pair in json)
                {
                    Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
                }

            }
            catch (Exception ex)
            {
                LogData(ex.Message);
            }
        }

        private static void LogData(string Message)
        {
            Console.WriteLine("Error: " + Message);
        }
    }
}
