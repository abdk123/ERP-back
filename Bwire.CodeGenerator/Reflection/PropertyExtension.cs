using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bwire.CodeGenerator
{
    public static  class PropertyExtension
    {
        public static string GetText(this PropertyInfo propertyInfo,bool isLowerCase)
        {
            var propType = string.Empty;
            if(propertyInfo.PropertyType == typeof(String))
            {
                propType = "string";
            }
            else if(propertyInfo.PropertyType == typeof(Boolean))
            {
                propType = "bool";
            }
            else if (propertyInfo.PropertyType == typeof(Boolean?))
            {
                propType = "bool?";
            }
            else if (propertyInfo.PropertyType == typeof(DateTime))
            {
                propType = "DateTime?";
            }
            else if (propertyInfo.PropertyType == typeof(DateTime?))
            {
                propType = "DateTime?";
            }
            else if (propertyInfo.PropertyType == typeof(Guid))
            {
                propType = "Guid";
            }
            else if (propertyInfo.PropertyType == typeof(Guid?))
            {
                propType = "Guid?";
            }
            else if (propertyInfo.PropertyType == typeof(Int32))
            {
                propType = "int";
            }
            else if (propertyInfo.PropertyType == typeof(Int32?))
            {
                propType = "int?";
            }
            else if( propertyInfo.PropertyType == typeof(Double))
            {
                propType = "double";
            }
            else if (propertyInfo.PropertyType == typeof(Double))
            {
                propType = "double?";
            }
            else if (propertyInfo.PropertyType.IsEnum)
            {
                propType = "int";
            }
            else if(propertyInfo.PropertyType == typeof(Decimal))
            {
                propType = "decimal";
            }
            else if (propertyInfo.PropertyType == typeof(Decimal?))
            {
                propType = "decimal?";
            }
            else if (propertyInfo.PropertyType == typeof(Single))
            {
                propType = "float";
            }
            else if (propertyInfo.PropertyType == typeof(Single?))
            {
                propType = "float?";
            }

            if (string.IsNullOrEmpty(propType))
                return propType;

            var name = propertyInfo.Name;
            if (isLowerCase)
                name = name.FirstCharToLowerCase();

            return $"public {propType} {name} " + "{ get; set; }";
        }
    }
}
