using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RelationshipHistoryBoard.Startup))]
namespace RelationshipHistoryBoard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
