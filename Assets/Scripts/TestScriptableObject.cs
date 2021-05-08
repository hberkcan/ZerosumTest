using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State { Start, ClearAllArea };

[CreateAssetMenu(fileName = "TestScriptableObject" , menuName = "ScriptableObjects/TestScriptableObject")]
public class TestScriptableObject : ScriptableObject
{
    public int levelNumber;
    public Color camBackgroundColor;
    public GameObject levelPrefab;
    public State state;
}
