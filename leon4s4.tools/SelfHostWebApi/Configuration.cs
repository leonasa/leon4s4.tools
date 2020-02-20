using System;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace leon4s4.tools.SelfHostWebApi
{
    public static class Configuration
    {
        private static readonly Lazy<Container> Lazy = new Lazy<Container>(() =>
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            //Register Dependencies here
            //container.Register<LogFactory, LogFactory>(Lifestyle.Singleton);
            
            return container;
        });


        public static Container Container => Lazy.Value;
    }
}