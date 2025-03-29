using System;
using UnityEngine;

/// <summary>
/// Create a scriptable hero 
/// </summary>
[CreateAssetMenu(fileName = "New Scriptable Example")]
public class ScriptableUnit : ScriptableExampleUnitBase {
    public UnitType UnitType;
 
}

[Serializable]
public enum UnitType {
    Undead = 0,
    Cult = 1
}

