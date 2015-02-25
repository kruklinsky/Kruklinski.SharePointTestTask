using BLL.Interface.Abstract;
using BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyResolver.cs
{
    public class ResolverModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITestListQueryService>().To<TestListQueryService>()
                .WithConstructorArgument("host", "http://evbyminsd4b4d:8080/Alexandr_Krupnichki")
                .WithConstructorArgument("userName", "Alexandr_Krupnichki")
                .WithConstructorArgument("password", "Pa$$w0rd1" );
        }
    }
}
