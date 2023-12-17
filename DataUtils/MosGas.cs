namespace DataUtils
{
    public class MosGas
    {
        private AdministrativeUnit _administrativeUnit = new AdministrativeUnit();
        private string _streetName = "Неизвестная улица";
        private int _areaId = 0;

        public string StreetName
        {
            init
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }
                _streetName = value;
            }
            get { return _streetName; }
        }
        public int AreaId
        {
            init
            {
                _areaId = value;
            }
            get
            {
                return _areaId;
            }
        }

        public MosGas(AdministrativeUnit administrativeUnit, string streetName, int areaId)
        {
            if (administrativeUnit is null)
            {
                throw new ArgumentException();
            }
            _administrativeUnit = administrativeUnit;
            StreetName = streetName;
            AreaId = areaId;
        }
        public MosGas() { }
    }
}
