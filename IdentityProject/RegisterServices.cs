using Services;
using Services.Account;
using Services.Attributes;
using System.Reflection;

namespace IdentityProject
{
    public static class RegisterServices
    {
        public static void AddStandAloneServices(this IServiceCollection @this) {
            var iAttributetype = typeof(IService);
            var iAssembly = iAttributetype.Assembly;
            var iDefinedTypes = iAssembly.GetExportedTypes();
            var iServices = iDefinedTypes
                .Where(type => type.GetTypeInfo()
                .GetCustomAttribute<IService>() != null);

            foreach (var iService in iServices)
            {
                var service = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(type => type.GetTypes())
                    .Where(s => iService.IsAssignableFrom(s) && s.IsClass).FirstOrDefault();
                if (service != null)
                {
                    @this.AddScoped(iService,service);
                }
            }
        }
    }
}
