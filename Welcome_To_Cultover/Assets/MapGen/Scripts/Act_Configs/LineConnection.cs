using UnityEngine;
using UnityEngine.UI.Extensions;

namespace Map
{
    /// <summary>
    /// Represents a connection between two MapNodes, which can be visualized using either a LineRenderer or a UILineRenderer.
    /// </summary>
    [System.Serializable]
    public class LineConnection
    {
        [Tooltip("The 3D LineRenderer used to visualize the connection in world space.")]
        public LineRenderer lr;

        [Tooltip("The 2D UILineRenderer used to visualize the connection in UI space.")]
        public UILineRenderer uilr; 

        [Tooltip("The starting MapNode of this connection.")]
        public MapNode from;

        [Tooltip("The ending MapNode of this connection.")]
        public MapNode to;

        /// <summary>
        /// Constructor to initialize a LineConnection with a LineRenderer, UILineRenderer, and two connected MapNodes.
        /// </summary>
        public LineConnection(LineRenderer lr, UILineRenderer uilr, MapNode from, MapNode to)
        {
            this.lr = lr;
            this.uilr = uilr;
            this.from = from;
            this.to = to;
        }

        /// <summary>
        /// Sets the color of the connection for both LineRenderer and UILineRenderer.
        /// </summary>
        /// <param name="color">The color to apply to the connection.</param>
        public void SetColor(Color color)
        {
            if (lr != null)
            {
                Gradient gradient = lr.colorGradient;
                GradientColorKey[] colorKeys = gradient.colorKeys;

                // Apply the new color to all gradient color keys
                for (int j = 0; j < colorKeys.Length; j++)
                {
                    colorKeys[j].color = color;
                }

                gradient.colorKeys = colorKeys;
                lr.colorGradient = gradient;
            }

            // Set color for UI-based line renderer if available
            if (uilr != null) 
                uilr.color = color;
        }
    }
}
