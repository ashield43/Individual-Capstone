using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainTicketSeller.Business;
using TrainTicketSeller.Database;

namespace TrainTicketSeller
{
    public partial class LegSelector : Form
    {
        Train train { get; set; }
        int startingCityIndex;
        int endingCityIndex;
        bool trainExists;
        Leg[] endingCityList;

        public LegSelector(Train train)
        {
            InitializeComponent();
            lblInfo.Text = "";

            SetupTrain(train);
            SetupComboBoxes();
            SetupSeatAvailabilty();
        }

        // Check the number of seats available through the selected route
        private void btnCheckAvailability_Click(object sender, EventArgs e)
        {
            // Check if starting city is before ending city
            if (!ValidateCityOrder())
            {
                MessageBox.Show("Your ending city must come after starting city", "Error");
            }
            else
            {
                int minimumSeats = train.NumberOfSeats;

                // Keeps track of the fewest seats through each leg to properly list how many seats are guaranteed throughout the route
                // If you want to go from A to D, and B to C only has 3 seats, then we can only sell 3 tickets through A to D
                for (int i = startingCityIndex; i <= endingCityIndex; i++)
                {
                    if(minimumSeats > train.ListOfLegs[i].SeatsAvailable)
                    {
                        minimumSeats = train.ListOfLegs[i].SeatsAvailable;
                    }
                }

                lblInfo.Text = "There are " + minimumSeats.ToString() + " seats avaiable for the selected trip";
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Regex intRegex = new Regex("^[0-9]{1,2}$");
            int quantity = 0;

            // Validate ticket quantity
            if (!intRegex.IsMatch(txtTicketQuantity.Text))
            {
                MessageBox.Show("Ticket Quanity must be a number greater than zero.", "Error");
                return;
            }
            else
            {
                quantity = Int32.Parse(txtTicketQuantity.Text);
            }

            // Check if starting city is before ending city
            if (ValidateCityOrder())
            {
                int a = startingCityIndex;
                bool continueLoop = true;

                // Check if there are enough seats on the train for the selected quantity of tickets
                while (a <= endingCityIndex && continueLoop)
                {
                    if(train.ListOfLegs[a].SeatsAvailable - quantity < 0)
                    {
                        continueLoop = false;
                        MessageBox.Show("Not enough seats on current route for selected quantity of tickets.", "Error");
                        return;
                    }
                    a++;
                }

                // If there are enough seats on every selected leg, sell the tickets and update the database accordingly
                // If the train was already found in the database, it only updates the legs selected by the customer
                if (trainExists)
                {
                    LegListManager.SetSeatAvailability(startingCityIndex, endingCityIndex, train.ListOfLegs, quantity);
                    for (int i = startingCityIndex; i <= endingCityIndex; i++)
                    {
                        RouteStopCommands.UpdateRouteStopAvailability(train, i);
                    }
                }
                // If the train was not found in the database, all legs of the train are stored
                // Legs that did not sell tickets are stored with a value equaling the number of seats on the train
                else
                {
                    LegListManager.SetSeatAvailability(startingCityIndex, endingCityIndex, train.ListOfLegs, quantity);
                    RouteStopCommands.AddRouteStopAvailability(train);
                    // Since the train was just created, update the form to properly show the train now exists
                    trainExists = true;
                }

                // If everything works, tell the customer their trip has been saved.
                lblInfo.Text = "Your trip from " + train.ListOfLegs[startingCityIndex].StartingCity + " to " + train.ListOfLegs[endingCityIndex].EndingCity + " has been booked.";
            }
            else
            {
                MessageBox.Show("Your ending city must come after starting city", "Error");
            }
        }

        private bool ValidateCityOrder()
        {
            bool valid = true;

            startingCityIndex = train.ListOfLegs.FindIndex(x => x == cboStartingCity.SelectedItem);
            endingCityIndex = train.ListOfLegs.FindIndex(x => x == cboEndingCity.SelectedItem);

            if (startingCityIndex > endingCityIndex)
            {
                valid = false;
            }

            return valid;
        }

        #region Form Setup Methods
        private void SetupComboBoxes()
        {
            cboStartingCity.DataSource = train.ListOfLegs;
            cboStartingCity.DisplayMember = "StartingCity";

            cboEndingCity.DataSource = endingCityList;
            cboEndingCity.DisplayMember = "EndingCity";
        }

        private void SetupSeatAvailabilty()
        {
            foreach (Leg leg in train.ListOfLegs)
            {
                if (trainExists)
                {
                    leg.SeatsAvailable = LegCommands.GetLegAvailability(train.TrainID, leg.LegID, train.DepartureDate);
                }
                else
                {
                    leg.SeatsAvailable = train.NumberOfSeats;
                }
            }
        }

        private void SetupTrain(Train train)
        {
            this.train = train;
            trainExists = TrainCommands.TrainRouteExists(train);
            endingCityList = new Leg[train.ListOfLegs.Count];
            train.ListOfLegs.CopyTo(endingCityList);
        }
        #endregion
    }
}
