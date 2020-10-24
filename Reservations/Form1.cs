using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reservations
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            // global
            const double rate = 120.0;
            const double weekendRate = 150.0;

            // get data
            DateTime arrival, departure;
            int nights;
            double price, avgPrice;
            try
            {
                arrival = Convert.ToDateTime(tbArrival.Text);
                departure = Convert.ToDateTime(tbDeparture.Text);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.StackTrace);
                return;
            }
            nights = Convert.ToInt32((departure - arrival).TotalDays);

            // calc prices
            price = 0;
            for (int x = 0; x < nights; x++)
            {
                if (arrival.AddDays(x).DayOfWeek == DayOfWeek.Friday || 
                    arrival.AddDays(x).DayOfWeek == DayOfWeek.Saturday)
                {
                    price += weekendRate;
                }
                else
                {
                    price += rate;
                }
            }
            avgPrice = price / nights;

            // display
            tbNights.Text = Convert.ToString(nights);
            tbPrice.Text = price.ToString("C");
            tbAvgPrice.Text = avgPrice.ToString("C");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbArrival.Text = Convert.ToString(DateTime.Today.ToShortDateString());
            tbDeparture.Text = Convert.ToString(DateTime.Today.AddDays(3).ToShortDateString());
        }
    }
}
