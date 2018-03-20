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
    public partial class AddTrain : Form
    {
        Regex stringRegex = new Regex("^[a-zA-Z\\s]{1,100}$");
        Regex intRegex = new Regex("^[0-9]{1,3}$");
        BindingList<String> cityList = new BindingList<String>();

        public AddTrain()
        {
            InitializeComponent();
            lstCities.DataSource = cityList;
        }

        // Add city to BindingList
        private void btnAddCity_Click(object sender, EventArgs e)
        {
            if (stringRegex.IsMatch(txtAddCity.Text))
            {
                String insertString = txtAddCity.Text;
                cityList.Add(txtAddCity.Text);
            }
            else
            {
                MessageBox.Show("You must enter a city name, and it cannot contain numbers or symbols.", "Error");
            }
            txtAddCity.Text = "";
        }

        // Remove city from BindingList
        private void btnRemoveCity_Click(object sender, EventArgs e)
        {
            if(lstCities.SelectedItem == null)
            {
                return; // End function if nothing was selected
            }

            cityList.Remove((String)lstCities.SelectedItem);
        }

        private void btnAddTrain_Click(object sender, EventArgs e)
        {
            if (stringRegex.IsMatch(txtTrainName.Text))
            {
                if (intRegex.IsMatch(txtNumberOfSeats.Text))
                {
                    if (cityList.Count > 1)
                    {
                        // Create the new train and add it to the database
                        Train newTrain = new Train(txtTrainName.Text, Int32.Parse(txtNumberOfSeats.Text));
                        newTrain.TrainID = TrainCommands.AddTrain(newTrain);

                        // Create all of the legs of the new train with the cityList object
                        LegListManager createLegList = new LegListManager();
                        List<Leg> finalLegList = LegListManager.CreateLegList(cityList);

                        // Store each leg in the database
                        foreach(Leg leg in finalLegList)
                        {
                            leg.LegID = LegCommands.AddLeg(leg);
                        }

                        // Update the RouteStops table to make sure the legs of the train are stored in the correct order
                        for(int i = 0; i < finalLegList.Count; i++ )
                        {
                            RouteStopCommands.AddRouteStop(newTrain, finalLegList[i], i+1);
                        }

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("There must be at least two cities on the route", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Number of seats must be a number less than 3 digits long", "Error");
                }
            }
            else
            {
                MessageBox.Show("You must enter a train name, and it cannot contain numbers or symbols", "Error");
            }
        }

        private void btnCityUp_Click(object sender, EventArgs e)
        {
            MoveItem(-1);
        }

        private void btnCityDown_Click(object sender, EventArgs e)
        {
            MoveItem(1);
        }

        public void MoveItem(int direction)
        {
            // Checking selected item
            if (lstCities.SelectedItem == null || lstCities.SelectedIndex < 0)
            {
                return; // No selected item - nothing to do
            }

            // Calculate new index using move direction
            int newIndex = lstCities.SelectedIndex + direction;

            // Checking bounds of the range, make sure it doesn't go below 0 or max size of the list
            if (newIndex < 0 || newIndex >= cityList.Count)
            {
                return; // Index out of range - nothing to do
            }

            String selected = lstCities.SelectedItem.ToString();

            // Removing removable element
            cityList.Remove(selected);
            // Insert it in new position
            cityList.Insert(newIndex, selected);
            // Restore selection
            lstCities.SetSelected(newIndex, true);
        }
    }
}
