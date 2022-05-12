using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Bwire.CodeGenerator
{
    internal static class StringExtension
    {
        public static string? FirstCharToLowerCase(this string? str)
        {
            if (!string.IsNullOrEmpty(str) && char.IsUpper(str[0]))
                return str.Length == 1 ? char.ToLower(str[0]).ToString() : char.ToLower(str[0]) + str[1..];

            return str;
        }

        public static string GetRealText(this string value)
        {
            return Regex.Replace(value, @"(?<a>[a-z])(?<b>[A-Z0-9])", @"${a} ${b}");
        }

        public static string GetProjectName(this string namespac)
        {
            return namespac.Split('.')[0];
        }

        public static string GetModuleName(this string namespac)
        {
            return namespac.Split('.')[1];
        }
        public static string GetAggregateName(this string namespac)
        {
            var array = namespac.Split('.');
            return array[array.Length - 1];
        }

        public static string ApplicationEntityPath(this string namespac)
        {
            namespac = namespac.Replace($"{GeneralSetting.ProjectName}.","");
            var list = namespac.Split('.').ToList();
            if (list.Any())
            {
                var path = GeneralSetting.ProjectAppPath;
                foreach (var item in list)
                {
                    path = Path.Combine(path, item);
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                }

                return path;
            }
            return GeneralSetting.ProjectAppPath;
        }

        public static string DomainEntityPath(this string namespac)
        {
            namespac = namespac.Replace($"{GeneralSetting.ProjectName}.", "");
            var list = namespac.Split('.').ToList();
            if (list.Any())
            {
                var path = GeneralSetting.ProjectDomainPath;
                foreach (var item in list)
                {
                    path = Path.Combine(path, item);
                }

                return path;
            }
            return GeneralSetting.ProjectAppPath;
        }
        
    }
}
