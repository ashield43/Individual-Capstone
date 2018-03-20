using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTicketSeller.Business
{
    public class LegListManager : Collection<Leg>
    {
        public LegListManager() { }

        public static List<Leg> CreateLegList(BindingList<String> cityList)
        {
            List<Leg> legList = new List<Leg>();

            for(int i = 1; i < cityList.Count; i++)
            {
                Leg newLeg = new Leg();
                newLeg.StartingCity = cityList[i - 1];
                newLeg.EndingCity = cityList[i];
                legList.Add(newLeg);
            }

            return legList;
        }

        public static List<Leg> SetSeatAvailability(int start, int end, List<Leg> legs, int quantity)
        {
            for (int i = start; i <= end; i++)
            {
                legs[i].SeatsAvailable -= quantity;
            }

            return legs;
        }
    }
}