using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bwire.CodeGenerator
{
    internal class PermissionsBuilder
    {
        public static void Generate(Assembly assembly, string moduleName)
        {
            Console.WriteLine($"Module : {moduleName}");
            var entities = assembly.GetTypes()
                .Where(t => t.Namespace.Contains($"{GeneralSetting.ProjectName}.{moduleName}")
                && t.BaseType != null
                && (t.BaseType.Name.Contains("BwireEntity") || t.BaseType.Name.Contains("IndexEntity"))
                && t.Name != "IndexEntity"
                && t.IsClass == true).ToList();

            if (entities.Any())
            {
                var list = GetUndefinedEntities(entities);
                var text = GeneratePermissions(list);
            }
        }

        private static List<PermissionViewModel> GetUndefinedEntities(List<Type> entities)
        {
            var list = new List<PermissionViewModel>();
            using (var reader = new StreamReader(GeneralSetting.PermissionsFilePath))
            {
                var text = reader.ReadToEnd();
                foreach (var entity in entities)
                {
                    
                    var page = $"Page_{entity.Name}";
                    var create = $"Action_{entity.Name}_Create";
                    var update = $"Action_{entity.Name}_Update";
                    var delete = $"Action_{entity.Name}_Delete";

                    var permissionViewModel = new PermissionViewModel()
                    {
                        Entity = entity.Name,
                        Page = !text.Contains(page) ? false : true,
                        Create = !text.Contains(create) ? false : true,
                        Update = !text.Contains(update) ? false : true,
                        Delete = !text.Contains(delete) ? false : true
                    };
                    list.Add(permissionViewModel);
                }
            }
            return list;
        }

        private static Tuple<string,string> GeneratePermissions(List<PermissionViewModel> list)
        {
            var permissionBuilder = new StringBuilder();
            var providerBuilder = new StringBuilder();
            foreach (var item in list)
            {
                permissionBuilder.AppendLine("");
                permissionBuilder.AppendLine("//"+item.Entity);

                providerBuilder.AppendLine("");
                providerBuilder.AppendLine("//" + item.Entity);

                if (!item.Page)
                {
                    var pageStr = $"Page_{item.Entity}";
                    permissionBuilder.AppendLine($"public const string {pageStr} = \"Page.{item.Entity}\";");
                    providerBuilder.AppendLine($"context.CreatePermission(PermissionNames.{pageStr}, L(\"{item.Entity}\"));");
                }

                if(!item.Create)
                {
                    var pageStr = $"Action_{item.Entity}_Create";
                    permissionBuilder.AppendLine($"public const string {pageStr} = \"Action.{item.Entity}.Create\";");
                    providerBuilder.AppendLine($"context.CreatePermission(PermissionNames.{pageStr}, L(\"Create{item.Entity}\"));");
                }

                if (!item.Update)
                {
                    var pageStr = $"Action_{item.Entity}_Update";
                    permissionBuilder.AppendLine($"public const string {pageStr} = \"Action.{item.Entity}.Update\";");
                    providerBuilder.AppendLine($"context.CreatePermission(PermissionNames.{pageStr}, L(\"Update{item.Entity}\"));");
                }

                if (!item.Delete)
                {
                    var pageStr = $"Action_{item.Entity}_Delete";
                    permissionBuilder.AppendLine($"public const string {pageStr} = \"Action.{item.Entity}.Delete\";");
                    providerBuilder.AppendLine($"context.CreatePermission(PermissionNames.{pageStr}, L(\"Delete{item.Entity}\"));");
                }
            }
            return Tuple.Create(permissionBuilder.ToString(), providerBuilder.ToString());
        }
    }

    internal class PermissionViewModel
    {
        public string Entity { get; set; }
        public bool Page { get; set; }
        public bool Create { get; set; }
        public bool Delete { get; set; }
        public bool Update { get; set; }
    }
}
