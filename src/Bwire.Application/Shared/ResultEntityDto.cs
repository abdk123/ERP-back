using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace Bwire.Shared
{
    public class ResultEntityDto
    {
        public EntityDto EntityDto { get; set; }
        public IList<ValidationMessage> ValidationMessages { get; set; }
    }
}
