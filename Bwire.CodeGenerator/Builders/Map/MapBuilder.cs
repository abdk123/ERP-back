using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Bwire.CodeGenerator
{
    public class MapBuilder
    {
        private readonly Type _entityType;
        private StringBuilder builder;
        public MapBuilder(Type entityType)
        {
            _entityType = entityType;
            builder = new StringBuilder();
        }
        public string Genetate()
        {
            
            var className = _entityType.Name;
            var namespac = _entityType.Namespace;

            builder.AppendLine("using AutoMapper;");
            builder.AppendLine($"using {namespac}.Dto;");
            builder.AppendLine("");

            //namespace
            builder.AppendLine($"namespace {namespac}.Map");
            builder.AppendLine("{");

            //class
            GenerateClass();

            builder.AppendLine("}");

            return builder.ToString();
        }

        private void GenerateClass()
        {
            var name = $"{_entityType.Name}";

            builder.AppendLine($"   public class {name}MapProfile : Profile");
            builder.AppendLine("    {");
            builder.AppendLine($"        public {name}MapProfile()");
            builder.AppendLine("        {");

            builder.AppendLine($"            CreateMap<{name}, {name}Dto>();");
            builder.AppendLine($"            CreateMap<{name}, Read{name}Dto>();");
            builder.AppendLine($"            CreateMap<Create{name}Dto, {name}>();");
            builder.AppendLine($"            CreateMap<Update{name}Dto, {name}>();");

            builder.AppendLine("        }");
            builder.AppendLine("    }");
        }

        
    }
}
