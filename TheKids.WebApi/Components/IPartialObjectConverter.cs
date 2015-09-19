
using System.Dynamic;

namespace TheKids.WebApi.Components
{
    /// <summary>
    /// the converter that converts the response object to API response object
    /// according to the objetDefinition parameter
    /// </summary>
    public interface IPartialObjectConverter
    {
        ExpandoObject ConvertToExpandoObject(object response, ObjectDefinition objetDefinition);
    }
}
