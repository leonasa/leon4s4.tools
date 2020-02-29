namespace leon4s4.tools.SampleSimpleInjector
{
    public interface IScenarioReaderFactory
    {
        IScenarioReader CreateNew(string name);
    }
}