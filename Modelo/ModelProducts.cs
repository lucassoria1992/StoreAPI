namespace StoreAPI.Modelo
{
    public class ModelProducts
    {
        public int id { get; set; }
        public string? description { get; set; }
        public string? image { get; set; }
        public string? category { get; set; }
        public Boolean star { get; set; }

        public decimal price { get; set; }
    }
}
