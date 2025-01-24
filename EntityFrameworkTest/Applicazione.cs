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
        private const int pagesize = 10;

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
            //
            int currentPage = 1;
            bool continuePaging = true;
            while (continuePaging)
            {
                List<Asset_DTO> assets = _datasource.GetPagedAssets(currentPage, pagesize);
                if(assets.Count == 0)
                    continuePaging = false;
                else
                {
                    foreach (Asset_DTO asset in assets)
                    {
                        Console.WriteLine(asset);
                    }
                    Console.WriteLine( "Pagina numero: " + currentPage);
                    var key = Console.ReadLine();
                    if (key == "q")
                        continuePaging = false;
                    else
                        currentPage++;
                }               
            }
        }
    }
}
