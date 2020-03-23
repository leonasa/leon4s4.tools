using System;

namespace leonasa.Tools.SampleSimpleInjector
{
    public interface IScenarioReaderFactory
    {
        IScenarioReader CreateNew(string name);
    }
}