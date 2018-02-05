using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using campingcare;
using Newtonsoft.Json.Linq;


namespace campingcare_csharp_sdk_tests
{
    public static class reservation_new
    {
       

        public static async void create_reservation()
        {
            try
            {
                Console.WriteLine("*************************************");
                Console.WriteLine("***       CREATE RESERVATION      ***");
                Console.WriteLine("*************************************");


                campingcare_api camping_care = new campingcare_api();
                camping_care.set_api_key("YOUR API KEY");

                var post_values = new List<KeyValuePair<string, string>>();

                post_values.Add(new KeyValuePair<string, string>("arrival", "2018-03-01"));
                post_values.Add(new KeyValuePair<string, string>("departure", "2018-03-05"));

                post_values.Add(new KeyValuePair<string, string>("status", "draft"));

                post_values.Add(new KeyValuePair<string, string>("accommodation_id", "36"));

                post_values.Add(new KeyValuePair<string, string>("first_name", "John"));
                post_values.Add(new KeyValuePair<string, string>("last_name", "Doe"));

                post_values.Add(new KeyValuePair<string, string>("persons", "2"));

                var data = await camping_care.create_reservation(post_values);

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
