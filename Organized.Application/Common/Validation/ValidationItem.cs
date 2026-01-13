using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Organized.Application.Common.Validation
{
    public class ValidationItem
    {
        public string ValidationSeverity { get; set; }
        public ValidationType ValidationType { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
