using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace TheKids.WebApi.Components
{
    public class PartialObjectConverter : IPartialObjectConverter
    {
        public ExpandoObject ConvertToExpandoObject(object response, ObjectDefinition objetDefinition)
        {
            var definitions = objetDefinition.Properties;
            var returnObj = new ExpandoObject();
            var type = response.GetType();
            // make sure the property id is included
            var propertyId = string.Format("{0}Id", type.Name);
            var defaultList = new Collection<string> {propertyId, "URI"};
            // retrieve a list of the properties
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var propertyInfo in properties)
            {
                // if it is in the default lsit, we have to output that regardless if that is defined in
                // the object definition
                if (defaultList.Any(x => x.Equals(propertyInfo.Name, StringComparison.InvariantCultureIgnoreCase)))
                {
                    ((IDictionary<string, object>) returnObj).Add(propertyInfo.Name, propertyInfo.GetValue(response, null));
                }
                else if (definitions.Any(f => f.Key.Equals(propertyInfo.Name, StringComparison.InvariantCultureIgnoreCase)))
                {
                    // if there is not subdefinition we need to filter, just put everything in
                    var definition = definitions[propertyInfo.Name];
                    if (definition == null ||
                        definition.Properties == null ||
                        !definition.Properties.Any())
                    {
                        ((IDictionary<string, object>) returnObj).Add(propertyInfo.Name,
                            propertyInfo.GetValue(response, null));
                    }
                    else
                    {
                        object value = propertyInfo.GetValue(response);
                        // well there is some subdefinition we need to filter
                        if (IsCollection(value))
                        {
                            var instance = new List<ExpandoObject>();
                            var valueEnumerable = value as IEnumerable;
                            foreach (var variable in valueEnumerable)
                            {
                                instance.Add(ConvertToExpandoObject(variable, definition));
                            }
                            ((IDictionary<string, object>)returnObj).Add(propertyInfo.Name, instance);

                        }
                        else
                        {
                            ((IDictionary<string, object>)returnObj).Add(propertyInfo.Name, ConvertToExpandoObject(value, definition));                            
                        }
                    }
                }
            }
            return returnObj;
        }

        /// <summary>
        /// check if the object is a collection
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool IsCollection(object input)
        {
            if (input == null) return false;
            return input is IEnumerable &&
                   input.GetType().IsGenericType &&
                   input.GetType().GetInterfaces().Any(t => t.IsGenericType && 
                                                        t.GetGenericTypeDefinition() == typeof(IEnumerable<>));
        }
    }
}