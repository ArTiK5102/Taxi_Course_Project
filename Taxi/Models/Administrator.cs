namespace Taxi.Models
{
    public class Administrator
    {
        [Key]
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Messages { get; set; }

    }
}
