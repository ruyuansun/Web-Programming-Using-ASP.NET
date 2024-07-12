using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppProjectTemplateV2Practice.Startup))]

namespace WebAppProjectTemplateV2Practice
{
   public partial class Startup
   {
      public void Configuration(IAppBuilder app)
      {
         ConfigureAuth(app);
      }
   }
}
