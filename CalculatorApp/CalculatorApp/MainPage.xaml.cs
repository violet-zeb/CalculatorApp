using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalculatorApp
{
    public partial class MainPage : ContentPage
    {
        int currentState = 1;
        string mathOperator;
        double firstNumber, secondNumber;
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            currentState=-2;
            Button dugme = (Button)sender;
            string pritisnuto = dugme.Text;
            mathOperator = pritisnuto;
            this.resultText.Text += pritisnuto;
        }

        private void OnClear(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            currentState = 1;
            this.resultText.Text = "0";
        }

        private void ButtonZero_Clicked(object sender, EventArgs e)
        {
            Button dugme = (Button)sender;
            string pritisnuto = dugme.Text;

            if (this.resultText.Text == "0" || currentState<0)
            {
                
                if (currentState < 0)
                {
                    this.resultText.Text = "";
                    currentState *= -1;
                }
            }

            this.resultText.Text += pritisnuto;

            double broj;

            if (double.TryParse(this.resultText.Text, out broj))
            {
                this.resultText.Text = broj.ToString();
                if (currentState == 1)
                {
                    firstNumber = broj;
                }
                else
                {
                    secondNumber = broj;
                }
            }

        }

        private void OnCalculate(object sender, EventArgs e)
        {
            if (currentState == 2)
            {
                var result=Calculate(firstNumber, secondNumber, mathOperator);
                this.resultText.Text = result.ToString();
                firstNumber = result;
                currentState = -1;
            }
        }

        public static double Calculate(double value1, double value2, string mathOperator)
        {
            double result = 0;

            switch (mathOperator)
            {
                case "/":
                    result = value1 / value2;
                    break;
                case "*":
                    result = value1 * value2;
                    break;
                case "+":
                    result = value1 + value2;
                    break;
                case "-":
                    result = value1 - value2;
                    break;
            }

            return result;
        }

    }
}
