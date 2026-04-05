using ExpressionEvaluator.Core;

namespace ExpressionEvaluator.UI.Win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Numbers
        private void btn0_Click(object sender, EventArgs e) => txtDisplay.Text += "0";
        private void btn1_Click(object sender, EventArgs e) => txtDisplay.Text += "1";
        private void btn2_Click(object sender, EventArgs e) => txtDisplay.Text += "2";
        private void btn3_Click(object sender, EventArgs e) => txtDisplay.Text += "3";
        private void btn4_Click(object sender, EventArgs e) => txtDisplay.Text += "4";
        private void btn5_Click(object sender, EventArgs e) => txtDisplay.Text += "5";
        private void btn6_Click(object sender, EventArgs e) => txtDisplay.Text += "6";
        private void btn7_Click(object sender, EventArgs e) => txtDisplay.Text += "7";
        private void btn8_Click(object sender, EventArgs e) => txtDisplay.Text += "8";
        private void btn9_Click(object sender, EventArgs e) => txtDisplay.Text += "9";

        // Operators
        private void btnPlus_Click(object sender, EventArgs e) => txtDisplay.Text += "+";
        private void btnMinus_Click(object sender, EventArgs e) => txtDisplay.Text += "-";
        private void btnMultiply_Click(object sender, EventArgs e) => txtDisplay.Text += "*";
        private void btnDivide_Click(object sender, EventArgs e) => txtDisplay.Text += "/";
        private void btnPow_Click(object sender, EventArgs e) => txtDisplay.Text += "^";
        private void btnOpenParenthesis_Click(object sender, EventArgs e) => txtDisplay.Text += "(";
        private void btnCloseParenthesis_Click(object sender, EventArgs e) => txtDisplay.Text += ")";

        // Decimal point
        private void btnDot_Click(object sender, EventArgs e)
        {
            string text = txtDisplay.Text;
            string[] parts = text.Split('+', '-', '*', '/', '^');
            string lastNumber = parts[parts.Length - 1];

            if (!lastNumber.Contains("."))
            {
                txtDisplay.Text += ".";
            }
        }

        // Clear all
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "";
        }

        // Delete last character
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
            }
        }

        // Evaluate expression
        private void btnResult_Click(object sender, EventArgs e)
        {
            try
            {
                double result = Evaluator.Evaluate(txtDisplay.Text);
                txtDisplay.Text = $"{txtDisplay.Text} = {result}";
            }
            catch (Exception)
            {
                txtDisplay.Text = "Error";
            }
        }
    }
}