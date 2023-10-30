using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Leaf.xNet;
using Zadanie4;

namespace Zadanie4Order
{
 
    public class PostOrder
    {
         static List<Prod> orders { get; set; }

        static string  GetResp(List<Prod> _orders)
        {
            string tempLink = "https://localhost:7208/api/Products/ListProducts";
            OrderProduct orderProduct = new OrderProduct();
            orderProduct.Products.AddRange(_orders);

            using (HttpRequest req = new HttpRequest())
            {

                var strJs = JsonSerializer.Serialize(orderProduct);
                var response = req.Post(tempLink, strJs, "application/json");
                return response.ToString();
            }
           
        }
        static void GetOrder()
        {
            while (true) 
            { 
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Enter name product");
                Console.ResetColor();

                string _name = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Enter count product");
                Console.ResetColor();
                int _count;
                while(!int.TryParse(Console.ReadLine(), out _count))
                {
                
                    Console.WriteLine("Hmm, not numbers");
                }
                orders.Add(new Prod { name = _name , count = _count});
                Console.WriteLine("More?\n1)yes\n2)no");

                if(Console.ReadLine() == "2")
                {
                    break;
                }
            }
        }
        public static void StartMessage()
        {
            Console.WriteLine("Hello, u check product?\n1)yes\n2)no");
            switch(Console.ReadLine())
            {
                case "1":
                    orders = new List<Prod>();
                    GetOrder();
                    break;
                case "2":
                    Console.WriteLine("Good luck!");
                    break;
            }

            Console.WriteLine(GetResp(orders));
        }
    }
}
