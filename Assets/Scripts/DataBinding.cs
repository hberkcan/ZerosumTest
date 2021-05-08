using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;



/*
 * 
 * 
 * Assume that you have created the class 'Data' for some reason and you are processing some data inside it. The output is float 'data'.
 * Then you realized you have to show this variable on the screen via a UnityEngine.Text, using the class 'TextSetter' you have written.
 * Data and TextSetter classes have no means of communication. They can't use references of each other.
 * In addition, you liked the TextSetter class a lot and want to use it in different places with different types of data later on. You want to generalize your technique.
 * 
 * Writing a global manager class that handles the classes below is not an option.
 * 
 * Static access to data classes is not the answer.
 * 
 * How would you solve this? Is there a behavioural pattern that seems to be the answer?
 * 
 * You can implement anything you wish.
 * 
 * Your solution doesn't actually have to work, just make sure your solution and intentions are clear conceptually.
 * 
 * 
 */



public class Data : MonoBehaviour
{


	private float data = 0f;

	private void Update()
	{
		data += Time.deltaTime * 5f;
	}


}



public class TextSetter : MonoBehaviour
{

	[SerializeField] private Text text;


}

/*
 * ScriptableObject can be an asset and accessible by any object in the scene.
 * In this example, we can create a SO that contains data. TextSetter monitors the data variable to update its display.
 * TextSetter does not know anything about the Data class' Gameobject in the scene, it just reads from the same variable that the Data class writes to.
 */



