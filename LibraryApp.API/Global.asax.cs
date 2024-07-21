using Autofac.Integration.WebApi;
using Autofac;
using LibraryApp.BLL.Services;
using LibraryApp.DAL;
using System.Web.Http;
using LibraryApp.DAL.Repositories.Abstract;
using LibraryApp.DAL.Repositories.Concrete;

namespace LibraryApp.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // Autofac yapılandırması
            var builder = new ContainerBuilder();

            // Web API denetleyicileri yükleyin
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);

            // Service'leri ve repository'leri buraya ekleyin
            builder.RegisterType<AddressService>().As<AddressService>();
            builder.RegisterType<AuthorService>().As<AuthorService>();
            builder.RegisterType<BookService>().As<BookService>();
            builder.RegisterType<BorrowingService>().As<BorrowingService>();
            builder.RegisterType<CategoryService>().As<CategoryService>();
            builder.RegisterType<FloorService>().As<FloorService>();
            builder.RegisterType<MemberService>().As<MemberService>();
            builder.RegisterType<ShelfService>().As<ShelfService>();

            // Repository'leri ekleyin
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();

            // LibraryContext için yapılandırma
            builder.RegisterType<LibraryContext>().AsSelf().InstancePerLifetimeScope();

            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
