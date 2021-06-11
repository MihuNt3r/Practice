using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccessLayer;

namespace PracticeV9
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
