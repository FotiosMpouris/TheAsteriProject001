using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainAnalysis : MonoBehaviour
{
    public float waypointSpacing = 5f; // Spacing between generated waypoints
    public LayerMask terrainLayerMask; // Layer mask for the terrain

    // Method to generate waypoints along the terrain
    public Vector3[] GenerateFlightPath(Transform shipTransform, float desiredHeight)
    {
        // Get the terrain data
        Terrain terrain = Terrain.activeTerrain;
        TerrainData terrainData = terrain.terrainData;

        // Calculate the number of waypoints based on terrain size and spacing
        int numWaypointsX = Mathf.CeilToInt(terrainData.size.x / waypointSpacing);
        int numWaypointsZ = Mathf.CeilToInt(terrainData.size.z / waypointSpacing);
        int totalWaypoints = numWaypointsX * numWaypointsZ;

        // Initialize the array to hold the waypoints
        Vector3[] waypoints = new Vector3[totalWaypoints];

        // Iterate through the terrain and generate waypoints
        int index = 0;
        for (int x = 0; x < numWaypointsX; x++)
        {
            for (int z = 0; z < numWaypointsZ; z++)
            {
                // Calculate the position of the waypoint
                float posX = x * waypointSpacing;
                float posZ = z * waypointSpacing;
                Vector3 waypointPos = new Vector3(posX, desiredHeight, posZ);

                // Raycast downward to find the terrain height at this point
                RaycastHit hit;
                if (Physics.Raycast(waypointPos + Vector3.up * 1000f, Vector3.down, out hit, Mathf.Infinity, terrainLayerMask))
                {
                    waypointPos.y = hit.point.y;
                }

                // Add the waypoint to the array
                waypoints[index] = waypointPos;
                index++;
            }
        }

        return waypoints;
    }
}
