using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bwire.CodeGenerator
{
    internal class InterfaceDomainServiceBuilder
    {
        private readonly Type _entityType;
        private StringBuilder builder;

        public InterfaceDomainServiceBuilder(Type entityType)
        {
            _entityType = entityType;
            this.builder = new StringBuilder();
        }

        public string Genetate()
        {
            var entityName = _entityType.Name;
            var namespac = _entityType.Namespace;

            builder.AddDefaultNamespaces();
            builder.AppendLine("using Abp.Domain.Services;");
            builder.AppendLine("");

            //namespace
            builder.AppendLine($"namespace {namespac}.Services");
            builder.AppendLine("{");

            builder.AppendLine($"    public interface I{entityName}DomainService : IDomainService");
            builder.AppendLine("     {");

            builder.AppendLine($"        IQueryable<{entityName}> Get();");
            builder.AppendLine($"        Task<IList<{entityName}>> GetAllAsync();");
            builder.AppendLine($"        Task<{entityName}> GetByIdAsync({GeneralSetting.DataTypeId} id);");
            builder.AppendLine($"        Task<{entityName}> CreateAsync({entityName} {entityName.FirstCharToLowerCase()});");
            builder.AppendLine($"        Task<{entityName}> UpdateAsync({entityName} {entityName.FirstCharToLowerCase()});");
            builder.AppendLine($"        Task DeleteAsync({GeneralSetting.DataTypeId} id);");

            builder.AppendLine("    }");
            builder.AppendLine("}");

            return builder.ToString();
        }
    }
}
