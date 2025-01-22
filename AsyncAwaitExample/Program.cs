namespace AsyncAwaitExample
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Avvio applicazione...");
            // Chiamata asincrona
            await EseguiOperazioniAsincrone();
            Console.WriteLine("Applicazione terminata.");
        }
        // Metodo asincrono per eseguire più operazioni simultaneamente
        static async Task EseguiOperazioniAsincrone()
        {
            Task<string> operazione1 = SimulaDownloadAsync("https://sito1.com", 3000);
            Task<string> operazione2 = SimulaDownloadAsync("https://sito2.com", 2000);
            Task<string> operazione3 = SimulaDownloadAsync("https://sito3.com", 1000);


            String result = SimulaDownload("url");

            Console.WriteLine("Download avviati, in attesa del completamento...");

            Console.WriteLine("Faccio cose, vedo gente....");

            // Aspetta il completamento di tutte le operazioni
            string[] risultati = await Task.WhenAll(operazione1, operazione2, operazione3);

            foreach (var risultato in risultati)
            {
                Console.WriteLine(risultato);
            }
        }

        // Metodo asincrono che simula il download di dati da un server
        static async Task<string> SimulaDownloadAsync(string url, int delay)
        {
            Console.WriteLine($"Avvio download da {url}...");
            await Task.Delay(delay);  // Simula un'attesa per il download dei dati
            return $"Download completato da {url} in {delay} ms.";
        }

        static string SimulaDownload(string url)
        {
            Console.WriteLine($"Avvio download da {url}...");
            Thread.Sleep(10000);  // Simula un'attesa per il download dei dati
            return $"Download completato da {url}";
        }
    }
}
