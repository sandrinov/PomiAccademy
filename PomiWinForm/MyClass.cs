using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomiWinForm
{
    public class MyClass
    {
        Button _btn;
        public MyClass(Button btn)
        {       
            _btn = btn;
            EventHandler pointer = new EventHandler(_btn_Click);
            _btn.Click += pointer;
        }

        public void _btn_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Event handled by MyClass");
        }
    }
}
