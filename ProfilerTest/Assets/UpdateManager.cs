using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    public enum UpdateMode
    {
        BucketA,
        BucketB,
        Always,
    }

    public static UpdateManager Instance {get; set;}

    private readonly HashSet<IBatchUpdate> sliceUpdateA = new ();
    private readonly HashSet<IBatchUpdate> sliceUpdateB = new ();

    private bool isCurrentBucketA;

    public void RegisterSlicedUpdate(IBatchUpdate updateBehavior, UpdateMode mode)
    {
        if(mode == UpdateMode.Always)
        {
            sliceUpdateA.Add(updateBehavior);
            sliceUpdateB.Add(updateBehavior);
        }
        else
        {
            var targetHashSet = mode == UpdateMode.BucketA ? sliceUpdateA : sliceUpdateB;
            targetHashSet.Add(updateBehavior);
        }
    }


    public void DeregisterSliceUpdate(IBatchUpdate bh)
    {
        sliceUpdateA.Remove(bh);
        sliceUpdateB.Remove(bh);
    }

    private void Awake() {

        Instance = Instance ? Instance : this;
    }

    private void Update()
    {
        var target = isCurrentBucketA ? sliceUpdateA : sliceUpdateB;

        foreach (var updateBH in target)
        {
            updateBH.BatchUpdate();
        }

        isCurrentBucketA = !isCurrentBucketA;
    }    
}