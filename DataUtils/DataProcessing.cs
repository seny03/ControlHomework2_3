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
            if (side == Side.Top)
            {
                return mosGas[..n];
            }
            else
            {
                return mosGas[(mosGas.Length - n)..];
            }
        }
    }
}
