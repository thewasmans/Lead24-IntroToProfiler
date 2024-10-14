using System;
using UnityEngine;

public class CullingGroupTest : MonoBehaviour
{
    public SomeSlowScript SlowScript;

    private CullingGroup group;

    private void Start() {
        group = new CullingGroup();
        group.targetCamera = Camera.main;
        group.onStateChanged += OnstateChanged;
    }

    private void OnstateChanged(CullingGroupEvent sphere)
    {
        SlowScript.enabled = sphere.isVisible;
    }

    private void Update()
    {
        group.SetBoundingSpheres(new BoundingSphere[]
        {
            new (transform.position, 1)
        });
        group.SetBoundingSphereCount(1);
    }

    private void OnDestroy() {
        group.Dispose();
    }
}
