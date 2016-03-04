using Microsoft.Owin;
using OnlineLearning;
using Owin;

[assembly: OwinStartup(typeof (Startup))]

namespace OnlineLearning
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}