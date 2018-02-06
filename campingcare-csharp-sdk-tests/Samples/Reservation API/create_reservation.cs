using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using campingcare;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace campingcare_csharp_sdk_tests
{
    public static class reservation_new
    {
        /*
        * Example create reservation - How to create a reservation from the Camping.care API
        * https://camping.care/developer/reservations/create_reservation
        */

        public static async void create_reservation()
        {
            try
            {

                Console.WriteLine("*************************************");
                Console.WriteLine("***       CREATE RESERVATION      ***");
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
                *   arrival:            Arrival date for the reservation (YYYY-MM-DD) (required)
                *   departure:          Departure date for the reservation (YYYY-MM-DD) (required)
                *   accommodation_id:   Accommodation id for the reservation. The specific id from a accommodation can be get by the function get accommodations
                *   persons:            The total number of persons in the reservation. (required)
                *   age_table_input:    The age table input of persons for the reservation. The age table input is a JSON string. (required*) (*if age tables are available)
                *   card_id:            The id of an discount card. This id can be found with this function. get cards.
                */

                var send_data = new List<KeyValuePair<string, string>>();


                send_data.Add(new KeyValuePair<string, string>("arrival", "2018-03-01"));
                send_data.Add(new KeyValuePair<string, string>("departure", "2018-03-05"));

                // get your accommodation_id with the api function 'Get accommodations'
                send_data.Add(new KeyValuePair<string, string>("accommodation_id", "36"));

                send_data.Add(new KeyValuePair<string, string>("persons", "5"));


                // Create a age table array and genreate age table JSON data
                var age_tables = new List<age_table_struct>();

                campingcare.age_table_struct age_table0 = new age_table_struct();
                age_table0.id = 29;
                age_table0.count = 3;

                campingcare.age_table_struct age_table1 = new age_table_struct();
                age_table1.id = 30;
                age_table0.count = 2;

                age_tables.Add(age_table0);
                age_tables.Add(age_table1);

                string age_table_json_string = JsonConvert.SerializeObject(age_tables);

                send_data.Add(new KeyValuePair<string, string>("age_table_input", age_table_json_string));


                /*
                * All data is returned in a reservation object
                * The structure can be found here: https://camping.care/developer/reservations/get_reservation.
                */

                var data = await camping_care.create_reservation(send_data);

                /*
                * In this example we print the data in json format in the console
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
