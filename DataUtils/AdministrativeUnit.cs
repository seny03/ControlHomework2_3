namespace DataUtils
{
    public class AdministrativeUnit
    {
        private string _district = "Неизвестный округ";
        private string _area = "Неизвестный район";

        public string District
        {
            init
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }
                _district = value;
            }
            get { return _district; }
        }
        public string Area
        {
            init
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }
                _area = value;
            }
            get { return _area; }
        }
        public AdministrativeUnit(string district, string area)
        {
            District = district;
            Area = area;
        }
        public AdministrativeUnit() { }
    }
}