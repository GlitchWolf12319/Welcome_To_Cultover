using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// One repository for all scriptable objects. Create your query methods here to keep your business logic clean.
/// I make this a MonoBehaviour as sometimes I add some debug/development references in the editor.
/// If you don't feel free to make this a standard class
/// </summary>
public class ResourceSystem : StaticInstance<ResourceSystem> {
    public List<ScriptableUnit> Units { get; private set; }
    private Dictionary<UnitType, ScriptableUnit> _UnitDict;

    protected override void Awake() {
        base.Awake();
        AssembleResources();
    }

    private void AssembleResources() {
        //Unit is a folder inside of resources folder that has a list of the units in the game
        Units = Resources.LoadAll<ScriptableUnit>("Unit").ToList();
        _UnitDict = Units.ToDictionary(r => r.UnitType, r => r);
    }

    public ScriptableUnit GetExampleHero(UnitType t) => _UnitDict[t];
    public ScriptableUnit GetRandomHero() => Units[Random.Range(0, Units.Count)];
}   