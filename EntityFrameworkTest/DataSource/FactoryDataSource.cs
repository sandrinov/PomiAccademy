using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTest.DataSource
{
    public class FactoryDataSource
    {
        private static IDataSource _dataSource;

        public static IDataSource GetInstance()
        {
            if (_dataSource == null)
            {
                // apply instance policy
                //_dataSource = new EF_DataSource();
                _dataSource = new FakeDataSource();
            }
            return _dataSource;
        }
    }
}
