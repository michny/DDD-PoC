using System.Reflection;
using AutoMapper;

namespace DDD.CommercePoC.Web
{
    public static class MappingConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => cfg.AddProfiles(Assembly.GetExecutingAssembly()));

            //This line checks that all used mappings are correctly configured and throws an exception if they are not
            Mapper.AssertConfigurationIsValid();
        }
    }
}