using System;
using System.Linq;
using System.Reflection;

namespace Bwire.CodeGenerator
{
    internal class ModulesBuilder
    {

        public static void Generate(Assembly assembly, string moduleName)
        {
            Console.WriteLine($"Module : {moduleName}");

            var entities = assembly.GetTypes()
                .Where(t => t.Namespace.Contains($"{GeneralSetting.ProjectName}.{moduleName}")
                && t.BaseType != null
                &&  (t.BaseType.Name.Contains("BwireEntity") || t.BaseType.Name.Contains("IndexEntity"))
                && t.Name != "IndexEntity"
                && t.IsClass == true).ToList();

            if (entities.Any())
            {
                foreach (var entity in entities)
                {
                    ApplicationBuilder.Genetate(entity);
                    DomainBuilder.Genetate(entity);
                }
            }

            //var entity = typeof(Unit);
            //DomainBuilder.Genetate(entity);
            //ApplicationBuilder.Genetate(entity);
        }
    }
}
