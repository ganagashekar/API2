using AutoMapper;
using EMSVUAPIBusiness.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMSVU.API.MapperConfig
{
    public class AutoMapperConfiguration
    {
        [Obsolete]
        public static void Configure()
        {
            Mapper.Initialize(x => AutoMapperBusinessMappingConfig.Configure(x));

            Mapper.Configuration.AssertConfigurationIsValid();
        }
    }

    public static class AutoMapperBusinessMappingConfig
    {
        public static void Configure(IMapperConfigurationExpression mapperConfiguration)
        {
            Action<IMapperConfigurationExpression> profileMapper = (cfg) =>
            {
                cfg.AllowNullCollections = true;
                cfg.AddProfile(new Param_Mapper());
                //cfg.AddProfile(new OrdersResponseProfile());
                //cfg.AddProfile(new eZTrackerProfile());
                //cfg.AddProfile(new DashBoardProfile());
                //cfg.AddProfile(new SellerMapper());
            };
            profileMapper(mapperConfiguration);
        }

        [Obsolete]
        public static void Initialize()
        {
            Mapper.Initialize(AutoMapperBusinessMappingConfig.Configure);
        }
    }
}
