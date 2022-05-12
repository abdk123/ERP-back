using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bwire.CodeGenerator
{
    internal class ImplementDomainServiceBuilder
    {
        private readonly Type _entityType;
        private StringBuilder builder;

        public ImplementDomainServiceBuilder(Type entityType)
        {
            _entityType = entityType;
            this.builder = new StringBuilder();
        }

        

        public string Genetate()
        {
            var entityName = _entityType.Name;
            var paramName = entityName.FirstCharToLowerCase();
            var idDataType = GeneralSetting.DataTypeId;
            var namespac = _entityType.Namespace;

            builder.AddDefaultNamespaces();
            builder.AppendLine("using Abp.Domain.Repositories;");
            builder.AppendLine("");

            //namespace
            builder.AppendLine($"namespace {namespac}.Services");
            builder.AppendLine("{");

            builder.AppendLine($"    public class {entityName}DomainService : I{entityName}DomainService");
            builder.AppendLine( "    {");

            builder.AppendLine($"        private readonly IRepository<{entityName}, {idDataType}> _{paramName}Repository;");
            builder.AppendLine($"        public {entityName}DomainService(IRepository<{entityName}, {idDataType}> {paramName}Repository)");
            builder.AppendLine( "        {");
            builder.AppendLine($"            _{paramName}Repository = {paramName}Repository;");
            builder.AppendLine( "        }");

            GenerateGetQueryable(builder, entityName, paramName);
            GenerateGetAllAsync(builder, entityName, paramName);
            GenerateGetByIdAsync(builder, entityName, paramName, idDataType);
            GenerateCreateAsync(builder, entityName, paramName);
            GenerateUpdateAsync(builder, entityName, paramName);
            GenerateDeleteAsync(builder, entityName, paramName);

            builder.AppendLine( "    }");
            builder.AppendLine("}");

            return builder.ToString();
        }

        private void GenerateDeleteAsync(StringBuilder builder, string entityName, string paramName)
        {
            builder.AppendLine($"        public async Task DeleteAsync({GeneralSetting.DataTypeId} id)");
            builder.AppendLine( "        {");
            builder.AppendLine($"            var {paramName} = await _{paramName}Repository.FirstOrDefaultAsync(id);");
            builder.AppendLine($"            await _{paramName}Repository.DeleteAsync({paramName});");
            builder.AppendLine( "        }");
        }

        private void GenerateUpdateAsync(StringBuilder builder, string entityName, string paramName)
        {
            builder.AppendLine($"        public async Task<{entityName}> UpdateAsync({entityName} {paramName})");
            builder.AppendLine( "        {");
            builder.AppendLine($"            return await _{paramName}Repository.InsertOrUpdateAsync({paramName});");
            builder.AppendLine( "        }");
        }

        private void GenerateCreateAsync(StringBuilder builder, string entityName, string paramName)
        {
            builder.AppendLine($"        public async Task<{entityName}> CreateAsync({entityName} {paramName})");
            builder.AppendLine( "        {");
            builder.AppendLine($"            return await _{paramName}Repository.InsertAsync({paramName});");
            builder.AppendLine( "        }");
        }

        private void GenerateGetByIdAsync(StringBuilder builder, string entityName, string paramName, string idDataType)
        {
            builder.AppendLine($"        public async Task<{entityName}> GetByIdAsync({idDataType} id)");
            builder.AppendLine( "        {");
            builder.AppendLine($"            return await _{paramName}Repository.FirstOrDefaultAsync(id);");
            builder.AppendLine( "        }");
        }

        private void GenerateGetQueryable(StringBuilder builder, string entityName, string paramName)
        {
            builder.AppendLine($"        public IQueryable<{entityName}> Get()");
            builder.AppendLine( "        {");
            builder.AppendLine($"            return _{paramName}Repository.GetAll();");
            builder.AppendLine( "        }");
        }

        private void GenerateGetAllAsync(StringBuilder builder,string entityName,string paramName)
        {
            builder.AppendLine($"        public async Task<IList<{entityName}>> GetAllAsync()");
            builder.AppendLine( "        {");
            builder.AppendLine($"            return await _{paramName}Repository.GetAllListAsync();");
            builder.AppendLine( "        }");

        }
    }
}
