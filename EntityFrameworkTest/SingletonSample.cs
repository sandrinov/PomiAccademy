using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTest
{
    public class SingletonSample
    {
        private static SingletonSample _instance;
        private SingletonSample()
        {
            _instance = new SingletonSample();
        }
        public static SingletonSample GetInstance()
        {
            if (_instance != null)
                return _instance;
            else
                return new SingletonSample();
        }
    }
}
