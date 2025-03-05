using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

namespace Map
{
    /// <summary>
    /// Represents a procedural map structure with nodes and paths, ie a map system.
    /// </summary>
    public class Map
    {
        [Tooltip("List of all nodes present in the map.")]
        public List<Node> nodes;

        [Tooltip("List of connections between nodes, represented as Vector2Int pairs.")]
        public List<Vector2Int> path;

        [Tooltip("The name of the boss node.")]
        public string bossNodeName;

        [Tooltip("The name of the map configuration")]
        public string configName;

        /// <summary>
        /// Constructor to initialize a new map instance.
        /// </summary>
        /// <param name="configName">The name of the map configuration.</param>
        /// <param name="bossNodeName">The name of the boss node.</param>
        /// <param name="nodes">The list of nodes in the map.</param>
        /// <param name="path">The list of connections between nodes.</param>
        public Map(string configName, string bossNodeName, List<Node> nodes, List<Vector2Int> path)
        {
            this.configName = configName;
            this.bossNodeName = bossNodeName;
            this.nodes = nodes;
            this.path = path;
        }

        /// <summary>
        /// Retrieves the boss node from the map.
        /// </summary>
        /// <returns>The boss node if found, otherwise null.</returns>
        public Node GetBossNode()
        {
            return nodes.FirstOrDefault(n => n.nodeType == NodeType.Boss);
        }

        /// <summary>
        /// Calculates the vertical distance between the first layer of nodes and the boss node.
        /// </summary>
        /// <returns>The Y-axis distance between the first layer node and the boss node.</returns>
        public float DistanceBetweenFirstAndLastLayers()
        {
            Node bossNode = GetBossNode();
            Node firstLayerNode = nodes.FirstOrDefault(n => n.point.y == 0);

            if (bossNode == null || firstLayerNode == null)
                return 0f;

            return bossNode.position.y - firstLayerNode.position.y;
        }

        /// <summary>
        /// Retrieves a node based on its grid position.
        /// </summary>
        /// <param name="point">The position of the node.</param>
        /// <returns>The node at the specified position if found, otherwise null.</returns>
        public Node GetNode(Vector2Int point)
        {
            return nodes.FirstOrDefault(n => n.point.Equals(point));
        }

        /// <summary>
        /// Converts the map data into a JSON-formatted string.
        /// </summary>
        /// <returns>A JSON string representing the map.</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
    }
}
