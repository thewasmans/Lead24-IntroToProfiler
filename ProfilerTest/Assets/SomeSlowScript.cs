using Unity.Profiling;
using UnityEngine;

public class SomeSlowScript : MonoBehaviour
{
    [SerializeField] private int _iterationValue01;
    [SerializeField] private int _iterationValue02;

    ProfilerMarker profilerMarker01 = new ProfilerMarker(ProfilerCategory.Scripts, "MyTestProfiler");
    ProfilerMarker<int> profilerMarkerWithInData = new("MyTestProfiler", "Iterations"); 

    void Start()
    {

    }

    void Update()
    {
        using(profilerMarker01.Auto())
        {
            SomeHeavyCalculation();
        }
        
        using(profilerMarkerWithInData.Auto(2000))
        {
            SomeOtherHeavyCalculation();
        }

        profilerMarker01.Begin();
        SomeOtherHeavyCalculation();
        profilerMarker01.End();
    }


    private void SomeHeavyCalculation()
    {
        FindPrimeNumber(_iterationValue01);
    }

    private void SomeOtherHeavyCalculation()
    {
        FindPrimeNumber(_iterationValue01);
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
}
