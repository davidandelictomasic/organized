using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Organized.Application.Common.Validation
{
    public class ValidationResultItem
    {
        public string ValidationSeverity { get; init; }
        public string Code { get; set; }
        public string Message { get; set; }

        public static ValidationResultItem FromValidationItem(ValidationItem validationItem)
        {
            return new ValidationResultItem
            {
                ValidationSeverity = validationItem.ValidationSeverity,
                Code = validationItem.Code,
                Message = validationItem.Message
            };
        }
    }
}
