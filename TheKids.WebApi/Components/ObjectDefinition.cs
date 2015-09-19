using System.Collections.Generic;

namespace TheKids.WebApi.Components
{
    /// <summary>
    /// defines the properties of the object
    /// </summary>
    /// <remarks>
    /// the reason for using a dictionary in the data structure is becuase that will have 
    /// better performance when checking if the property exist or not comparing with other
    /// collection type
    /// </remarks>
    public class ObjectDefinition
    {
        public ObjectDefinition()
        {
            Properties = new Dictionary<string, ObjectDefinition>();
        }
        public IDictionary<string, ObjectDefinition> Properties { get; set; } 
    }
}
