using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    /// <summary>
    /// A ScriptableObject that defines the configuration for generating a procedural map.
    /// </summary>
    [CreateAssetMenu(menuName = "Map/MapConfig", fileName = "NewMapConfig")]
    public class MapConfig : ScriptableObject
    {
        [Tooltip("Blueprints defining the available node types and their properties.")]
        public List<NodeBlueprint> nodeBlueprints;

        [Tooltip("Node types that will be randomly placed on layers with 'Randomize Nodes' enabled.")]
        public List<NodeType> randomNodes = new List<NodeType>
        {
            NodeType.Mystery, NodeType.Store,NodeType.Wave, NodeType.SacrficeRoom, NodeType.MinorEnemy, NodeType.RestSite
        };

        /// <summary>
        /// The width of the grid, determined by the maximum value of pre-boss nodes or starting nodes.
        /// </summary>
        public int GridWidth => Mathf.Max(numOfPreBossNodes.max, numOfStartingNodes.max);

        [Tooltip("Defines the minimum and maximum number of nodes in the pre-boss layer.")]
        public IntMinMax numOfPreBossNodes;

        [Tooltip("Defines the minimum and maximum number of starting nodes in the first layer.")]
        public IntMinMax numOfStartingNodes;

        [Tooltip("Increase this value to generate more paths between nodes.")]
        public int extraPaths;

        [Tooltip("The layers that make up the structure of the map.")]
        public List<MapLayer> layers;
    }
}
