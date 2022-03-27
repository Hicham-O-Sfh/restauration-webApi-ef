namespace restauration_api.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public string Cuisine { get; set; }
        public float Note { get; set; }
    }
}
