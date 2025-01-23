namespace LambdaSample
{
    internal class Program
    {
        public delegate bool FilterPointer(int i);

        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            FilterPointer fp1 = new FilterPointer(FilterEvenInt);
            //FilterList(list, fp1);
            FilterList(list, i => (i & 1) == 1);
        }
       
        public static void FilterList(List<int> listToFilter, FilterPointer fp)
        {
            foreach (int i in listToFilter)
            {
                if (fp(i))
                    Console.WriteLine(i);
            }
        }
        static bool FilterEvenInt(int i) 
        {
            return i % 2 == 0;
        }
        static bool FilterOddInt(int i)
        {
            return i % 2 == 1;
        }
    }
}
