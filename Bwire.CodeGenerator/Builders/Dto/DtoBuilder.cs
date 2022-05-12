using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Bwire.CodeGenerator
{
    public class DtoBuilder
    {
        private readonly Type _entityType;
        private readonly string _prefix;
        private readonly bool _isLowerCase;
        private StringBuilder builder;
        public DtoBuilder(Type entityType, string prefix = "", bool isLowerCase = false)
        {
            _entityType = entityType;
            _prefix = prefix;
            _isLowerCase = isLowerCase;
            builder = new StringBuilder();
        }
        public string Genetate()
        {
            var className = _entityType.Name;
            var namespac = _entityType.Namespace;

            builder.AppendLine("using System;");
            builder.AppendLine("using Abp.Application.Services.Dto;");
            builder.AppendLine("");

            //namespace
            builder.AppendLine($"namespace {namespac}.Dto");
            builder.AppendLine("{");

            //class
            GenerateClass();

            builder.AppendLine("}");

            return builder.ToString();
        }

        private void GenerateClass()
        {
            builder.AppendLine($"   public class {_prefix}{_entityType.Name}Dto : EntityDto<{GeneralSetting.DataTypeId}>");
            builder.AppendLine("    {");

            #region properties
            var properties = _entityType.GetProperties(BindingFlags.Public
                                                        | BindingFlags.Instance
                                                        | BindingFlags.DeclaredOnly);
            foreach (var propInfo in properties)
            {
                GenerateProperty(propInfo);
            }
            #endregion

            builder.AppendLine("    }");
        }

        private void GenerateProperty(PropertyInfo propInfo)
        {
            var propText = propInfo.GetText(_isLowerCase);
            if (!string.IsNullOrEmpty(propText))
            {
                builder.AppendLine($"        {propText}");
            }
        }
    }
}
