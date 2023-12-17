using DataUtils;

namespace UserUtils
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MosGas[]? mosGas = IOUtils.ReadLines();
            if (mosGas is null)
            {
            }
            MosGas[] cur = DataProcessing.GetRows(mosGas, Side.Bottom, 10);
            foreach (MosGas mg in cur)
            {
                if (mg is null)
                {
                    Console.WriteLine("null");
                }
                else
                {
                    Console.WriteLine(mg.AreaId + " ; " + mg.StreetName);
                }
            }
        }
    }
}