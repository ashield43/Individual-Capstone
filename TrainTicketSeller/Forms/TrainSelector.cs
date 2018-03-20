using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainTicketSeller.Business;
using TrainTicketSeller.Database;
using TrainTicketSeller.Forms;

namespace TrainTicketSeller
{
    public partial class Form1 : Form
    {
        List<Train> trainList;
        Train selectedTrain;
        DateTime departureDate = DateTime.Today;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Clear all trains that have completed their routes and cannot sell their tickets
            RouteStopCommands.ClearRouteStopAvailabilty();

            Setup();
        }


        private void btnSelect_Click(object sender, EventArgs e)
        {
            // Check if user selected a train
            if (selectedTrain != null)
            {
                // Check if the train is set to depart today or a day in the future
                if (departureDate >= DateTime.Today)
                {
                    selectedTrain.DepartureDate = departureDate;
                    LegSelector test = new LegSelector(selectedTrain);
                    test.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Depature date cannot be in the past", "Error");
                }
            }
            else
            {
                MessageBox.Show("You must select a train", "Error");              
            }
        }

        // Admin only feature to add trains to the database
        private void btnAddTrain_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.ShowDialog();
            Setup();
        }

        // Sets up page for when the form first loads, and after the login window
        // closes to refresh the combobox if a train was added
        private void Setup()
        {
            lblRoute.Text = "";

            trainList = TrainCommands.GetTrains();

            cboTrainList.Items.Clear();
            foreach (Train train in trainList)
            {
                train.ListOfLegs = LegCommands.GetLegs(train.TrainID);
                cboTrainList.Items.Add(train);
            }
        }

        private void cboTrainList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTrain = (Train)cboTrainList.SelectedItem;
            lblRoute.Text = selectedTrain.OutputRoute();
        }

        private void dtpDepartureDate_ValueChanged(object sender, EventArgs e)
        {
            departureDate = dtpDepartureDate.Value.Date;
        }
    }
}
