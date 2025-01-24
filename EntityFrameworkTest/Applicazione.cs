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
        public Applicazione()
        {
              
        }
        public void Esegui() 
        { 
            IDataSource ds = new FakeDataSource();
            List<Asset_DTO> asset_DTOs = ds.GetAllAssets();
            foreach (var asset_dto in asset_DTOs)
            {
                Console.WriteLine(asset_dto);
            }           
        }
    }
}
