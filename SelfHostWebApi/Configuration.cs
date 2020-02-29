﻿using System;
using leon4s4.tools.SampleSimpleInjector;
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
            //Sample of Factory DI
            container.Register<ScenarioReader>(Lifestyle.Singleton);
            container.Register<TrafficJsonReader>(Lifestyle.Singleton);

            container.RegisterInstance<IScenarioReaderFactory>(new ScenarioReaderFactory
            {
                {".xml", container.GetInstance<ScenarioReader>},
                {".json", container.GetInstance<TrafficJsonReader>}
            });

            return container;
        });


        public static Container Container => Lazy.Value;
    }
}