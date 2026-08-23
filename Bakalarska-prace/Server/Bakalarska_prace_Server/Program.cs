namespace Bakalarska_prace_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSignalR();

            var app = builder.Build();

            Console.WriteLine("Server startuje podle konfigurace...");
            app.Run(); // Automaticky si naète port z Kestrel konfigurace nebo appsettings
        }
    }
}