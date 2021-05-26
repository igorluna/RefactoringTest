using System;

namespace LegacyApp.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            ProveAddUser(args);
        }

        public static void ProveAddUser(string[] args)
        {
            var userService = new UserService();
            
            var addResult = userService.AddUser(
                "Igor",
                "Luna",
                "igor.luna@email.com",
                new DateTime(1985, 09, 21),
                1);

            Console.WriteLine("Adicionando Igor Luna " + (addResult ? "com sucesso!" : "com erros!"));
        }
    }
}
