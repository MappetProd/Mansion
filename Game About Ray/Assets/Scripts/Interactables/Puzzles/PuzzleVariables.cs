using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Scriptable object/PuzzleDataBase")]
public class PuzzleVariables : ScriptableObject
{
    public Dictionary<int, bool> puzzlesIsSolvedDict = new Dictionary<int, bool>()
    {
        {1, false },
    };
}
