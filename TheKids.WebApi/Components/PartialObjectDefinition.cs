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
    public class PartialObjectDefinition
    {
        public PartialObjectDefinition()
        {
            Properties = new Dictionary<string, PartialObjectDefinition>();
        }
        public IDictionary<string, PartialObjectDefinition> Properties { get; set; } 
    }
}
