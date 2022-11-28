using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        /* Name: Hayden withers
* Date: nov 6 2022
* This program calculates an annuity */
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        double totalPayment = 0;
        const int minYears = 5;
        const string FLname = "hayden_withers";
        //class level variables

        private void picHelp_Click(object sender, EventArgs e)
        {

            string help = "this program reads in two numbers:" + "\n" + "\t" + "future value: amount of ''$'' " + "\n" + "\t" + "years must be at least:" + minYears + "\n" +
                "and calculates payments based on:" + "\n" + "\t" + "yearly intrest rate of " + Convert.ToString(lblRatePerYear.Text) + "%";
            MessageBox.Show(help, FLname);
            // displays messagebox with relevant info on the form and formula
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            string exit = "Thank you for using the program!" + "\n" + "total payments ="  + totalPayment.ToString("C2")  ; //+ total payment value read in
            MessageBox.Show(exit, FLname);
            this.Close();
            // shows a messagebox with some info and closes the form
         }

        private void ResetAll()
        {
            txtFutureValue.Text = "";
            txtYears.Text = "";
            grpSolution.Visible = false; 
            lblPayments.Visible = false;
            txtFutureValue.Focus();
            //function to reset the page
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResetAll();
            // calling above function
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetAll();
        //calling above function
        }


        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try //tries the conversions and calculations, if it fails, display a message to the user
            {
                double TotalYears = Convert.ToDouble(txtYears.Text);
                double FutureValue = Convert.ToDouble(txtFutureValue.Text);
                string RateConvert = Convert.ToString(lblRatePerYear.Text);
                double rate = Convert.ToDouble(RateConvert);
                double percentRate = rate/100;
                if (minYears <= TotalYears) //checks that years are at least 5, if it is do the equation and display ansewr, if not display an error message to user
                {
                    totalPayment = FutureValue *( percentRate/12)/ (Math.Pow(1 + percentRate / 12, TotalYears*12)-1);
                    lblPayments.Text = totalPayment.ToString("C2");
                    grpSolution.Visible = true;
                    lblPayments.Visible = true;
                }

                else // messagebox shown if years is less than 5
                {
                    MessageBox.Show("years must be at least 5", FLname);
                }
            }
            catch //error shown for try catch
            {
                MessageBox.Show("input string was not in correct format", FLname);
            }
        }// change made here
    }
}
