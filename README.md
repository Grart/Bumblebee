# Bumblebee
.net core fast http gateway components 

# sample
```
    class Program
    {
        private static Gateway g;
        static void Main(string[] args)
        {
            g = new Gateway();
            g.HttpOptions(h => h.LogToConsole = true);
            g.AddServer("http://192.168.2.25:9090").AddUrl("*", 3);
            g.AddServer("http://192.168.2.26:9090").AddUrl("*", 10);
            g.Open();
            Console.Read();
        }
    }
```
open gateway default 8080 port

add server http://192.168.2.25:9090 weight 3

add server http://192.168.2.26:9090 weight 10

## requesting 
```
g.Requesting += (o, e) =>
{
      if (e.Request.Url.IndexOf("order") >= 0)
      {
             NotFoundResult result = new NotFoundResult("order url notfound!");
             e.Response.Result(result);
             e.Cancel = true;
       }
};
```
## requested
```
g.Requested += (o, e) => {
       //e.Code http status code
       //e.Request
       //e.Response;
};
```
## response error
custom response error
```
g.ResponseError += (o, e) => {
      e.Result = new NotFoundResult("test");
};
```
