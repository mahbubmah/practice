using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleApp
{
    public partial class VehicleUI : Form
    {
        private Vehicle aVehicle;
        public VehicleUI()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            aVehicle = new Vehicle(nametTextBox.Text, regNoTextBox.Text);
            MessageBox.Show("Vehicle has been created");
        }

        private void setCurrentSpeed_Click(object sender, EventArgs e)
        {
            double currentSpeed = Convert.ToDouble(currentSpeedTextBox.Text);
            aVehicle.SetSpeed(currentSpeed);
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            minSpeedTextBox.Text = aVehicle.MinSpeed.ToString();
            maxTextBox.Text = aVehicle.MaxSpeed.ToString();
            averageSpeedTextBox.Text = aVehicle.AvgSpeed.ToString();
        }
    }
}
