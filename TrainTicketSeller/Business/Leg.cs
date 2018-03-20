using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTicketSeller.Business
{
    public class Leg
    {
        public int LegID { get; set; }
        public String StartingCity { get; set; }
        public String EndingCity { get; set; }
        public int SeatsAvailable { get; set; }

        public Leg()
        {
            LegID = -1;
            StartingCity = null;
            EndingCity = null;
            SeatsAvailable = -1;
        }

        public Leg(int legID, String startingCity, String endingCity, int seatsAvailable)
        {
            this.LegID = legID;
            this.StartingCity = startingCity;
            this.EndingCity = endingCity;
            this.SeatsAvailable = seatsAvailable;
        }
    }
}
