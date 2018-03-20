namespace TrainTicketSeller
{
    partial class LegSelector
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
            this.cboStartingCity = new System.Windows.Forms.ComboBox();
            this.cboEndingCity = new System.Windows.Forms.ComboBox();
            this.lblStartingCity = new System.Windows.Forms.Label();
            this.lblEndingCity = new System.Windows.Forms.Label();
            this.btnCheckAvailability = new System.Windows.Forms.Button();
            this.txtTicketQuantity = new System.Windows.Forms.TextBox();
            this.lblNumberOfTickets = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnOrder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboStartingCity
            // 
            this.cboStartingCity.FormattingEnabled = true;
            this.cboStartingCity.Location = new System.Drawing.Point(35, 51);
            this.cboStartingCity.Name = "cboStartingCity";
            this.cboStartingCity.Size = new System.Drawing.Size(150, 21);
            this.cboStartingCity.TabIndex = 0;
            // 
            // cboEndingCity
            // 
            this.cboEndingCity.FormattingEnabled = true;
            this.cboEndingCity.Location = new System.Drawing.Point(191, 51);
            this.cboEndingCity.Name = "cboEndingCity";
            this.cboEndingCity.Size = new System.Drawing.Size(150, 21);
            this.cboEndingCity.TabIndex = 1;
            // 
            // lblStartingCity
            // 
            this.lblStartingCity.AutoSize = true;
            this.lblStartingCity.Location = new System.Drawing.Point(32, 35);
            this.lblStartingCity.Name = "lblStartingCity";
            this.lblStartingCity.Size = new System.Drawing.Size(63, 13);
            this.lblStartingCity.TabIndex = 2;
            this.lblStartingCity.Text = "Starting City";
            // 
            // lblEndingCity
            // 
            this.lblEndingCity.AutoSize = true;
            this.lblEndingCity.Location = new System.Drawing.Point(188, 35);
            this.lblEndingCity.Name = "lblEndingCity";
            this.lblEndingCity.Size = new System.Drawing.Size(60, 13);
            this.lblEndingCity.TabIndex = 3;
            this.lblEndingCity.Text = "Ending City";
            // 
            // btnCheckAvailability
            // 
            this.btnCheckAvailability.Location = new System.Drawing.Point(35, 104);
            this.btnCheckAvailability.Name = "btnCheckAvailability";
            this.btnCheckAvailability.Size = new System.Drawing.Size(114, 23);
            this.btnCheckAvailability.TabIndex = 3;
            this.btnCheckAvailability.Text = "Check Availability";
            this.btnCheckAvailability.UseVisualStyleBackColor = true;
            this.btnCheckAvailability.Click += new System.EventHandler(this.btnCheckAvailability_Click);
            // 
            // txtTicketQuantity
            // 
            this.txtTicketQuantity.Location = new System.Drawing.Point(347, 52);
            this.txtTicketQuantity.MaxLength = 2;
            this.txtTicketQuantity.Name = "txtTicketQuantity";
            this.txtTicketQuantity.Size = new System.Drawing.Size(26, 20);
            this.txtTicketQuantity.TabIndex = 2;
            // 
            // lblNumberOfTickets
            // 
            this.lblNumberOfTickets.AutoSize = true;
            this.lblNumberOfTickets.Location = new System.Drawing.Point(344, 35);
            this.lblNumberOfTickets.Name = "lblNumberOfTickets";
            this.lblNumberOfTickets.Size = new System.Drawing.Size(79, 13);
            this.lblNumberOfTickets.TabIndex = 6;
            this.lblNumberOfTickets.Text = "Ticket Quantity";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(32, 130);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(35, 13);
            this.lblInfo.TabIndex = 7;
            this.lblInfo.Text = "lblInfo";
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(191, 104);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(75, 23);
            this.btnOrder.TabIndex = 8;
            this.btnOrder.Text = "Order";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // LegSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblNumberOfTickets);
            this.Controls.Add(this.txtTicketQuantity);
            this.Controls.Add(this.btnCheckAvailability);
            this.Controls.Add(this.lblEndingCity);
            this.Controls.Add(this.lblStartingCity);
            this.Controls.Add(this.cboEndingCity);
            this.Controls.Add(this.cboStartingCity);
            this.Name = "LegSelector";
            this.Text = "LegSelectorcs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboStartingCity;
        private System.Windows.Forms.ComboBox cboEndingCity;
        private System.Windows.Forms.Label lblStartingCity;
        private System.Windows.Forms.Label lblEndingCity;
        private System.Windows.Forms.Button btnCheckAvailability;
        private System.Windows.Forms.TextBox txtTicketQuantity;
        private System.Windows.Forms.Label lblNumberOfTickets;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnOrder;
    }
}