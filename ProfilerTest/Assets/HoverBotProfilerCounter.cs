using Unity.Profiling;
using UnityEngine;

public class HoverBotProfilerCounter : MonoBehaviour
{
    static readonly ProfilerCounterValue<int> profilerCounterValue = new("Hover Bot Count", ProfilerMarkerDataUnit.Count);

    private void OnEnable()
    {
        profilerCounterValue.Value ++;
    }

    private void OnDisable()
    {
        profilerCounterValue.Value --;
    }
}
