namespace Taxi.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Contact { get; set; }
        public string Mail { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public User()
        {
           Orders = new List<Order>();
        }
       
    }
}
 
