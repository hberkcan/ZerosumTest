using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] TestScriptableObject testScriptableObject;

    void Start()
    {
        Camera.main.clearFlags = CameraClearFlags.SolidColor;
        Camera.main.backgroundColor = testScriptableObject.camBackgroundColor;

        Instantiate(testScriptableObject.levelPrefab);

        testScriptableObject.levelNumber = 1;
        testScriptableObject.state = State.Start;

        Debug.Log("Level" + testScriptableObject.levelNumber + " has Started!");
    }
}
