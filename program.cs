using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;


namespace flightbooking
{
    class Program
    {
        public static SqlConnection sqlCon { get; set; }
        static DBConnection db = new DBConnection();
        static void Main(string[] args)

        {
            
            int choice;
            var flag = true;
            while(flag)
            {
                Console.WriteLine("Enter the choice:");
                Console.WriteLine("1. Update Airplane Price:");
                Console.WriteLine("2. Enter Airplane by id");
                Console.WriteLine("3. Corporate booking");
                Console.WriteLine("4. Exit");
                choice = Int32.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the  Airplane Id:");
                        int id = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the price info");
                        int price = Int32.Parse(Console.ReadLine());
                        UpdateAirplanePrice(id, price);
                        break;
                    case 2:
                        Console.WriteLine("Enter the  Airplane Id:");
                        int id1 = Int32.Parse(Console.ReadLine());
                        Booking booking = GetAirplaneById(id1);
                        Console.WriteLine("AirplaneID\tBookingFrom\tBookingTo\tTotalSeats\tTicketPrice\tSeatStatus");
                        Console.WriteLine(booking.airplaneId + "\t\t" + booking.bookingFrom + "\t\t" + booking.bookingTo + "\t\t" + booking.totalSeats + "\t\t" + booking.ticketPrice + "\t\t" + booking.seatStatus);
                        break;
                    case 3:
                        Console.WriteLine("Enter the  Corporate code:");
                        string corporateCode = Console.ReadLine();
                        Console.WriteLine("Enter the  no of Passengers");
                        int noOfPassengers = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the  Airplane Id:");
                        int id2 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the price info:");
                        int price1 = Int32.Parse(Console.ReadLine());
                        Booking booking1 = GetAirplaneById(id2);
                        int discount = CalculateCost(corporateCode, noOfPassengers, booking1);
                        int res = (int)((price1 * noOfPassengers) - ((price1 * noOfPassengers) * discount / (double)100));
                        Console.WriteLine(res);
                        break;
                    default:
                        flag = false;
                        break;

                }
            }  

        }
         
        public static void UpdateAirplanePrice(int id, int price)
        {
            sqlCon = new SqlConnection(DBConnection.GetConnection);
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand("Update booking set TicketPrice ="+ price+" where airplaneId ="+ id+";", sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();
        }

        public static Booking GetAirplaneById(int id)
        {

            sqlCon = new SqlConnection(DBConnection.GetConnection);
            sqlCon.Open();

            SqlCommand cmd = new SqlCommand("select * from booking where airplaneId="+id+";", sqlCon);
            SqlDataReader reader = cmd.ExecuteReader();
            Booking booking = new Booking();
            while (reader.Read())
            {
                
                booking.airplaneId = (int)reader[0];
                booking.bookingFrom = reader[1].ToString(); ;
                booking.bookingTo = reader[2].ToString(); ;
                booking.totalSeats = (int)reader[3];
                booking.ticketPrice = (int)reader[4];
                booking.seatStatus = reader[5].ToString();

            }
            sqlCon.Close();
            return booking;
        }

        public static int CalculateCost(string corporateCode, int noOfPassengers, Booking booking)
        {
            var discount = 0 ;
            if (corporateCode == "IBM124" && noOfPassengers <= 10) discount = 10;
            else if (corporateCode == "IBM124" && noOfPassengers > 10) discount = 20;
            else if (corporateCode == "CTS001" && noOfPassengers <= 10) discount = 5;
            else if (corporateCode == "CTS001" && noOfPassengers > 10) discount = 10;
            else if (corporateCode == "COMMON" && noOfPassengers <= 10) discount = 2;
            else discount = 5;
            return discount;
        }
    }  
}
