using Unity.Profiling;
using UnityEngine;

public class NavigationLogic : MonoBehaviour, IBatchUpdate
{

    public int Iterations = 1000;

    public ProfilerMarker marker = new ProfilerMarker(ProfilerCategory.Scripts, "Navigation Logic");

    void DoingSOmeAILogic()
    {
        FindPrimeNumber(Iterations);
    }
    
    public void DoingSomeOtherAILogic()
    {
        FindPrimeNumber(Iterations);
    }    

   private static long FindPrimeNumber(int n)
    {
        int count = 0;
        long a = 2;
        while (count < n)
        {
            long b = 2;
            int prime = 1;// to check if found a prime
            while (b * b <= a)
            {
                if (a % b == 0)
                {
                    prime = 0;
                    break;
                }
                b++;
            }
            if (prime > 0)
            {
                count++;
            }
            a++;
        }
        return (--a);
    }

    public void BatchUpdate()
    {
        marker.Begin();
        DoingSOmeAILogic();
        marker.End();
    }

    private void OnEnable()
    {
        UpdateManager.Instance.RegisterSlicedUpdate(this, UpdateManager.UpdateMode.BucketA);
    }

    private void OnDisable() {
        
        UpdateManager.Instance.DeregisterSliceUpdate(this);
    }
}

public interface IBatchUpdate
{
    public void BatchUpdate();
}