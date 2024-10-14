using Unity.Profiling;
using Unity.Profiling.Editor;

[ProfilerModuleMetadata("Gameplay Module")]
public class GamePlayProfilerModule : ProfilerModule
{
    static readonly ProfilerCounterDescriptor[] counters = {
        new("Hover Bot Count", ProfilerCategory.Scripts),
        new("Batches Count", ProfilerCategory.Render)
    };

    public GamePlayProfilerModule() : base(counters) {}

    public override ProfilerModuleViewController CreateDetailsViewController()
    {
        return new GamePlayProfilerModuleController(ProfilerWindow);
    }
}
