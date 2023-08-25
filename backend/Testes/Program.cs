using Backend.Services;
class Program
{
    public static void Main(string[] args)
    {
        service service = new service();
        Console.WriteLine(service.ConsultasDiarias());
    }
}