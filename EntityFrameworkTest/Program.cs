
using EntityFrameworkTest.EF;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            var employee = new { FirstName = "Mario", BirthDate = DateTime.Now.AddYears(-20) };
            //TestSelect();
            //TestInsert();
            //OldTest();
            await LinqSamples();
        }

        private static async Task LinqSamples()
        {
            AvioAssetChainDBContext _context = new AvioAssetChainDBContext();
            #region example 1
            var assetsWithDocuments = await _context.Assets
                                            .Include(a => a.AssetDocuments)
                                            .ToListAsync();

            foreach (var asset_ef in assetsWithDocuments)
            {
                Console.WriteLine($"Asset: {asset_ef.AssetName}");
                foreach (var document in asset_ef.AssetDocuments)
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

            foreach (var asset_ef in filteredAssets)
            {
                Console.WriteLine($"Asset con documenti PDF: {asset_ef.AssetName}");
            }
            #endregion
            #region example 3
            //3. Selezione con proiezione su DTO (Data Transfer Object)

            var assetDtos = await _context.Assets
                            //.Include(a => a.AssetDocuments)
                            .Select(a => new
                            {
                                a.AssetName,
                                a.AssetType,
                                Documents = a.AssetDocuments.Select(d => new
                                {
                                    d.AssetDocumentName,
                                    d.AssetDocumentType
                                }).ToList()
                            })
                            .ToListAsync();

            foreach (var asset_dto in assetDtos)
            {
                Console.WriteLine($"Asset: {asset_dto.AssetName}, Tipo: {asset_dto.AssetType}");
                foreach (var doc_dto in asset_dto.Documents)
                {
                    Console.WriteLine($" - {doc_dto.AssetDocumentName} ({doc_dto.AssetDocumentType})");
                }
            }

            #endregion


            #region example 4
            //4. Ricerca di un Asset specifico con i documenti collegati (Lazy Loading)

            var asset = await _context.Assets.FindAsync(55);
            _context.Entry(asset).Collection(a => a.AssetDocuments).Load();

            Console.WriteLine($"Asset: {asset.AssetName}");
            foreach (var doc in asset.AssetDocuments)
            {
                Console.WriteLine($" - {doc.AssetDocumentName}");
            }

            #endregion

            #region example 5
            var groupedData = await _context.Assets
                .GroupBy(a => a.AssetType)
                .Select(g => new
                {
                    AssetType = g.Key,
                    DocumentCount = g.Sum(a => a.AssetDocuments.Count)
                })
                .ToListAsync();

            foreach (var group in groupedData)
            {
                Console.WriteLine($"Tipo di Asset: {group.AssetType}, Numero di Documenti: {group.DocumentCount}");
            }

            #endregion

            #region delete sample
            var assetToDelete = await _context.Assets
                .Include(a => a.AssetDocuments)
                .FirstOrDefaultAsync(a => a.IdAsset == 54);

            if (assetToDelete != null)
            {
                _context.Assets.Remove(assetToDelete);
                await _context.SaveChangesAsync();
                Console.WriteLine("Asset e documenti associati eliminati.");
            }
            #endregion

            #region paging result
            int pageSize = 5;
            int pageNumber = 1;

            var paginatedAssets = await _context.Assets
                .OrderBy(a => a.AssetName)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            foreach (var asset_ef in paginatedAssets)
            {
                Console.WriteLine($"Asset: {asset.AssetName}");
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
