using System;
using System.Collections.Generic;
using System.IO;

namespace leonasa.Tools.SampleSimpleInjector
{
    public class ScenarioReaderFactory : Dictionary<string, Func<IScenarioReader>>, IScenarioReaderFactory
    {
        public IScenarioReader CreateNew(string name) => this[Path.GetExtension(name) ?? throw new InvalidOperationException()]();
    }
}