using PSharp.Template.Core.Packs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PSharp.Template.Business
{
    public class ConsultPack : PsharpPack
    {
        public override IServiceCollection AddServices(IServiceCollection services, IConfiguration configuration)
        {
            return base.AddServices(services, configuration);
        }
    }
}
