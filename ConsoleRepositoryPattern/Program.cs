using CRP.Common;
using CRP.Domain.Models;
using CRP.Storage.Services;
using Ninject;
using System;

namespace ConsoleRepositoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new CRPNinjectModule());

            var userService = kernel.Get<UserService>();
            userService.Add(new User { CreatedBy = "Admin", CreatedOn = DateTime.Now, Email = "pratikdhavale@gmail.com", FullName = "Pratik Dhavale", UserType = UserType.Client });
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
