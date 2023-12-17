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
                return;
            }

            foreach (var mg in DataProcessing.FilterRows(mosGas, "streetname", "Выставочный переулок"))
            {
                Console.WriteLine(mg.AreaId + " ; " + mg.StreetName + " ; " + mg.AdministrativeUnit.District + " ; " + mg.AdministrativeUnit.Area);
            }
        }
    }
}