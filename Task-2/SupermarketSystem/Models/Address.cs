namespace SupermarketSystem.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string TextAddress { get; private set; } = null!;
        public Guid CountryId { get; private set; }
        public Guid CityId { get; private set; }
        public Guid RegionId { get; private set; }

        private Address() { }
        private Address( string textAddress, Guid countryId, Guid cityId, Guid regionId)
        {
            TextAddress = textAddress;
            CountryId = countryId;
            CityId = cityId;
            RegionId = regionId;
        }

        public static Address Create(string textAddress, Guid countryId, Guid cityId, Guid regionId)
        {
            if(string.IsNullOrEmpty(textAddress)) { throw  new ArgumentNullException(); }
            return new Address( textAddress, countryId, cityId, regionId);
        }

        public void Update(string textAddress, Guid countryId, Guid cityId, Guid regionId)
        {
            if (string.IsNullOrEmpty(textAddress)) { throw new ArgumentNullException(); }
            TextAddress = textAddress;
            CountryId = countryId;
            CityId = cityId;
            RegionId = regionId;
        }
    }
}
