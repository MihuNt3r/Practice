namespace PracticeV9
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu menu = Startup.ConfigureServices();
            menu.Run();
        }
    }
}
