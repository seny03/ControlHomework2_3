namespace DataUtils
{
    public enum Side
    {
        Top = 0,
        Bottom = 1
    }
    public static class DataProcessing
    {
        public static MosGas[] GetRows(MosGas[] mosGas, Side side, int n)
        {
            if (n <= 1 || n > mosGas.Length)
            {
                throw new ArgumentException();
            }
            if (side == Side.Top)
            {
                return mosGas[..n];
            }
            else
            {
                return mosGas[(mosGas.Length - n)..];
            }
        }

        public static MosGas[] FilterRows(MosGas[] mosGas, string columnName, string value)
        {
            if (columnName == "streetname")
            {
                return mosGas.Where(mg => (mg.StreetName == value)).ToArray();
            }
            else if (columnName == "area")
            {
                return mosGas.Where(mg => (mg.AdministrativeUnit.Area == value)).ToArray();
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
