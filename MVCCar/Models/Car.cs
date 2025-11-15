namespace MVCCar.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }
        public int ProductionYear { get; set; }

        public decimal Price { get; set; }

        public string? Manufacturer { get; set; }


    }
}
