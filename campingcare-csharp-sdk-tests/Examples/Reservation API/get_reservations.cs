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
       

        public static async void get_reservations()
        {
            try
            {
                Console.WriteLine("*************************************");
                Console.WriteLine("***       GET RESERVATIONS        ***");
                Console.WriteLine("*************************************");


                campingcare_api camping_care = new campingcare_api();
                camping_care.set_api_key("YOUR API KEY");

                var post_values = new List<KeyValuePair<string, string>>();
                post_values.Add(new KeyValuePair<string, string>("arrival", "2017-01-01"));
                post_values.Add(new KeyValuePair<string, string>("departure", "2018-12-31"));
                var data = await camping_care.get_reservations(post_values);

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
