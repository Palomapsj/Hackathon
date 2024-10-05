using Newtonsoft.Json;

namespace Care.Api.Repository.Helpers
{
    public class Helpers
    {



        public static string AuditJsonSerializer(object objToSerialize)
        {
            List<string> errors = new List<string>();

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new AuditCustomResolverToJson(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.None,
                NullValueHandling = NullValueHandling.Ignore,
                Error = (sender, args) =>
                {
                    errors.Add(args.ErrorContext.Error.Message);
                    args.ErrorContext.Handled = true;
                }

            };
            string jsonData = JsonConvert.SerializeObject(objToSerialize, settings);

            return jsonData;
        }

    }
}
