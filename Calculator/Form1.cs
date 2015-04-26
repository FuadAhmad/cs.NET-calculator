using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private double _value = 0;
        private string _operator = "";
        private bool _isOperatorPressed = false;
        private bool _isEqualPressed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnDigit_Click(object sender, EventArgs e)
        {
            if ((result.Text == "0") || _isOperatorPressed)
            {
                result.Clear();
                _isOperatorPressed = false;
            }
            if (_isEqualPressed)
            {
                result.Clear();
                _isEqualPressed = false;
            }
            Button b = (Button) sender;
            if (b.Text == ".")
            {
                if (!result.Text.Contains("."))
                {
                    result.Text = result.Text + b.Text;
                }
            }else
            {
                result.Text = result.Text + b.Text;
            }            
            if (result.Text == ".")
            {
                result.Text = "0.";
            }    
        }

        private void operator_Click(object sender, EventArgs e)
        {
            _isOperatorPressed = true;
            Button b = (Button)sender;
            _operator = b.Text;
            _value = double.Parse(result.Text);       
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            _isEqualPressed = true;
            switch(_operator)
            {
                case "+":
                    result.Text = (_value + Double.Parse(result.Text)).ToString();
                    break;
                case "-":
                    result.Text = (_value - Double.Parse(result.Text)).ToString();
                    break;
                case "*":
                    result.Text = (_value * Double.Parse(result.Text)).ToString();
                    break;
                case "/":
                    result.Text = (_value / Double.Parse(result.Text)).ToString();
                    break;

            }
            //_value = Double.Parse(result.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            result.Text = "0";
        }

        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            if (result.Text != "0" && result.Text.Length != 0)
            {
                result.Text = result.Text.Remove(result.Text.Length - 1);
            }
            if (result.Text == "")
            {
                result.Text = "0";
            }

        }
    }
}
