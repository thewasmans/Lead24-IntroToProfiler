using System.Text;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.UI;

public class ProfilerData : MonoBehaviour
{
    public ProfilerRecorder botCountRecorder;
    public ProfilerRecorder batchesRecorder;
    [SerializeField] public Text textLabel;

    private void Update()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append($"Hover count: \t\t {botCountRecorder.LastValue} ");
        stringBuilder.AppendLine($"Render Batches: \t\t {batchesRecorder.LastValue} ");
        textLabel.text = stringBuilder.ToString();
    }

    private void OnEnable()
    {
        botCountRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Scripts, "Hover Bot Count");
        batchesRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Scripts, "Batches Count");
    }

    private void OnDisable()
    {
        botCountRecorder.Dispose();
        batchesRecorder.Dispose();
    }
}
