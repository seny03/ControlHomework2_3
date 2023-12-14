using DataUtils;

namespace UserUtils
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var T = new AdministrativeUnit("1", "2");
            Console.WriteLine(T.Area + " " + T.District);
        }
    }
}