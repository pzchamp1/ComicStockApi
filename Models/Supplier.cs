namespace ComicStock.Models
{
    public class Supplier
    {
        private int id;
        private string name;
        private string reference;
        private string city;
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Reference { get => reference; set => reference = value; }
        public string City { get => city; set => city = value; }
    }
}