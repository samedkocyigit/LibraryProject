using Autofac.Integration.WebApi;
using Autofac;
using LibraryApp.BLL.Services;
using LibraryApp.DAL;
using System.Web.Http;
using LibraryApp.DAL.Repositories.Abstract;
using LibraryApp.DAL.Repositories.Concrete;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;
using LibraryApp.BLL.Services.Abstract;

namespace LibraryApp.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // Autofac yapılandırması
            var builder = new ContainerBuilder();
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;


            // Web API denetleyicileri yükleyin
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);

            // Service'leri ve repository'leri buraya ekleyin
            builder.RegisterType<AddressService>().As<IAddressService>();
            builder.RegisterType<AuthorService>().As<IAuthorService>();
            builder.RegisterType<BookService>().As<IBookService>();
            builder.RegisterType<BorrowingService>().As<IBorrowingService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<FloorService>().As<IFloorService>();
            builder.RegisterType<MemberService>().As<IMemberService>();
            builder.RegisterType<ShelfService>().As<IShelfService>();

            // Repository'leri ekleyin
            builder.RegisterGeneric(typeof(DAL.Repositories.Concrete.GenericRepository<>)).As(typeof(DAL.Repositories.Abstract.GenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<AddressRepository>().As<IAddressRepository>().InstancePerLifetimeScope();
            builder.RegisterType<AuthorRepository>().As<IAuthorRepository>().InstancePerLifetimeScope();
            builder.RegisterType<BookRepository>().As<IBookRepository>().InstancePerLifetimeScope();
            builder.RegisterType<BorrowingRepository>().As<IBorrowingRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().InstancePerLifetimeScope();
            builder.RegisterType<FloorRepository>().As<IFloorRepository>().InstancePerLifetimeScope();
            builder.RegisterType<MemberRepository>().As<IMemberRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ShelfRepository>().As<IShelfRepository>().InstancePerLifetimeScope();

            // LibraryContext için yapılandırma
            builder.RegisterType<LibraryContext>().AsSelf().InstancePerLifetimeScope();

            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            //// JWT Authentication
            //var key = Encoding.ASCII.GetBytes("your_secret_key_here");
            //var tokenValidationParameters = new TokenValidationParameters
            //{
            //    ValidateIssuerSigningKey = true,
            //    IssuerSigningKey = new SymmetricSecurityKey(key),
            //    ValidateIssuer = false,
            //    ValidateAudience = false
            //};

            //GlobalConfiguration.Configuration.Filters.Add(new JwtAuthenticationFilter(tokenValidationParameters));
        }
    }
    //public class JwtAuthenticationFilter : ActionFilterAttribute
    //{
    //    private readonly TokenValidationParameters _tokenValidationParameters;

    //    public JwtAuthenticationFilter(TokenValidationParameters tokenValidationParameters)
    //    {
    //        _tokenValidationParameters = tokenValidationParameters;
    //    }

    //    public override void OnActionExecuting(HttpActionContext actionContext)
    //    {
    //        if (actionContext.Request.Headers.Authorization != null)
    //        {
    //            var token = actionContext.Request.Headers.Authorization.Parameter;
    //            var tokenHandler = new JwtSecurityTokenHandler();
    //            try
    //            {
    //                var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var validatedToken);
    //                actionContext.RequestContext.Principal = principal;
    //            }
    //            catch
    //            {
    //                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
    //            }
    //        }
    //        else
    //        {
    //            actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
    //        }
    //    }
    //}
}
