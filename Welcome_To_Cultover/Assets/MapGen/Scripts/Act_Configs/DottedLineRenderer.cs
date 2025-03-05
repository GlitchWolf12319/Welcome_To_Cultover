using UnityEngine;

namespace Map
{
    // This class adjusts the texture scale of a LineRenderer to create a dotted line effect.
    public class DottedLineRenderer : MonoBehaviour
    {
        [Tooltip("Enable this to update the texture scale dynamically every frame.")]
        public bool scaleInUpdate = false;

        private LineRenderer lR; // Reference to the LineRenderer component
        private Renderer rend;   // Reference to the Renderer component

        private void Start()
        {
            // Scale the material once when the object starts
            ScaleMaterial();

            // Enable Update method only if scaleInUpdate is true
            enabled = scaleInUpdate;
        }

        /// <summary>
        /// Scales the material texture based on the length of the LineRenderer.
        /// Call this method after modifying the line positions.
        /// </summary>
        public void ScaleMaterial()
        {
            lR = GetComponent<LineRenderer>(); // Get the LineRenderer component
            rend = GetComponent<Renderer>();   // Get the Renderer component

            // Adjust the texture scale to match the line's length
            rend.material.mainTextureScale = new Vector2(
                Vector2.Distance(lR.GetPosition(0), lR.GetPosition(lR.positionCount - 1)) / lR.widthMultiplier,
                1
            );
        }

        private void Update()
        {
            // If scaleInUpdate is true, continuously update the texture scale
            rend.material.mainTextureScale = new Vector2(
                Vector2.Distance(lR.GetPosition(0), lR.GetPosition(lR.positionCount - 1)) / lR.widthMultiplier,
                1
            );
        }
    }
}
