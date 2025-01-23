
using EntityFrameworkTest.EF;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var employee = new { FirstName = "Mario", BirthDate = DateTime.Now.AddYears(-20) };
            //TestSelect();
            //TestInsert();
            //OldTest();
            LinqSamples();
        }

        private static async void LinqSamples()
        {
            AvioAssetChainDBContext _context = new AvioAssetChainDBContext();
            #region example 1
            var assetsWithDocuments = await _context.Assets
                                            .Include(a => a.AssetDocuments)
                                            .ToListAsync();

            foreach (var asset in assetsWithDocuments)
            {
                Console.WriteLine($"Asset: {asset.AssetName}");
                foreach (var document in asset.AssetDocuments)
                {
                    Console.WriteLine($" - Documento: {document.AssetDocumentName}");
                }
            }
            #endregion

            #region example 2
            var filteredAssets = await _context.Assets
                    .Include(a => a.AssetDocuments)
                    .Where(a => a.AssetDocuments.Any(d => d.AssetDocumentType.ToUpper() == "PDF"))
                    .ToListAsync();

            foreach (var asset in filteredAssets)
            {
                Console.WriteLine($"Asset con documenti PDF: {asset.AssetName}");
            }
            #endregion

        }

        private static void OldTest()
        {
            AvioAssetChainDBContext ctx = new AvioAssetChainDBContext();

            #region first implementation
            //List<Asset> listOfAsset = ctx.Assets.ToList();

            //foreach (var item in listOfAsset)
            //{
            //    var query_document = from qd in ctx.AssetDocuments
            //                                where qd.AssetContainer == item.IdAsset
            //                                select qd;

            //    int numOfDocuments = query_document.ToList().Count();

            //    Console.WriteLine("Asset: "+ item.AssetName + " \t\t num of documents: " + numOfDocuments);
            //}
            #endregion

            var assets = ctx.Assets.Include("AssetDocuments").ToList();

            //var asset2 = ctx.Assets.ToList();

            foreach (Asset asset in assets)
            {
                Console.WriteLine("Asset: " + asset.AssetName + " \t\t num of documents: " + asset.AssetDocuments.Count);
            }
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
