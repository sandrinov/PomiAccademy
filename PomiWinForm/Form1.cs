using System.Runtime.CompilerServices;

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

        private async void button2_Click(object sender, EventArgs e)
        {
            //Task<String> t_payload = AccessWebASync();

            //// do........
            //string payload = await t_payload;

            string payload = await AccessWebASync();

            textBox2.Text = "";
            textBox2.Text = payload;
        }

        private async Task<string> AccessWebASync()
        {
            HttpClient client = new HttpClient();
            Task<string> ts = client.GetStringAsync("https://www.google.com");

            DoIndipendentWork();

            string content = await ts;

            return content;
        }

        private void DoIndipendentWork()
        {
            textBox2.Text = "I'm working indipendently";
        }
    }
}
