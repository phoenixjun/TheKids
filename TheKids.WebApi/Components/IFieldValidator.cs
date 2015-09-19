
using System.Collections.Generic;

namespace TheKids.WebApi.Components
{
    public interface IFieldValidator
    {
        FieldValidationResponse Validate(string fields, ICollection<string> validFields);
    }
}
