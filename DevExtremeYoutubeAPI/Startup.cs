using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;

namespace DevExtremeYoutubeAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            //HttpConfiguration httpConfiguration = new HttpConfiguration();
            //ConfigureOAuth(app);
            //WebApiConfig.Register(httpConfiguration);
            //app.UseWebApi(httpConfiguration);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new Microsoft.Owin.PathString("/Token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new AuthorizationServerProvider()
            };
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            //Register the web api to the pipeline 
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }

        //void ConfigureOAuth(IAppBuilder app)
        //{
        //    //app.UseCors(CorsOptions.AllowAll);

        //    //Token üretimi için authorization ayarlarını belirliyoruz.
        //    OAuthAuthorizationServerOptions oAuthAuthorizationServerOptions = new OAuthAuthorizationServerOptions()
        //    {
        //        TokenEndpointPath = new PathString("/token"), //Token talebini yapacağımız dizin
        //        AccessTokenExpireTimeSpan = TimeSpan.FromDays(1), //Oluşturulacak tokenı bir gün geçerli olacak şekilde ayarlıyoruz.
        //        AllowInsecureHttp = true, //Güvensiz http portuna izin veriyoruz.
        //        Provider = new ProviderAuthorization() //Sağlayıcı sınıfını belirtiyoruz. Birazdan bu sınıfı oluşturacağız.
        //    };

        //    //Yukarıda belirlemiş olduğumuz authorization ayarlarında çalışması için server'a ilgili OAuthAuthorizationServerOptions tipindeki nesneyi gönderiyoruz.
        //    app.UseOAuthAuthorizationServer(oAuthAuthorizationServerOptions);

        //    //Authentication Type olarak Bearer Authentication'ı kullanacağımızı belirtiyoruz.
        //    app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        //    //Bearer Token, OAuth 2.0 ile gelen standartlaşmış bir token türüdür.
        //    //Herhangi bir kriptolu veriye ihtiyaç duyulmaksızın client tarafından token isteğinde bulunulur ve server belirli bir zamana sahip access_token üretir.
        //    //Bearer Token SSL güvenliğine dayanır.
        //}

        //public void Configuration(IAppBuilder app)
        //{

        //    HttpConfiguration config = new HttpConfiguration();
        //    ConfigureOAuth(app);

        //    WebApiConfig.Register(config);
        //    app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        //    app.UseWebApi(config);
        //}
        //void ConfigureOAuth(IAppBuilder app)
        //{
        //    OAuthAuthorizationServerOptions oAuthAuthorizationServerOptions = new OAuthAuthorizationServerOptions()
        //    {
        //        AllowInsecureHttp = true,
        //        TokenEndpointPath = new PathString("/token"),
        //        AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
        //        Provider = new SimpleAuthorizationServerProvider()
        //    };

        //    app.UseOAuthAuthorizationServer(oAuthAuthorizationServerOptions);
        //    app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        //}
    }

}