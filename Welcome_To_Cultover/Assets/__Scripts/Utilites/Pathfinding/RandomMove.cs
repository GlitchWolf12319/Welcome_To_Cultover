using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMove : MonoBehaviour
{
    public NavMeshAgent agent; 
    public float range = 5f; // Radius of the movement area
    public Transform centrePoint; // Center of movement area

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false; // Prevents unwanted Y-axis rotation
        agent.updateUpAxis = false; // Ensures movement stays on the X-Y plane
    }

    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance) // If the agent reached its destination
        {
            Vector2 point;
            if (RandomPoint(centrePoint.position, range, out point)) // Get a random valid point
            {
                Debug.DrawRay(point, Vector2.up, Color.blue, 1.0f); // Visual debugging
                agent.SetDestination(point);
            }
        }
    }

    bool RandomPoint(Vector2 center, float range, out Vector2 result)
    {
        Vector2 randomPoint = center + Random.insideUnitCircle * range; // Random point in a circle
        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) 
        { 
            result = hit.position;
            return true;
        }

        result = Vector2.zero;
        return false;
    }

    // Draws a circle in the Scene view to visualize the movement range
    void OnDrawGizmos()
    {
        if (centrePoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(centrePoint.position, range); // Draws a wireframe circle
        }
    }
}
