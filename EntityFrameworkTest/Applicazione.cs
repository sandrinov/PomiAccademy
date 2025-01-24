using EntityFrameworkTest.DataSource;
using EntityFrameworkTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTest
{
    public class Applicazione
    {
        private IDataSource _datasource;
        public Applicazione(IDataSource datasource)
        {
            _datasource = datasource;
            //_datasource = FactoryDataSource.GetInstance();
        }
        public void Esegui() 
        { 
            //IDataSource ds = new FakeDataSource();
            //List<Asset_DTO> asset_DTOs = _datasource.GetAllAssets();
            //foreach (var asset_dto in asset_DTOs)
            //{
            //    Console.WriteLine(asset_dto);
            //}           
        }
    }
}
