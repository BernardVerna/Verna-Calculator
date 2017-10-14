﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VernaCalculator
{
    public partial class FormProgramming : Form
    {

        public char operation = ' ';    //Holder for current user operation
        private double answer = 0.00;    //Holder for current answer
        private double gen = 0.00;       //Holder for 2nd double
        private string temp = "";       //Used for ra
        private int counter = 0;

        //Convert text string to double
        public void setAnswer()
        {
            if (this.textDisplay.Text != "*" && this.textDisplay.Text != "/" && this.textDisplay.Text != "+"
                && this.textDisplay.Text != "-" && this.textDisplay.Text != "^"
                && this.textDisplay.Text != "sqrt")
            {
                this.answer = Convert.ToDouble(this.textDisplay.Text);
                Console.WriteLine("answer: " + Convert.ToString(answer));
            }
        }
        public double getAnswer() { return answer; }


        //Convert text string to double
        public void setGen()
        {
            if (this.textDisplay.Text != "*" && this.textDisplay.Text != "/" && this.textDisplay.Text != "+"
                && this.textDisplay.Text != "-" && this.textDisplay.Text != "^"
                && this.textDisplay.Text != "sqrt")
            {
                this.gen = Convert.ToDouble(this.textDisplay.Text);
                Console.WriteLine("gen: " + Convert.ToString(gen));
            }
        }
        public double getGen() { return answer; }


        //This function indexes the selected number to the back of the entire string number
        public void addButtonValue(string x)
        {
            if (this.textDisplay.Text == "0" || this.textDisplay.Text == "*" || this.textDisplay.Text == "/"
                || this.textDisplay.Text == "+" || this.textDisplay.Text == "-" || this.textDisplay.Text == "^"
                || this.textDisplay.Text == "sqrt")
            {
                this.textDisplay.Text = x;
            }
            else
            {
                this.textDisplay.Text += x;
            }
        }


        public FormProgramming()
        {
            InitializeComponent();
        }

        private void FormProgramming_Load(object sender, EventArgs e)
        {

        }


        /*=================================================================================================
         *                                    BUTTON ACITONS START
         ================================================================================================*/
        
            
        //When button 0 is clicked 
        private void button0_Click(object sender, EventArgs e)
        {
            if (counter == 0)
                this.addButtonValue(this.button0.Text);
        }
        //When button 1 is clicked
        private void button1_Click(object sender, EventArgs e)
        {
            if (counter == 0)
                this.addButtonValue(this.button1.Text);
        }
        //When button 2 is clicked
        private void button2_Click(object sender, EventArgs e)
        {
            if (counter == 0)
                this.addButtonValue(this.button2.Text);
        }
        //When button 3 is clicked
        private void button3_Click(object sender, EventArgs e)
        {
            if (counter == 0)
                this.addButtonValue(this.button3.Text);
        }
        //When button 4 is clicked
        private void button4_Click(object sender, EventArgs e)
        {
            if (counter == 0)
                this.addButtonValue(this.button4.Text);
        }
        //When button 5 is clicked
        private void button5_Click(object sender, EventArgs e)
        {
            if (counter == 0)
                this.addButtonValue(this.button5.Text);
        }
        //When button 6 is clicked
        private void button6_Click(object sender, EventArgs e)
        {
            if (counter == 0)
                this.addButtonValue(this.button6.Text);
        }
        //When button 7 is clicked
        private void button7_Click(object sender, EventArgs e)
        {
            if (counter == 0)
                this.addButtonValue(this.button7.Text);
        }
        //When button 8 is clicked
        private void button8_Click(object sender, EventArgs e)
        {
            if (counter == 0)
                this.addButtonValue(this.button8.Text);
        }
        //When button 9 is clicked
        private void button9_Click(object sender, EventArgs e)
        {
            if (counter == 0)
                this.addButtonValue(this.button9.Text);
        }
        //When button + is clicked
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            this.operation = '+';

            this.setAnswer();

            this.textDisplay.Text = "+";

            this.counter = 0;

        }
        //When button - is clicked
        private void buttonMinus_Click(object sender, EventArgs e)
        {
            this.operation = '-';

            this.setAnswer();

            this.textDisplay.Text = "-";

            this.counter = 0;
        }
        //When button * is clicked
        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            this.operation = '*';

            this.setAnswer();

            this.textDisplay.Text = "*";

            this.counter = 0;
        }
        //When button / is clicked
        private void buttonDivide_Click(object sender, EventArgs e)
        {
            this.operation = '/';

            this.setAnswer();

            this.textDisplay.Text = "/";

            this.counter = 0;
        }
        //When button ^ is clicked
        private void buttonPowerOf_Click(object sender, EventArgs e)
        {
            this.operation = '^';

            this.setAnswer();

            this.textDisplay.Text = "^";

            this.counter = 0;
        }
        //When button sqrt is clicked
        private void buttonSquareRoot_Click(object sender, EventArgs e)
        {
            this.operation = 's';

            this.setAnswer();

            this.textDisplay.Text = "sqrt";

            this.counter = 0;
        }
        //When button sqrt is clicked;
        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.operation = ' ';
            this.answer = 0.00;

            this.textDisplay.Text = "0";

            this.counter = 0;
        }

        //When the user is ready to recieve their current answer
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (this.textDisplay.Text != "*" && this.textDisplay.Text != "/" && this.textDisplay.Text != "+"
                && this.textDisplay.Text != "-" && this.textDisplay.Text != "^"
                && this.textDisplay.Text != "sqrt")
            {
                if (counter == 0)
                {
                    gen = Convert.ToDouble(this.textDisplay.Text);
                    this.temp = this.textDisplay.Text;
                    counter++;
                }
                else
                {
                    gen = Convert.ToDouble(temp);
                }


                switch (operation)
                {
                    case '+':
                        answer += gen;
                        break;
                    case '-':
                        answer -= gen;
                        break;
                    case '*':
                        answer *= gen;
                        break;
                    case '/':
                        answer /= gen;
                        break;
                    case '^':
                        answer = Math.Pow(answer, gen);
                        break;
                    case 's':
                        answer = Math.Pow(answer, (1 / gen));
                        break;
                }
                this.textDisplay.Text = Convert.ToString(this.answer);

            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void windowToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStandard_Click(object sender, EventArgs e)
        {
            FormMain f = new FormMain();

            f.Location = this.Location;

            this.Hide();

            f.ShowDialog();

            this.Close();
        }

        /*=================================================================================================
        *                                    BUTTON ACITONS END
        =================================================================================================*/
    }
}