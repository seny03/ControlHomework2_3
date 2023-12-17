namespace DataUtils
{
    public class MosGas : IComparable<MosGas>
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

        public AdministrativeUnit AdministrativeUnit
        {
            init
            {
                if (value is null)
                {
                    throw new ArgumentException();
                }
                _administrativeUnit = value;
            }
            get { return _administrativeUnit; }
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

        public int CompareTo(MosGas? other)
        {
            if (other is null)
            {
                throw new ArgumentException();
            }
            return AdministrativeUnit.District.CompareTo(other.AdministrativeUnit.District);
        }
    }
}
