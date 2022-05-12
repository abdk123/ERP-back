using Bwire.Authorization.Users;
using Bwire.CodeGenerator.Builders.Localization;
using System;
using System.Reflection.Emit;

namespace Bwire.CodeGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Files : ");
            var assembly = typeof(User).Assembly;
            ModulesBuilder.Generate(assembly, "Inventory");
            //LocalizationBuilder.Generate(assembly, "Inventory");
            //DbContextBuilder.Generate(assembly, "Inventory");
            //PermissionsBuilder.Generate(assembly, "Inventory");

            Console.WriteLine("Files : " + GeneralSetting.FileCount);
        }
    }
}
