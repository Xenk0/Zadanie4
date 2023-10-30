using Zadanie4Order;

namespace Zadanie4
{
    public class Prod
    {
        public string name { get; set; }
        public int count { get; set; }

    }
    public class OrderProduct
    {
        
        public OrderProduct() 
        {
            Products = new List<Prod>();
        }
        public int Id { get; set; }
        public List<Prod> Products { get; set; }

      
    }
}
