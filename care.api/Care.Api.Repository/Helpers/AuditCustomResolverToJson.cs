using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Care.Api.Repository.Helpers
{
    public class AuditCustomResolverToJson : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);


            foreach (JsonProperty prop in properties)
            {
                if (prop.PropertyType == typeof(Validation.ValidationResult) || prop.PropertyName == "IsValid")
                {
                    prop.Ignored = true;
                }
                else if ((prop.PropertyType.IsClass || prop.PropertyType.IsInterface) &&
                         prop.PropertyType != typeof(string) && prop.PropertyType != typeof(Guid) &&
                         prop.PropertyType != typeof(DateTime) && prop.PropertyType != typeof(decimal))
                {
                    prop.Ignored = true;
                }
            }
            return properties;
        }
    }
}
