
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * 
 * 
 * Complete the functions below.  
 * For sure, they don't belong in the same class. This is just for the test so ignore that.
 * 
 * 
 */



public static class Utility
{


	public static GameObject[] GetObjectsWithName(string name)
	{

		/*
		 * 
		 *	Return all objects in the scene with the specified name. Don't think about performance, do it in as few lines as you can. 
		 * 
		 */

		List<GameObject> goList = new List<GameObject>();

		foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
		{
			if (go.name == name)
				goList.Add(go);
		}

		GameObject[] arrayOfGameObjects = goList.ToArray();

		return arrayOfGameObjects;
	}


	public static bool CheckCollision(Ray ray, float maxDistance, int layer)
	{
		/*
		 * 
		 *	Perform a raycast using the ray provided, only to objects of the specified 'layer' within 'maxDistance' and return if something is hit. 
		 * 
		 */

		int layerMask = 1 << layer;

		return Physics.Raycast(ray, maxDistance, layerMask);
	}





	public static Vector2[] GeneratePoints(int size)
	{

		/*
		 * Generate 'size' number of random points, making sure they are distributed as evenly as possible (Trying to achieve maximum distance between every neighbor).
		 * Boundary corners are (0, 0) and (1, 1). (Point (1.2, 0.45) is not valid because it's outside the boundaries. )
		 * Is there a known algorithm that achieves this?
		 */

		float p = 1.325f;  //g is called plastic constant derived from golden ratio

		float a1 = 1f / p; //Quasirandom sequences
		float a2 = 1f / (p * p);

		Vector2[] myArray = new Vector2[size];

		for(int i = 0; i < size; i++)
        {
			Vector2 myVector = new Vector2((0.5f + a1 * (i + 1)) % 1f, (0.5f + a2 * (i + 1)) % 1f);
			Debug.Log(myVector);
			myArray[i] = myVector;
        }

		return myArray;
	}


	public static Texture2D GenerateTexture(int width, int height, Color color)
	{

		/*
		 * Create a Texture2D object of specified 'width' and 'height', fill it with 'color' and return it. Do it as performant as possible.
		 */
		Texture2D myTexture = new Texture2D(width, height);

		Color[] fillColorArray = myTexture.GetPixels();

		for(int i = 0; i < fillColorArray.Length; i++)
        {
			fillColorArray[i] = color;
        }

		myTexture.SetPixels(fillColorArray);
		myTexture.Apply();

		return myTexture;
	}
}