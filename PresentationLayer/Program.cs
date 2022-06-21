using BusinessLayer;
using BusinessLayer.Models;
using DataAccessLayer;
using System;

namespace PresentationLayer
{
    class Program
    {
        private static IUserService _userService;
        private static IUserRepository _userRepository;

        static void Main(string[] args)
        {
            RegisterAllDependencies();
            int choise;
            do
            {
                Console.WriteLine(
                    $"1 - Add{Environment.NewLine}" +
                    $"2 - Remove{Environment.NewLine}" +
                    $"3 - Update{Environment.NewLine}" +
                    $"4 - Show all{Environment.NewLine}" +
                    $"5 - Show by id{Environment.NewLine}" +
                    $"0 - Exit");
                choise = Convert.ToInt32(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        Add();
                        break;
                    case 2:
                        Remove();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        ShowAll();
                        break;
                    case 5:
                        ShowById();
                        break;
                }

                Console.Clear();
            } while (choise != 0);
        }

        private static void RegisterAllDependencies()
        {
            _userRepository = new UserRepositoryMsSql();
            _userService = new UserService(_userRepository);
        }

        private static void ShowById()
        {
            Console.Write("Enter id:");
            int id = Convert.ToInt32(Console.ReadLine());
            var user = _userRepository.GetById(id);
            if(user != null)
            {
                Console.WriteLine(user);
            }
            else
            {
                Console.WriteLine("User not found!");
            }

            Console.ReadKey();
        }

        private static void ShowAll()
        {
            foreach(var user in _userService.GetAllUsers())
            {
                Console.WriteLine(user);
            }

            Console.ReadKey();
        }

        private static void Update()
        {
            throw new NotImplementedException();
        }

        private static void Remove()
        {
            throw new NotImplementedException();
        }

        private static void Add()
        {
            UserToRegister userToRegister = new UserToRegister();

            Console.Write("Enter first name:");
            userToRegister.FirstName = Console.ReadLine();

            Console.Write("Enter last name:");
            userToRegister.LastName = Console.ReadLine();

            Console.Write("Enter phone :");
            userToRegister.Phone = Console.ReadLine();

            _userService.RegisterUser(userToRegister);

            Console.Write("User registered!");
            Console.ReadKey();
        }
    }
}
