using UnityEngine;
using Unity.Jobs;
using Unity.Burst;
using Unity.Collections;

/*
 *
 * JobTest scene runs very slow because of the repeated dummy math operation below. Implement the for loop below, using parallelized Unity jobs and Burst compiler to gain performance
 * If the 'count' is too large for your machine to handle, you can decrease it.
 * 
 */

public class JobTest : MonoBehaviour
{

	[SerializeField]
	private bool useJob = false;

	private int count = 1000000;

	private float[] values;

	void Start()
	{
		values = new float[count];
	}


	void Update()
	{

		if (useJob)
		{
			// Job here

			NativeArray<float> nativeValues = new NativeArray<float>(values.Length, Allocator.TempJob);

			MyJob myJob = new MyJob { values = nativeValues };

			JobHandle jobHandle = myJob.Schedule(values.Length, 100);
			jobHandle.Complete();

			for(int i = 0; i < values.Length; i++)
            {
				values[i] = nativeValues[i];
            }
			
			nativeValues.Dispose();
		}
		else
		{

			for (int i = 0; i < values.Length; i++)
			{
				values[i] = Mathf.Sqrt(Mathf.Pow(values[i] + 1.75f, 2.5f + i)) * 5 + 2f;
			}

		}
		
	}

	[BurstCompile]
    public struct MyJob : IJobParallelFor
    {
		public NativeArray<float> values;

        public void Execute(int index)
        {
			values[index] = Mathf.Sqrt(Mathf.Pow(values[index] + 1.75f, 2.5f + index)) * 5 + 2f;
		}
    }
}