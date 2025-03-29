using UnityEngine;

namespace Map
{
    public enum NodeType
    {
        MinorEnemy,
        EliteEnemy,
        RestSite,
        SacrficeRoom,
        Store,
        Boss,
        Mystery,
        Wave,
    }
}

namespace Map
{
    [CreateAssetMenu]
    public class NodeBlueprint : ScriptableObject
    {
        public Sprite sprite;
        public NodeType nodeType;
    }
}