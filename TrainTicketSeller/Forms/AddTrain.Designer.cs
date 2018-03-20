namespace TrainTicketSeller
{
    partial class AddTrain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstCities = new System.Windows.Forms.ListBox();
            this.lblCities = new System.Windows.Forms.Label();
            this.lblTrainName = new System.Windows.Forms.Label();
            this.txtTrainName = new System.Windows.Forms.TextBox();
            this.lblNumberOfSeats = new System.Windows.Forms.Label();
            this.txtNumberOfSeats = new System.Windows.Forms.TextBox();
            this.lblAddCity = new System.Windows.Forms.Label();
            this.txtAddCity = new System.Windows.Forms.TextBox();
            this.btnAddCity = new System.Windows.Forms.Button();
            this.btnRemoveCity = new System.Windows.Forms.Button();
            this.btnCityUp = new System.Windows.Forms.Button();
            this.btnCityDown = new System.Windows.Forms.Button();
            this.btnAddTrain = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstCities
            // 
            this.lstCities.FormattingEnabled = true;
            this.lstCities.Location = new System.Drawing.Point(185, 45);
            this.lstCities.Name = "lstCities";
            this.lstCities.Size = new System.Drawing.Size(120, 173);
            this.lstCities.TabIndex = 1;
            // 
            // lblCities
            // 
            this.lblCities.AutoSize = true;
            this.lblCities.Location = new System.Drawing.Point(182, 29);
            this.lblCities.Name = "lblCities";
            this.lblCities.Size = new System.Drawing.Size(32, 13);
            this.lblCities.TabIndex = 2;
            this.lblCities.Text = "Cities";
            // 
            // lblTrainName
            // 
            this.lblTrainName.AutoSize = true;
            this.lblTrainName.Location = new System.Drawing.Point(37, 29);
            this.lblTrainName.Name = "lblTrainName";
            this.lblTrainName.Size = new System.Drawing.Size(62, 13);
            this.lblTrainName.TabIndex = 3;
            this.lblTrainName.Text = "Train Name";
            // 
            // txtTrainName
            // 
            this.txtTrainName.Location = new System.Drawing.Point(40, 45);
            this.txtTrainName.Name = "txtTrainName";
            this.txtTrainName.Size = new System.Drawing.Size(100, 20);
            this.txtTrainName.TabIndex = 4;
            // 
            // lblNumberOfSeats
            // 
            this.lblNumberOfSeats.AutoSize = true;
            this.lblNumberOfSeats.Location = new System.Drawing.Point(37, 92);
            this.lblNumberOfSeats.Name = "lblNumberOfSeats";
            this.lblNumberOfSeats.Size = new System.Drawing.Size(88, 13);
            this.lblNumberOfSeats.TabIndex = 5;
            this.lblNumberOfSeats.Text = "Number Of Seats";
            // 
            // txtNumberOfSeats
            // 
            this.txtNumberOfSeats.Location = new System.Drawing.Point(40, 108);
            this.txtNumberOfSeats.MaxLength = 3;
            this.txtNumberOfSeats.Name = "txtNumberOfSeats";
            this.txtNumberOfSeats.Size = new System.Drawing.Size(28, 20);
            this.txtNumberOfSeats.TabIndex = 6;
            // 
            // lblAddCity
            // 
            this.lblAddCity.AutoSize = true;
            this.lblAddCity.Location = new System.Drawing.Point(40, 153);
            this.lblAddCity.Name = "lblAddCity";
            this.lblAddCity.Size = new System.Drawing.Size(94, 13);
            this.lblAddCity.TabIndex = 7;
            this.lblAddCity.Text = "Add City To Route";
            // 
            // txtAddCity
            // 
            this.txtAddCity.Location = new System.Drawing.Point(40, 169);
            this.txtAddCity.Name = "txtAddCity";
            this.txtAddCity.Size = new System.Drawing.Size(100, 20);
            this.txtAddCity.TabIndex = 8;
            // 
            // btnAddCity
            // 
            this.btnAddCity.Location = new System.Drawing.Point(40, 195);
            this.btnAddCity.Name = "btnAddCity";
            this.btnAddCity.Size = new System.Drawing.Size(75, 23);
            this.btnAddCity.TabIndex = 9;
            this.btnAddCity.Text = "Add City";
            this.btnAddCity.UseVisualStyleBackColor = true;
            this.btnAddCity.Click += new System.EventHandler(this.btnAddCity_Click);
            // 
            // btnRemoveCity
            // 
            this.btnRemoveCity.Location = new System.Drawing.Point(185, 224);
            this.btnRemoveCity.Name = "btnRemoveCity";
            this.btnRemoveCity.Size = new System.Drawing.Size(120, 23);
            this.btnRemoveCity.TabIndex = 10;
            this.btnRemoveCity.Text = "Remove City";
            this.btnRemoveCity.UseVisualStyleBackColor = true;
            this.btnRemoveCity.Click += new System.EventHandler(this.btnRemoveCity_Click);
            // 
            // btnCityUp
            // 
            this.btnCityUp.Location = new System.Drawing.Point(311, 105);
            this.btnCityUp.Name = "btnCityUp";
            this.btnCityUp.Size = new System.Drawing.Size(23, 23);
            this.btnCityUp.TabIndex = 11;
            this.btnCityUp.Text = "▲";
            this.btnCityUp.UseVisualStyleBackColor = true;
            this.btnCityUp.Click += new System.EventHandler(this.btnCityUp_Click);
            // 
            // btnCityDown
            // 
            this.btnCityDown.Location = new System.Drawing.Point(311, 137);
            this.btnCityDown.Name = "btnCityDown";
            this.btnCityDown.Size = new System.Drawing.Size(23, 23);
            this.btnCityDown.TabIndex = 12;
            this.btnCityDown.Text = "▼";
            this.btnCityDown.UseVisualStyleBackColor = true;
            this.btnCityDown.Click += new System.EventHandler(this.btnCityDown_Click);
            // 
            // btnAddTrain
            // 
            this.btnAddTrain.Location = new System.Drawing.Point(234, 276);
            this.btnAddTrain.Name = "btnAddTrain";
            this.btnAddTrain.Size = new System.Drawing.Size(100, 23);
            this.btnAddTrain.TabIndex = 13;
            this.btnAddTrain.Text = "Add Train";
            this.btnAddTrain.UseVisualStyleBackColor = true;
            this.btnAddTrain.Click += new System.EventHandler(this.btnAddTrain_Click);
            // 
            // AddTrain
            // 
            this.AcceptButton = this.btnAddCity;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 311);
            this.Controls.Add(this.btnAddTrain);
            this.Controls.Add(this.btnCityDown);
            this.Controls.Add(this.btnCityUp);
            this.Controls.Add(this.btnRemoveCity);
            this.Controls.Add(this.btnAddCity);
            this.Controls.Add(this.txtAddCity);
            this.Controls.Add(this.lblAddCity);
            this.Controls.Add(this.txtNumberOfSeats);
            this.Controls.Add(this.lblNumberOfSeats);
            this.Controls.Add(this.txtTrainName);
            this.Controls.Add(this.lblTrainName);
            this.Controls.Add(this.lblCities);
            this.Controls.Add(this.lstCities);
            this.Name = "AddTrain";
            this.Text = "AddTrain";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstCities;
        private System.Windows.Forms.Label lblCities;
        private System.Windows.Forms.Label lblTrainName;
        private System.Windows.Forms.TextBox txtTrainName;
        private System.Windows.Forms.Label lblNumberOfSeats;
        private System.Windows.Forms.TextBox txtNumberOfSeats;
        private System.Windows.Forms.Label lblAddCity;
        private System.Windows.Forms.TextBox txtAddCity;
        private System.Windows.Forms.Button btnAddCity;
        private System.Windows.Forms.Button btnRemoveCity;
        private System.Windows.Forms.Button btnCityUp;
        private System.Windows.Forms.Button btnCityDown;
        private System.Windows.Forms.Button btnAddTrain;
    }
}