using System;
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
        public char answerBase = ' ';   //Holder for current base
        private double answer = 0.00;    //Holder for current answer
        private double gen = 0.00;       //Holder for 2nd double
        private string temp = "";       //Used for ra
        private string tempConvert = ""; //Used to convert from base to base
        private int counter = 0;
        private int hold = 0;

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


        //Convert from one base to another
        public void baseConvert(char from, char to)
        {
            if (from == 'd')
            {
                if (to == 'b')
                {
                    this.textDisplay.Text = Convert.ToString(Convert.ToInt32(this.textDisplay.Text, 10), 2);
                }
                if (to == 'o')
                {
                    this.textDisplay.Text = Convert.ToString(Convert.ToInt32(this.textDisplay.Text, 10), 8);
                }
                if (to == 'h')
                {
                    this.textDisplay.Text = Convert.ToString(Convert.ToInt32(this.textDisplay.Text, 10), 16);
                }
            }
            if (from == 'b')
            {
                if (to == 'd')
                {
                    this.textDisplay.Text = Convert.ToString(Convert.ToInt32(this.textDisplay.Text, 2), 10);
                }
                if (to == 'o')
                {
                    this.textDisplay.Text = Convert.ToString(Convert.ToInt32(this.textDisplay.Text, 2), 8);
                }
                if (to == 'h')
                {
                    this.textDisplay.Text = Convert.ToString(Convert.ToInt32(this.textDisplay.Text, 2), 16);
                }
            }
            if (from == 'o')
            {
                if (to == 'd')
                {
                    this.textDisplay.Text = Convert.ToString(Convert.ToInt32(this.textDisplay.Text, 8), 10);
                }
                if (to == 'b')
                {
                    this.textDisplay.Text = Convert.ToString(Convert.ToInt32(this.textDisplay.Text, 8), 2);
                }
                if (to == 'h')
                {
                    this.textDisplay.Text = Convert.ToString(Convert.ToInt32(this.textDisplay.Text, 8), 16);
                }
            }
            if (from == 'h')
            {
                if (to == 'd')
                {
                    this.textDisplay.Text = Convert.ToString(Convert.ToInt32(this.textDisplay.Text, 16), 10);
                }
                if (to == 'b')
                {
                    this.textDisplay.Text = Convert.ToString(Convert.ToInt32(this.textDisplay.Text, 16), 2);
                }
                if (to == 'o')
                {
                    this.textDisplay.Text = Convert.ToString(Convert.ToInt32(this.textDisplay.Text, 16), 8);
                }
            }
        }


        public FormProgramming()
        {
            InitializeComponent();

            answerBase = 'd';

            this.counter = 0;

            this.buttonDecimal.FlatStyle = System.Windows.Forms.FlatStyle.Standard;

            this.buttonBinary.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonOctal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonHex.FlatStyle = System.Windows.Forms.FlatStyle.Popup;

            this.buttonA.Enabled = false;
            this.buttonA.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonB.Enabled = false;
            this.buttonB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonC.Enabled = false;
            this.buttonC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonD.Enabled = false;
            this.buttonD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonE.Enabled = false;
            this.buttonE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonF.Enabled = false;
            this.buttonF.FlatStyle = System.Windows.Forms.FlatStyle.Popup;

            this.button2.Enabled = true;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.button3.Enabled = true;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.button4.Enabled = true;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.button5.Enabled = true;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.button6.Enabled = true;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.button7.Enabled = true;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.button8.Enabled = true;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.button9.Enabled = true;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Standard;

            this.buttonDot.Enabled = true;
            this.buttonDot.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
        }

        private void FormProgramming_Load(object sender, EventArgs e)
        {
            SetFeatureToAllControls(this.Controls);
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
        private void buttonA_Click(object sender, EventArgs e)
        {
            if (counter == 0)
                this.addButtonValue("a");
        }
        private void buttonB_Click(object sender, EventArgs e)
        {
            if (counter == 0)
                this.addButtonValue("b");
        }
        private void buttonC_Click(object sender, EventArgs e)
        {
            if (counter == 0)
                this.addButtonValue("c");
        }
        private void buttonD_Click(object sender, EventArgs e)
        {
            if (counter == 0)
                this.addButtonValue("d");
        }
        private void buttonE_Click(object sender, EventArgs e)
        {
            if (counter == 0)
                this.addButtonValue("e");
        }
        private void buttonF_Click(object sender, EventArgs e)
        {
            if (counter == 0)
                this.addButtonValue("f");
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

                    if (answerBase == 'd')
                    {
                        gen = Convert.ToDouble(this.textDisplay.Text);
                        this.temp = this.textDisplay.Text;
                        counter++;
                    }
                    if (answerBase == 'b')
                    {
                        this.baseConvert('d', 'b');
                        gen = Convert.ToInt32(this.textDisplay.Text,2);
                        this.baseConvert('b', 'd');
                        this.temp = this.textDisplay.Text;
                        counter++;
                    }
                    if (answerBase == 'o')
                    {
                        this.baseConvert('d', 'o');
                        gen = Convert.ToInt32(this.textDisplay.Text, 8);
                        this.baseConvert('o', 'd');
                        this.temp = this.textDisplay.Text;
                        counter++;
                    }
                    if (answerBase == 'h')
                    {
                        this.baseConvert('d', 'h');
                        gen = Convert.ToInt32(this.textDisplay.Text, 16);
                        this.baseConvert('h', 'd');
                        this.temp = this.textDisplay.Text;
                        counter++;
                    }
                }
                else
                {
                    if (answerBase == 'd')
                    {
                        gen = Convert.ToDouble(this.temp);
                    }
                    if (answerBase == 'b')
                    {
                        gen = Convert.ToInt32(this.temp, 2);
                    }
                    if (answerBase == 'o')
                    {
                        gen = Convert.ToInt32(this.temp, 8);
                    }
                    if (answerBase == 'h')
                    {
                        gen = Convert.ToInt32(this.temp, 16);
                    }
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



        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            this.baseConvert(this.answerBase, 'd');

            answerBase = 'd';

            this.counter = 0;


            this.buttonDecimal.FlatStyle = System.Windows.Forms.FlatStyle.Standard;

            this.buttonBinary.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonOctal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonHex.FlatStyle = System.Windows.Forms.FlatStyle.Popup;

            this.buttonA.Enabled = false;
            this.buttonA.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonB.Enabled = false;
            this.buttonB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonC.Enabled = false;
            this.buttonC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonD.Enabled = false;
            this.buttonD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonE.Enabled = false;
            this.buttonE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonF.Enabled = false;
            this.buttonF.FlatStyle = System.Windows.Forms.FlatStyle.Popup;

            this.button2.Enabled = true;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.button3.Enabled = true;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.button4.Enabled = true;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.button5.Enabled = true;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.button6.Enabled = true;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.button7.Enabled = true;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.button8.Enabled = true;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.button9.Enabled = true;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Standard;

            this.buttonDot.Enabled = true;
            this.buttonDot.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
        }
        private void buttonBinary_Click(object sender, EventArgs e)
        {
            this.baseConvert(this.answerBase, 'b');

            answerBase = 'b';

            this.counter = 0;

            this.buttonBinary.FlatStyle = System.Windows.Forms.FlatStyle.Standard;

            this.buttonDecimal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonOctal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonHex.FlatStyle = System.Windows.Forms.FlatStyle.Popup;

            this.buttonA.Enabled = false;
            this.buttonA.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonB.Enabled = false;
            this.buttonB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonC.Enabled = false;
            this.buttonC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonD.Enabled = false;
            this.buttonD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonE.Enabled = false;
            this.buttonE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonF.Enabled = false;
            this.buttonF.FlatStyle = System.Windows.Forms.FlatStyle.Popup;

            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Enabled = false;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Enabled = false;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.Enabled = false;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Enabled = false;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button8.Enabled = false;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button9.Enabled = false;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;

            this.buttonDot.Enabled = false;
            this.buttonDot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        }
        private void buttonOctal_Click(object sender, EventArgs e)
        {
            this.baseConvert(this.answerBase, 'o');

            answerBase = 'o';

            this.counter = 0;
            

            this.buttonOctal.FlatStyle = System.Windows.Forms.FlatStyle.Standard;

            this.buttonBinary.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDecimal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonHex.FlatStyle = System.Windows.Forms.FlatStyle.Popup;

            this.buttonA.Enabled = false;
            this.buttonA.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonB.Enabled = false;
            this.buttonB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonC.Enabled = false;
            this.buttonC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonD.Enabled = false;
            this.buttonD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonE.Enabled = false;
            this.buttonE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonF.Enabled = false;
            this.buttonF.FlatStyle = System.Windows.Forms.FlatStyle.Popup;

            this.button2.Enabled = true;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.button3.Enabled = true;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.button4.Enabled = true;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.button5.Enabled = true;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.button6.Enabled = true;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.button7.Enabled = true;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.button8.Enabled = false;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button9.Enabled = false;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;

            this.buttonDot.Enabled = false;
            this.buttonDot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        }
        private void buttonHex_Click(object sender, EventArgs e)
        {
            this.baseConvert(this.answerBase, 'h');

            answerBase = 'h';

            this.counter = 0;
            

            this.buttonHex.FlatStyle = System.Windows.Forms.FlatStyle.Standard;

            this.buttonBinary.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonOctal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDecimal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;

            this.buttonA.Enabled = true;
            this.buttonA.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.buttonB.Enabled = true;
            this.buttonB.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.buttonC.Enabled = true;
            this.buttonC.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.buttonD.Enabled = true;
            this.buttonD.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.buttonE.Enabled = true;
            this.buttonE.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.buttonF.Enabled = true;
            this.buttonF.FlatStyle = System.Windows.Forms.FlatStyle.Standard;

            this.button2.Enabled = true;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.button3.Enabled = true;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.button4.Enabled = true;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.button5.Enabled = true;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.button6.Enabled = true;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.button7.Enabled = true;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.button8.Enabled = true;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.button9.Enabled = true;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Standard;

            this.buttonDot.Enabled = false;
            this.buttonDot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        }

        /*=================================================================================================
        *                                    BUTTON ACITONS END
        =================================================================================================*/

        /*=================================================================================================
        *                                    KEY ACITONS START
        =================================================================================================*/

        private void SetFeatureToAllControls(Control.ControlCollection cc)
        {
            if (cc != null)
            {
                foreach (Control control in cc)
                {
                    control.PreviewKeyDown += new PreviewKeyDownEventHandler(control_PreviewKeyDown);
                    SetFeatureToAllControls(control.Controls);
                }
            }
        }

        void control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad0 && this.button0.Enabled == true) { this.addButtonValue("0"); }
            if (e.KeyCode == Keys.NumPad1 && this.button1.Enabled == true) { this.addButtonValue("1"); }
            if (e.KeyCode == Keys.NumPad2 && this.button2.Enabled == true) { this.addButtonValue("2"); }
            if (e.KeyCode == Keys.NumPad3 && this.button3.Enabled == true) { this.addButtonValue("3"); }
            if (e.KeyCode == Keys.NumPad4 && this.button4.Enabled == true) { this.addButtonValue("4"); }
            if (e.KeyCode == Keys.NumPad5 && this.button5.Enabled == true) { this.addButtonValue("5"); }
            if (e.KeyCode == Keys.NumPad6 && this.button6.Enabled == true) { this.addButtonValue("6"); }
            if (e.KeyCode == Keys.NumPad7 && this.button7.Enabled == true) { this.addButtonValue("7"); }
            if (e.KeyCode == Keys.NumPad8 && this.button8.Enabled == true) { this.addButtonValue("8"); }
            if (e.KeyCode == Keys.NumPad9 && this.button9.Enabled == true) { this.addButtonValue("9"); }

            if (e.KeyCode == Keys.A && this.button0.Enabled == true) { this.addButtonValue("a"); }
            if (e.KeyCode == Keys.B && this.button1.Enabled == true) { this.addButtonValue("b"); }
            if (e.KeyCode == Keys.C && this.button2.Enabled == true) { this.addButtonValue("c"); }
            if (e.KeyCode == Keys.D && this.button3.Enabled == true) { this.addButtonValue("d"); }
            if (e.KeyCode == Keys.E && this.button4.Enabled == true) { this.addButtonValue("e"); }
            if (e.KeyCode == Keys.F && this.button5.Enabled == true) { this.addButtonValue("f"); }

            if (e.KeyCode == Keys.Add)
            {
                this.operation = '+';

                this.setAnswer();

                this.textDisplay.Text = "+";

                this.counter = 0;
            }
            if (e.KeyCode == Keys.Subtract)
            {
                this.operation = '-';

                this.setAnswer();

                this.textDisplay.Text = "-";

                this.counter = 0;
            }
            if (e.KeyCode == Keys.Multiply)
            {
                this.operation = '*';

                this.setAnswer();

                this.textDisplay.Text = "*";

                this.counter = 0;
            }
            if (e.KeyCode == Keys.Divide)
            {
                this.operation = '/';

                this.setAnswer();

                this.textDisplay.Text = "/";

                this.counter = 0;
            }
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;
            }
        }
        /*=================================================================================================
        *                                    KEY ACITONS END
        =================================================================================================*/


    }
}
