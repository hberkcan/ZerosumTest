using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    public GameObject obj;

    void Start()
    {
        //DelayedExecution.Do(MyMethod, 1f);

        //ObjectName();

        //Debug.Log(CheckColl());

        //Utility.GenerateTexture(800, 600, Color.red);

        //Utility.GeneratePoints(10);

        //Texture2D tex = Utility.GenerateTexture(10, 10, Color.red);
        //obj.GetComponent<Renderer>().material.mainTexture = tex;
    }

    void MyMethod()
    {
        Debug.Log("Hello");
    }

    void ObjectName()
    {
        GameObject[] array = Utility.GetObjectsWithName("beko");

        for(int i = 0; i < array.Length; i++)
        {
            Debug.Log("Hi");
        }
    }

    bool CheckColl()
    {
        Ray ray = new Ray(Vector3.zero, Vector3.forward);

        return Utility.CheckCollision(ray, 100f, 0);
    }
}
