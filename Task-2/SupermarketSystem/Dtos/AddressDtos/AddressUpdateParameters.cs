﻿namespace SupermarketSystem.Dtos.AddressDtos
{
    public class AddressUpdateParameters
    {
        public Guid Id { get; set; }
        public string TextAddress { get; set; }
        public Guid CountryId { get; set; }
        public Guid CityId { get; set; }
        public Guid RegionId { get; set; }
    }
}
