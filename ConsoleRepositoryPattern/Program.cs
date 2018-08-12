using CRP.Common;
using CRP.Domain.Infrastructure;
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
            IUnitOfWork unitOfWork = kernel.Get<UnitOfWork>();
            var userService = kernel.Get<UserService>();
            userService.Add(new User { CreatedBy = "Pratik", CreatedOn = DateTime.Now.AddDays(1), Email = "pratikd12havale1@gmail.com", FullName = "Pratik213 Dhavale", UserType = UserType.Employee });
            unitOfWork.CommitChanges();
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
