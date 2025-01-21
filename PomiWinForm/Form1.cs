namespace PomiWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MyClass mc = new MyClass(this.button1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "Hello Windows Forms!";
        }
    }
}
