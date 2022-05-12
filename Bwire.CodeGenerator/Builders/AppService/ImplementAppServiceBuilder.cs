using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bwire.CodeGenerator
{
    internal class ImplementAppServiceBuilder
    {
        private readonly Type _entityType;
        private StringBuilder builder;

        public ImplementAppServiceBuilder(Type entityType)
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
            builder.AppendLine($"using {namespac}.Dto;");
            builder.AppendLine("using Microsoft.AspNetCore.Mvc;");
            builder.AppendLine("using Syncfusion.EJ2.Base;");
            builder.AppendLine("using System.Collections;");
            builder.AppendLine("");

            //namespace
            builder.AppendLine($"namespace {namespac}.Services");
            builder.AppendLine("{");

            builder.AppendLine($"    public class {entityName}AppService : {GeneralSetting.AppServiceBase}, I{entityName}AppService");
            builder.AppendLine("    {");

            builder.AppendLine($"        private readonly I{entityName}DomainService _{paramName}DomainService;");
            builder.AppendLine($"        public {entityName}AppService(I{entityName}DomainService {paramName}DomainService)");
            builder.AppendLine("        {");
            builder.AppendLine($"            _{paramName}DomainService = {paramName}DomainService;");
            builder.AppendLine("        }");

            GenerateGetQueryable(builder, entityName, paramName);
            GenerateGetAllAsync(builder, entityName, paramName);
            GenerateGetByIdAsync(builder, entityName, paramName, idDataType);
            GenerateCreateAsync(builder, entityName, paramName);
            GenerateUpdateAsync(builder, entityName, paramName);
            GenerateDeleteAsync(builder, entityName, paramName);

            builder.AppendLine("    }");
            builder.AppendLine("}");

            return builder.ToString();
        }

        private void GenerateDeleteAsync(StringBuilder builder, string entityName, string paramName)
        {
            builder.AppendLine($"        public async Task DeleteAsync({GeneralSetting.DataTypeId} id)");
            builder.AppendLine("        {");
            builder.AppendLine($"            await _{paramName}DomainService.DeleteAsync(id);");
            builder.AppendLine("        }");
        }

        private void GenerateUpdateAsync(StringBuilder builder, string entityName, string paramName)
        {
            builder.AppendLine($"        public async Task<Update{entityName}Dto> UpdateAsync(Update{entityName}Dto {paramName}Dto)");
            builder.AppendLine("        {");
            builder.AppendLine($"            var {paramName} = ObjectMapper.Map<{entityName}>({paramName}Dto);");
            builder.AppendLine($"            var updated{entityName} = await _{paramName}DomainService.UpdateAsync({paramName});");
            builder.AppendLine($"            return ObjectMapper.Map<Update{entityName}Dto>(updated{entityName});");
            builder.AppendLine("        }");
        }

        private void GenerateCreateAsync(StringBuilder builder, string entityName, string paramName)
        {
            builder.AppendLine($"        public async Task<Create{entityName}Dto> CreateAsync(Create{entityName}Dto {paramName}Dto)");
            builder.AppendLine("        {");
            builder.AppendLine($"            var {paramName} = ObjectMapper.Map<{entityName}>({paramName}Dto);");
            builder.AppendLine($"            var created{entityName} = await _{paramName}DomainService.CreateAsync({paramName});");
            builder.AppendLine($"            return ObjectMapper.Map<Create{entityName}Dto>(created{entityName});");
            builder.AppendLine("        }");
        }

        private void GenerateGetByIdAsync(StringBuilder builder, string entityName, string paramName, string idDataType)
        {
            builder.AppendLine($"        public async Task<{entityName}Dto> GetByIdAsync({idDataType} id)");
            builder.AppendLine("        {");
            builder.AppendLine($"            var {paramName} = await _{paramName}DomainService.GetByIdAsync(id);");
            builder.AppendLine($"            return ObjectMapper.Map<{entityName}Dto>({paramName});");
            builder.AppendLine("        }");
        }

        private void GenerateGetQueryable(StringBuilder builder, string entityName, string paramName)
        {
            builder.AppendLine($"        public ReadGrudDto Get([FromBody] DataManagerRequest dm)");
            builder.AppendLine("        {");
            builder.AppendLine($"            var list = _{paramName}DomainService.Get().ToList();");
            builder.AppendLine($"            IEnumerable<{entityName}Dto> data = ObjectMapper.Map<List<{entityName}Dto>>(list);");
            builder.AppendLine($"            var operations = new DataOperations();");
            builder.AppendLine($"            if (dm.Where != null)");
            builder.AppendLine( "            {");
            builder.AppendLine($"                data = operations.PerformFiltering(data, dm.Where, \"and\");");
            builder.AppendLine( "            }");
            builder.AppendLine($"            ");
            builder.AppendLine($"            IEnumerable groupDs = new List<{entityName}Dto>();");
            builder.AppendLine($"            if (dm.Group != null)");
            builder.AppendLine( "            {");
            builder.AppendLine($"                groupDs = operations.PerformGrouping(data, dm.Group);");
            builder.AppendLine( "            }");
            builder.AppendLine($"            ");
            builder.AppendLine($"            var count = data.Count();");
            builder.AppendLine($"            if (dm.Skip != 0)");
            builder.AppendLine( "            {");
            builder.AppendLine($"                data = operations.PerformSkip(data, dm.Skip);");
            builder.AppendLine( "            }");
            builder.AppendLine($"            ");
            builder.AppendLine($"            if (dm.Take != 0)");
            builder.AppendLine( "            {");
            builder.AppendLine($"                data = operations.PerformSkip(data, dm.Take);");
            builder.AppendLine( "            }");
            builder.AppendLine($"            ");
            builder.AppendLine( "            return new ReadGrudDto() { result = data,count = 0, groupDs = groupDs };");
            builder.AppendLine("        }");
        }

        private void GenerateGetAllAsync(StringBuilder builder, string entityName, string paramName)
        {
            builder.AppendLine($"        public async Task<IList<{entityName}Dto>> GetAllAsync()");
            builder.AppendLine("        {");
            builder.AppendLine($"            var list = await _{paramName}DomainService.GetAllAsync();");
            builder.AppendLine($"            return ObjectMapper.Map<IList<{entityName}Dto>>(list);");
            builder.AppendLine("        }");

        }
    }
}
