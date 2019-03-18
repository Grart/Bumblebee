using System;
using BeetleX.FastHttpApi;
namespace Bumblebee.BaseSample
{
    class Program
    {
        private static Gateway g;
        static void Main(string[] args)
        {
            g = new Gateway();
            g.HttpOptions(h =>
            {
                h.Port = 8080;//设置监听商品，默认8080
                h.LogToConsole = true;
               
            });
          
             g.AddServer("http://localhost:5000/").AddUrl("*", 10);
            //g.AddServer("http://192.168.2.26:9090").AddUrl("*", 0);
            //g.AddServer("http://192.168.2.27:9090").AddUrl("/order.*", 0);
            //g.AddServer("http://192.168.2.28:9090").AddUrl("/order.*", 0);
            g.Open();
            Console.Read();
        }

     
    }
}
