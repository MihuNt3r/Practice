using PracticeBL.Interfaces;
using PracticeBL.Services;
using DAL;

namespace ConsoleApp51
{
    public class Startup
    {
        public static MainMenu ConfigureServices()
        {
            FootballDataStore store = new FootballDataStore();
            IFootballService _service = new FootballService(store);
            MainMenu menu = new MainMenu(_service);
            return menu;
        }
    }
}
