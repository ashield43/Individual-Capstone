using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTicketSeller.Business
{
    public class Train
    {
        public int TrainID { get; set; }
        public String TrainName { get; set; }
        public int NumberOfSeats { get; set; }
        public List<Leg> ListOfLegs { get; set; }
        public DateTime DepartureDate { get; set; }

        public Train()
        {
            TrainID = -1;
            TrainName = null;
            NumberOfSeats = -1;
            ListOfLegs = new List<Leg>();
        }

        public Train(String trainName, int numberOfSeats)
        {
            TrainName = trainName;
            NumberOfSeats = numberOfSeats;
            ListOfLegs = new List<Leg>();
        }

        // Generates a string to display each city in the route for the train
        public String OutputRoute()
        {
            String outputString = "";

            if(ListOfLegs.Count > 0)
            {
                outputString = ListOfLegs[0].StartingCity + " - ";

                for(int i = 0; i < ListOfLegs.Count - 1; i ++)
                {
                    outputString += ListOfLegs[i].EndingCity + " - ";
                }

                outputString += ListOfLegs.Last().EndingCity;
            }

            return outputString;
        }

        // Generates a string to give the train name, the city the train starts in, and the city the train ends in
        override
        public String ToString()
        {
            String returnString = TrainName + ": " + ListOfLegs.First().StartingCity + " - " + ListOfLegs.Last().EndingCity;

            return returnString;
        }
    }
}
