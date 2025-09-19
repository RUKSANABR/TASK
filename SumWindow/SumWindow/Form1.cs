namespace SumWindow
{
    public partial class Form1 : Form //inherit form1 from form
    {
        public Form1() // constructor
        {
            InitializeComponent();  //setup button,text etc
        }

        private void button1_Click(object sender, EventArgs e) //evnt hndlr for button click
        {
            // Try to parse first number
            if (!double.TryParse(textBox1.Text.Trim(), out double num1))
            {
                MessageBox.Show("Please enter a valid number in Number 1", "Invalid Input",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            // Try to parse second number
            if (!double.TryParse(textBox2.Text.Trim(), out double num2))
            {
                MessageBox.Show("Please enter a valid number in Number 2", "Invalid Input",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            // Calculate sum
            double sum = num1 + num2;

            // Show result
            label4.Text = $"Sum: {sum}";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}