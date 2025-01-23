
using EntityFrameworkTest.EF;

namespace EntityFrameworkTest
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var employee = new { FirstName = "Mario", BirthDate = DateTime.Now.AddYears(-20) };
            //TestSelect();
            //TestInsert();
            OldTest();
        }

        private static void OldTest()
        {
            
        }

        private static void TestInsert()
        {
            AvioAssetChainDBContext ctx = new AvioAssetChainDBContext();

            Asset newAsset = new Asset();
            newAsset.AssetName = "Pomi accademy asset Test";
            newAsset.AssetType = "Test Type";
            newAsset.AssetIdentifier = Guid.NewGuid().ToString();
            newAsset.AssetLongDescription = "Long Desc";
            newAsset.AssetShortDescription = "Short Desc";

            ctx.Assets.Add(newAsset);
            ctx.SaveChanges();

            Console.WriteLine( newAsset.IdAsset);



        }

        private static void TestSelect()
        {
            AvioAssetChainDBContext ctx = new AvioAssetChainDBContext();

            IQueryable query_result = from a in ctx.Assets
                         where a.AssetName == "NewName"
                         select a;
            foreach (Asset asset in query_result)
            {
                asset.AssetName = "NewName";
            }
            ctx.SaveChanges();



            List<AssetDocument> assetDSocuments = ctx.AssetDocuments.ToList(); 




        }
    }
}
