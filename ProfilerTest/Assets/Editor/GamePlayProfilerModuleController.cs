using Unity.Profiling;
using Unity.Profiling.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class GamePlayProfilerModuleController : ProfilerModuleViewController
{
    const string guid = "e6d68e74694f96444a43b91fe88afc32";
    public Label LabelBotCount;
    public Label LabelBatches;
    
    public GamePlayProfilerModuleController(ProfilerWindow profilerWindow) : base(profilerWindow)
    {
        profilerWindow.SelectedFrameIndexChanged += OnSelectedFrameIndexChanged;
    }

    private void OnSelectedFrameIndexChanged(long newFrameIndex)
    {
        string botCount = UnityEditorInternal.ProfilerDriver.GetFormattedCounterValue((int)newFrameIndex, ProfilerCategory.Scripts.Name, "Hover Bot Count");
        string batches = UnityEditorInternal.ProfilerDriver.GetFormattedCounterValue((int)newFrameIndex, ProfilerCategory.Scripts.Name, "Batches Count");

        LabelBotCount.text = $"Number of bots {botCount}";
        LabelBatches.text = $" Number of baches {batches}";
    }

    protected override void Dispose(bool disposing)
    {
        if(disposing)
            ProfilerWindow.SelectedFrameIndexChanged -= OnSelectedFrameIndexChanged;

        base.Dispose(disposing);
        Debug.Log("Dispose");
    }

    protected override VisualElement CreateView()
    {
        var assetPath = AssetDatabase.GUIDToAssetPath(guid);
        var visualTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(assetPath);

        TemplateContainer templateContainer = visualTreeAsset.Instantiate();
        LabelBotCount = new Label("Number of bots ");
        LabelBatches = new Label("Number of batches");
        templateContainer.Add(LabelBotCount);
        templateContainer.Add(LabelBatches);
        templateContainer.Add(new Button(){
            text = "Click me five"
        });

        return templateContainer;
    }
}
