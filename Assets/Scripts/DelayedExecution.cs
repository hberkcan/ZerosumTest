
using UnityEngine;
using System.Collections;



public class DelayedExecution : MonoBehaviour
{

	/*
	 * 
	 * 
	 * Implement the function 'Do' below so that it can be called from any context.
	 * You want to pass it a function and a float 'delay'. After 'delay' seconds, the function is to be executed.
	 * You can create as many additional functions as you need.
	 * Assume that this class needs to be a 'MonoBehaviour', so don't change that.
	 * 
	 * 
	 */

	static public DelayedExecution instance;

	public delegate void MyDelegate();

	private void Awake()
    {
		instance = this;
    }

    public static void Do(MyDelegate myDelegate, float delay)
    {
		instance.StartCoroutine(instance.MyCoroutine(myDelegate, delay));
    }

	IEnumerator MyCoroutine(MyDelegate myDelegate, float delay)
	{
		yield return new WaitForSeconds(delay);

		myDelegate();
	}
}

