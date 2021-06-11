using System;
//using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Exceptions;
using BusinessEntities;
using PracticeV9.RegularExpressions;

namespace PracticeV9
{
    public class MainMenu
    {
        private IFootballService _service;
        public MainMenu(IFootballService service)
        {
            _service = service;
        }

        public void Run()
        {
            int a = 0;
            while (a != 5)
            {
                Console.WriteLine("Available commands:\n1.Players Menu\n2.Teams Menu\n3.Matches Menu\n4.Stadiums Menu\n5.Exit");
                Console.WriteLine("Enter number of command: ");
                int cmd = 0;
                try
                {
                    cmd = Int32.Parse(Console.ReadLine());
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
                switch (cmd)
                {
                    case (1):
                        PlayersMenu();
                        break;
                    case (2):
                        TeamsMenu();
                        break;
                    case (3):
                        MatchesMenu();
                        break;
                    case (4):
                        StadiumsMenu();
                        break;
                    case (5):
                        a = 5;
                        break;
                    default:
                        Console.WriteLine("Error. Try again");
                        break;
                }
            }
        }

        #region EntitiesMenus
        public void PlayersMenu()
        {
            int a = 0;

            while (a != 6)
            {
                Console.WriteLine("Available commands:\n1.Add Player\n2.Remove Player\n3.Change Player's info\n4.View Player's full info\n5.View all Players\n6.Exit");
                Console.WriteLine("Enter number of command: ");
                int cmd = 0;
                try
                {
                    cmd = Int32.Parse(Console.ReadLine());
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
                switch (cmd)
                {
                    case (1):
                        try
                        {
                            AddFootballer();
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.Message);
                        }
                        break;
                    case (2):
                        Console.WriteLine("Enter id of a player");
                        try
                        {
                            int id = Int32.Parse(Console.ReadLine());
                            _service.DeleteFootballer(id);
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.Message);
                        }
                        Console.WriteLine("Player was successfully deleted");
                        break;
                    case (3):
                        try
                        {
                            ChangePlayerInfo();
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.Message);
                        }
                        break;
                    case (4):
                        Console.WriteLine("Enter id of a player");
                        try
                        {
                            int id = Int32.Parse(Console.ReadLine());
                            Footballer Player = _service.GetFootballerById(id);
                            Console.WriteLine(Player.GetFullInfo());
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.Message);
                        }
                        break;
                    case (5):
                        var players = _service.GetAllFootballersFromDb();

                        Console.WriteLine(String.Format("|{0,-9}|{1,-10}|{2,-11}|{3,-10}|{4,-15}|", "ID", "First Name", "Last Name", "Position", "Team"));
                        foreach (var player in players)
                        {
                            Console.WriteLine(player);
                        }
                        break;
                    case (6):
                        a = 6;
                        break;
                    default:
                        Console.WriteLine("Error. Try again");
                        break;
                }
            }

        }

        public void TeamsMenu()
        {
            int a = 0;
            while (a != 6)
            {
                Console.WriteLine("Available commands:\n1.Add Team\n2.Add Player to Team\n3.Remove Player from Team\n4.View all Teams\n5.View Team info\n6.Exit");
                Console.WriteLine("Enter number of command: ");
                int cmd = 0;
                try
                {
                    cmd = Int32.Parse(Console.ReadLine());
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
                switch (cmd)
                {
                    case (1):
                        try
                        {
                            AddTeam();
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.Message);
                        }
                        break;
                    case (2):
                        try
                        {
                            var teams = _service.GetAllTeamsFromDb();

                            var players = _service.GetAllFootballersFromDb();

                            Console.WriteLine("TEAMS");
                            foreach (var t in teams)
                            {
                                Console.WriteLine(t);
                            }
                            Console.WriteLine("PLAYERS");
                            foreach (var p in players)
                            {
                                Console.WriteLine(p);
                            }
                            AddPlayerToTeam();
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.Message);
                        }
                        break;
                    case (3):
                        Console.WriteLine("PLAYERS");
                        var Players = _service.GetAllFootballersFromDb();
                        foreach (var p in Players)
                        {
                            Console.WriteLine(p);
                        }

                        Console.WriteLine("Enter Player's id");
                        try
                        {
                            int id = Int32.Parse(Console.ReadLine());
                            _service.RemovePlayerFromTeam(id);
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.Message);
                        }
                        break;
                    case (4):
                        var Teams = _service.GetAllTeamsFromDb();

                        Console.WriteLine(String.Format("|{0,-9}|{1,-10}|{2,-11}|{3,-10}|", "ID", "Name", "City", "Country"));
                        Teams.ForEach(t => Console.WriteLine(t));
                        break;
                    case (5):
                        Console.WriteLine("Enter id of a team");
                        try
                        {
                            int id = Int32.Parse(Console.ReadLine());
                            Team team = _service.GetTeamById(id);
                            Console.WriteLine(team.GetFullInfo());
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.Message);
                        }
                        break;
                    case (6):
                        a = 6;
                        break;
                    default:
                        Console.WriteLine("Error. Try again");
                        break;
                }
            }
        }

        public void MatchesMenu()
        {
            int a = 0;
            while (a != 7)
            {
                Console.WriteLine("Available commands:\n1.Add Match\n2.Delete Match\n3.Change Match Info\n4.View all Matches\n5.View Match Info\n6.Sort Matches\n7.Exit");
                Console.WriteLine("Enter number of command: ");
                int cmd = 0;
                try
                {
                    cmd = Int32.Parse(Console.ReadLine());
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
                switch (cmd)
                {
                    case (1):
                        try
                        {
                            AddMatch();
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.Message);
                        }
                        break;
                    case (2):
                        Console.WriteLine("Enter match id");
                        try
                        {
                            int id = Int32.Parse(Console.ReadLine());
                            _service.DeleteMatch(id);
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.Message);
                        }
                        break;
                    case (3):
                        try
                        {
                            ChangeMatchInfo();
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.Message);
                        }
                        break;
                    case (4):
                        Console.WriteLine("Matches:");
                        var matches = _service.GetAllMatchesFromDb();

                        matches.ForEach(m => Console.WriteLine(m));
                        break;
                    case (5):
                        Console.WriteLine("Enter match id");
                        try
                        {
                            int id = Int32.Parse(Console.ReadLine());
                            var match = _service.GetMatchById(id);
                            Console.WriteLine(match.GetFullInfo());
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.Message);
                        }
                        break;
                    case (6):
                        break;
                    case (7):
                        a = 7;
                        break;
                    default:
                        Console.WriteLine("Error. Try again");
                        break;
                }
            }
        }

        public void StadiumsMenu()
        {
            int a = 0;
            while (a != 6)
            {
                Console.WriteLine("Available commands:\n1.Add Stadium\n2.Delete Stadium\n3.Change Stadium Info\n4.View all Stadiums\n5.View Stadium info\n6.Exit");
                Console.WriteLine("Enter number of command: ");
                int cmd = 0;
                try
                {
                    cmd = Int32.Parse(Console.ReadLine());
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
                switch (cmd)
                {
                    case (1):
                        try
                        {
                            AddStadium();
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.Message);
                        }
                        break;
                    case (2):
                        Console.WriteLine("Enter id of a stadium");
                        try
                        {
                            int id = Int32.Parse(Console.ReadLine());
                            _service.DeleteStadium(id);
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.Message);
                        }
                        Console.WriteLine("Stadium was successfully deleted");
                        break;
                    case (3):
                        try
                        {
                            ChangeStadiumInfo();
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.Message);
                        }
                        break;
                    case (4):
                        var stadiums = _service.GetAllStadiumsFromDb();

                        Console.WriteLine(String.Format("|{0,-9}|{1,-20}|{2,-11}|{3,-10}|", "ID", "Name", "City", "MaxCapacity"));
                        stadiums.ForEach(s => Console.WriteLine(s));
                        break;
                    case (5):
                        Console.WriteLine("Enter id of a stadium");
                        try
                        {
                            int id = Int32.Parse(Console.ReadLine());
                            Stadium stadium = _service.GetStadiumById(id);
                            Console.WriteLine(stadium.GetFullInfo());
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.Message);
                        }
                        break;
                    case (6):
                        a = 6;
                        break;
                    default:
                        Console.WriteLine("Error. Try again");
                        break;
                }
            }
        }
        #endregion


        #region AddEntity

        public void AddFootballer()
        {
            Console.WriteLine("Enter First Name");
            string FirstName = Console.ReadLine();

            if (!RegexValidations.NameValidator.IsMatch(FirstName))
                throw new InvalidInputException("Incorrect First Name");

            Console.WriteLine("Enter Last Name");
            string LastName = Console.ReadLine();

            if (!RegexValidations.NameValidator.IsMatch(LastName))
                throw new InvalidInputException("Incorrect Last Name");

            Console.WriteLine("Enter Player's Birth Date\nFormat: DD-MM-YYYY");
            string birthDate = Console.ReadLine();

            DateTime BirthDate = DateTime.Parse(birthDate);

            Console.WriteLine("Choose Player's Position:\n0 - Goalkeeper\n1 - Defender\n2 - Midfielder\n3 - Attacker");

            Position PlayersPosition = Position.Goalkeeper;
            bool isInputCorrect = false;

            do
            {
                Console.WriteLine("Enter number of position:");
                int position = Int32.Parse(Console.ReadLine());
                switch (position)
                {
                    case (0):
                        PlayersPosition = Position.Goalkeeper;
                        isInputCorrect = true;
                        break;
                    case (1):
                        PlayersPosition = Position.Defender;
                        isInputCorrect = true;
                        break;
                    case (2):
                        PlayersPosition = Position.Midfielder;
                        isInputCorrect = true;
                        break;
                    case (3):
                        PlayersPosition = Position.Attacker;
                        isInputCorrect = true;
                        break;
                }
            } while (!isInputCorrect);

            Console.WriteLine("Choose Player's Health Status\n0 - Injured\n1 - Healthy");
            Console.WriteLine("Enter number of Health Status");

            HealthStatus Status = HealthStatus.Healthy;
            isInputCorrect = false;

            do
            {
                int status = Int32.Parse(Console.ReadLine());
                switch (status)
                {
                    case (0):
                        Status = HealthStatus.Injured;
                        isInputCorrect = true;
                        break;
                    case (1):
                        Status = HealthStatus.Healthy;
                        isInputCorrect = true;
                        break;
                }
            } while (!isInputCorrect);

            Console.WriteLine("Enter Player's Salary:");

            decimal Salary = decimal.Parse(Console.ReadLine());

            Footballer Player = new Footballer()
            {
                FirstName = FirstName,
                LastName = LastName,
                BirthDate = BirthDate,
                Position = PlayersPosition,
                HealthStatus = Status,
                Salary = Salary
            };

            _service.AddFootballer(Player);
        }

        public void AddTeam()
        {
            Console.WriteLine("Enter Team's Name");
            string Name = Console.ReadLine();

            if (!RegexValidations.NameValidator.IsMatch(Name))
                throw new InvalidInputException("Incorrect Name of Team");

            Console.WriteLine("Enter Team's City");
            string City = Console.ReadLine();

            if (!RegexValidations.CityValidator.IsMatch(City))
                throw new InvalidInputException("Incorrect City");

            Console.WriteLine("Enter Team's Country");
            string Country = Console.ReadLine();

            if (!RegexValidations.CityValidator.IsMatch(Country))
                throw new InvalidInputException("Incorrect Country");

            Team team = new Team()
            {
                Name = Name,
                City = City,
                Country = Country
            };

            _service.AddTeam(team);
        }

        public void AddStadium()
        {
            Console.WriteLine("Enter Stadium Name");
            string name = Console.ReadLine();

            if (!RegexValidations.NameValidator.IsMatch(name))
                throw new InvalidInputException("Incorrect Stadium Name");

            Console.WriteLine("Enter City");
            string city = Console.ReadLine();

            if (!RegexValidations.CityValidator.IsMatch(city))
                throw new InvalidInputException("Incorrect City");

            Console.WriteLine("Enter Maximal Capacity of a Stadium");
            int capacity = Int32.Parse(Console.ReadLine());

            if (capacity < 0 || capacity > 100000)
                throw new InvalidInputException("Incorrect Capacity");

            Stadium stadium = new Stadium()
            {
                Name = name,
                City = city,
                MaxCapacity = capacity
            };

            _service.AddStadium(stadium);
        }

        public void AddMatch()
        {
            var teams = _service.GetAllTeamsFromDb();
            var stadiums = _service.GetAllStadiumsFromDb();

            Console.WriteLine("Enter Home Team name");
            string homeTeamName = Console.ReadLine();

            var homeTeam = teams.Find(t => t.Name == homeTeamName);

            if (homeTeam == null)
                throw new ArgumentException("Can't find team with such name");

            Console.WriteLine("Enter Guest Team name");
            string guestTeamName = Console.ReadLine();

            var guestTeam = teams.Find(t => t.Name == guestTeamName);

            if (guestTeam == null)
                throw new ArgumentException("Can't find team with such name");

            Console.WriteLine("Enter Stadium name");
            string stadiumName = Console.ReadLine();

            var stadium = stadiums.Find(s => s.Name == stadiumName);

            if (stadium == null)
                throw new ArgumentException("Can't find stadium with such name");

            Console.WriteLine("Enter date of a match");
            Console.WriteLine("Format: DD-MM-YYYY");
            DateTime date = DateTime.Parse(Console.ReadLine());

            _service.AddMatch(homeTeam.Id, guestTeam.Id, stadium.Id, date);
        }

        #endregion

        public void ChangePlayerInfo()
        {
            Console.WriteLine("Players: ");
            var players = _service.GetAllFootballersFromDb();
            players.ForEach(p => Console.WriteLine(p));

            Console.WriteLine("Enter id of a player");

            int id = Int32.Parse(Console.ReadLine());
            var player = _service.GetFootballerById(id);

            Console.WriteLine("1.Change First Name\n2.Change Last Name\n3.Change Birth Date\n4.Change Position\n5.Change Health Status\n6.Change Salary");
            Console.WriteLine("Enter number of command:");
            int cmd = Int32.Parse(Console.ReadLine());

            switch (cmd)
            {
                case (1):
                    ChangeFirstName(player.Id);
                    break;
                case (2):
                    ChangeLastName(player.Id);
                    break;
                case (3):
                    ChangeBirthDate(player.Id);
                    break;
                case (4):
                    ChangePosition(player.Id);
                    break;
                case (5):
                    ChangeHealthStatus(player.Id);
                    break;
                case (6):
                    ChangeSalary(player.Id);
                    break;
                default:
                    Console.WriteLine("Error. Try again");
                    break;
            }
        }

        public void ChangeMatchInfo()
        {
            var matches = _service.GetAllMatchesFromDb();
            if (matches.Count > 0)
            {
                Console.WriteLine("Matches");
                matches.ForEach(m => Console.WriteLine(m));

                Console.WriteLine("Enter match id");
                try
                {
                    int id = Int32.Parse(Console.ReadLine());
                    var match = _service.GetMatchById(id);

                    Console.WriteLine("1.Change date\n2.Change stadium\n3.Change spectators count\n4.Enter match result");
                    Console.WriteLine("Enter number of command: ");

                    int cmd = Int32.Parse(Console.ReadLine());

                    switch (cmd)
                    {
                        case (1):
                            ChangeMatchDate(id);
                            break;
                        case (2):
                            ChangeMatchStadium(id);
                            break;
                        case (3):
                            //ChangeSpectatorsCount()
                            break;
                        case (4):
                            EnterMatchResult(id);
                            break;
                        default:
                            Console.WriteLine("Error. Try again");
                            break;
                    }
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
            else
            {
                Console.WriteLine("No matches to change");
            }
        }

        public void ChangeStadiumInfo()
        {
            var stadiums = _service.GetAllStadiumsFromDb();

            if (stadiums.Count > 0)
            {
                Console.WriteLine("Stadiums");
                stadiums.ForEach(s => Console.WriteLine(s));

                Console.WriteLine("Enter stadium id: ");
                int id = Int32.Parse(Console.ReadLine());

                var stadium = _service.GetStadiumById(id);

                Console.WriteLine("1.Change capacity\n2.Change sit price");
                Console.WriteLine("Enter number of command: ");

                int cmd = Int32.Parse(Console.ReadLine());

                switch (cmd)
                {
                    case (1):
                        ChangeStadiumCapacity(id);
                        break;
                    case (2):
                        break;
                }

            }
            else
            {
                Console.WriteLine("No stadiums to change");
            }
        }

        #region ChangeEntity

        public void ChangeFirstName(int id)
        {
            Console.WriteLine("Enter new First Name");
            string firstName = Console.ReadLine();

            if (!RegexValidations.NameValidator.IsMatch(firstName))
                throw new InvalidInputException("Incorrect First name");

            _service.ChangeFirstName(id, firstName);
            Console.WriteLine("Name successfully changed");
        }

        public void ChangeLastName(int id)
        {
            Console.WriteLine("Enter new Last Name");
            string firstName = Console.ReadLine();

            if (!RegexValidations.NameValidator.IsMatch(firstName))
                throw new InvalidInputException("Incorrect Last name");

            _service.ChangeFirstName(id, firstName);
            Console.WriteLine("Name successfully changed");
        }

        public void ChangeBirthDate(int id)
        {
            Console.WriteLine("Enter new Birth Date");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            _service.ChangeBirthDate(id, birthDate);
        }
        public void ChangePosition(int id)
        {
            Console.WriteLine("Choose Player's Position:\n0 - Goalkeeper\n1 - Defender\n2 - Midfielder\n3 - Attacker");

            Position PlayersPosition = Position.Goalkeeper;
            bool isInputCorrect = false;

            do
            {
                Console.WriteLine("Enter number of position:");
                int position = Int32.Parse(Console.ReadLine());
                switch (position)
                {
                    case (0):
                        PlayersPosition = Position.Goalkeeper;
                        isInputCorrect = true;
                        break;
                    case (1):
                        PlayersPosition = Position.Defender;
                        isInputCorrect = true;
                        break;
                    case (2):
                        PlayersPosition = Position.Midfielder;
                        isInputCorrect = true;
                        break;
                    case (3):
                        PlayersPosition = Position.Attacker;
                        isInputCorrect = true;
                        break;
                }
            } while (!isInputCorrect);

            _service.ChangePosition(id, PlayersPosition);
        }

        public void ChangeHealthStatus(int id)
        {
            Console.WriteLine("Choose Player's Health Status\n0 - Injured\n1 - Healthy");
            Console.WriteLine("Enter number of Health Status");

            HealthStatus Status = HealthStatus.Healthy;
            bool isInputCorrect = false;

            do
            {
                int status = Int32.Parse(Console.ReadLine());
                switch (status)
                {
                    case (0):
                        Status = HealthStatus.Injured;
                        isInputCorrect = true;
                        break;
                    case (1):
                        Status = HealthStatus.Healthy;
                        isInputCorrect = true;
                        break;
                }
            } while (!isInputCorrect);

            _service.ChangeHealthStatus(id, Status);
        }

        public void ChangeSalary(int id)
        {
            Console.WriteLine("Enter Player's Salary:");

            decimal Salary = decimal.Parse(Console.ReadLine());

            _service.ChangeSalary(id, Salary);
        }

        public void ChangeMatchDate(int id)
        {
            Console.WriteLine("Enter new match date");

            DateTime date = DateTime.Parse(Console.ReadLine());

            _service.ChangeMatchDate(id, date);
        }

        public void ChangeMatchStadium(int id)
        {
            Console.WriteLine("Enter new stadium name");

            string stadiumName = Console.ReadLine();

            var stadiums = _service.GetAllStadiumsFromDb();

            var stadium = stadiums.Find(s => s.Name == stadiumName);

            if (stadium == null)
                throw new ArgumentException("Can't find stadium with such name");

            _service.ChangeStadium(id, stadium.Id);
        }

        //public void ChangeMatchSpectatorsCount(int id)
        //{

        //}

        public void EnterMatchResult(int id)
        {
            Console.WriteLine("Enter Home Team Goals:");
            int homeTeamGoals = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter Guest Team Goals");
            int guestTeamGoals = Int32.Parse(Console.ReadLine());

            _service.EnterMatchResult(id, homeTeamGoals, guestTeamGoals);
        }

        public void ChangeStadiumCapacity(int id)
        {
            Console.WriteLine("Enter new capacity");
            int capacity = Int32.Parse(Console.ReadLine());

            if (capacity < 0 || capacity > 100000)
                throw new InvalidInputException("Incorrect Capacity");

            _service.ChangeCapacity(id, capacity);
        }

        public void AddPlayerToTeam()
        {
            Console.WriteLine("Enter Player's First name");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter Player's Last name");
            string lastName = Console.ReadLine();

            var players = _service.GetAllFootballersFromDb();

            var player = players.Find(p => p.FirstName == firstName && p.LastName == lastName);

            if (player == null)
                throw new ArgumentException("Can't find player with such name and surname");

            Console.WriteLine("Enter Team Name");
            string teamName = Console.ReadLine();

            Console.WriteLine("Enter Team City");
            string city = Console.ReadLine();

            var teams = _service.GetAllTeamsFromDb();

            var team = teams.Find(t => t.Name == teamName && t.City == city);

            if (team == null)
                throw new ArgumentException("Can't find team with such name and city");

            _service.AddPlayerToTeam(player.Id, team.Id);
        }

        #endregion
    }
}
