using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MoveOutSideOfRange : MonoBehaviour
{
    public NavMeshAgent agent;
    public float range = 5f; // Inner radius (avoid picking points here)
    public float minDistanceOutside = 2f; // Minimum extra distance outside the range
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
            if (RandomPointOutside(centrePoint.position, range, minDistanceOutside, out point)) // Get a random valid point
            {
                Debug.DrawRay(point, Vector2.up, Color.blue, 1.0f); // Visual debugging
                agent.SetDestination(point);
            }
        }
    }

    bool RandomPointOutside(Vector2 center, float innerRange, float minOutside, out Vector2 result)
    {
        for (int i = 0; i < 10; i++) // Try up to 10 times to find a valid point
        {
            Vector2 direction = Random.insideUnitCircle.normalized; // Get a random direction
            float distance = innerRange + minOutside + Random.Range(0, minOutside * 2); // Pick a distance outside range
            Vector2 randomPoint = center + direction * distance; // Move along the direction

            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) 
            { 
                result = hit.position;
                return true;
            }
        }

        result = Vector2.zero;
        return false;
    }

    // Draws a wireframe circle for reference
    void OnDrawGizmos()
    {
        if (centrePoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(centrePoint.position, range); // Inner range (avoid this area)

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(centrePoint.position, range + minDistanceOutside); // Approximate outer range
        }
    }
}