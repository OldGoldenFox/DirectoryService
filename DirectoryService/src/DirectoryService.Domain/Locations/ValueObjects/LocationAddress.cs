namespace DirectoryService.Domain.Locations.ValueObjects
{
    public record LocationAddress
    {
        public string Country { get; }
        
        public string City { get; }
        
        public string Street { get; }
        
        public string HouseNumber { get; }
        
        private LocationAddress(string country, string city, string street, string houseNumber)
        {
            Country = country;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
        }

        public static LocationAddress Create(string country, string city, string street, string houseNumber)
        {
            country = country.Trim();
            city = city.Trim();
            street = street.Trim();
            houseNumber = houseNumber.Trim();
            
            ValidateField(country, "Country", 3, 100);
            ValidateField(country, "City", 1, 100);
            ValidateField(street, "Street", 1, 100);
            
            if (string.IsNullOrWhiteSpace(houseNumber))
            {
                throw new ArgumentException("HouseNumber cannot be null or whitespace.");
            }
            
            return new LocationAddress(country, city, street, houseNumber);
        }
        
        private static void ValidateField(string value, string fieldName, int min, int max)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"{fieldName} cannot be empty.");
            
            if (value.Length < min || value.Length > max)
                throw new ArgumentException($"{fieldName} must be between {min} and {max} characters.");
        }
    }
}