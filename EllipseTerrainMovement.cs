using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllipseTerrainMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f; // Speed of movement
    [SerializeField] float majorRadius = 10f; // Major radius of the ellipse
    [SerializeField] float minorRadius = 5f; // Minor radius of the ellipse
    [SerializeField] float defaultHeightAboveTerrain = 5f; // Default height above the terrain
    [SerializeField] float altitudeLerpSpeed = 5f; // Speed of altitude adjustment
    [SerializeField] float rollSpeed = 5f; // Speed of rolling adjustment
    [SerializeField] float rollBufferAngle = 5f; // Buffer zone around desired roll angle
    [SerializeField] float maxTerrainHeightForRoll = 10f; // Maximum terrain height for initiating roll

    private Vector3 center; // Center point of the ellipse
    private float currentAltitude; // Current altitude of the ship
    private float currentRollAngle; // Current roll angle of the ship

    // Counter and threshold for higher altitude
    private int altitudeChangeCounter = 0;
    private int altitudeChangeThreshold = 100; // Change this value as needed for frequency of altitude change

    void Start()
    {
        // Calculate the center point of the ellipse based on the terrain
        center = transform.position;
        center.y = Terrain.activeTerrain.SampleHeight(center) + defaultHeightAboveTerrain;

        // Initialize current altitude and roll angle
        currentAltitude = center.y;
        currentRollAngle = 0f;
    }

    void Update()
    {
        // Calculate the position of the spaceship along the elliptical path
        float t = Time.time * speed;
        float x = center.x + Mathf.Cos(t) * majorRadius; // X position
        float z = center.z + Mathf.Sin(t) * minorRadius; // Z position

        // Set the position of the spaceship
        transform.position = new Vector3(x, currentAltitude, z);

        // Calculate the direction of movement
        Vector3 direction = new Vector3(-Mathf.Sin(t), 0f, Mathf.Cos(t)).normalized;

        // Rotate the spaceship to face the direction of movement
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 180f * Time.deltaTime);

        // Adjust altitude to maintain height above terrain
        float terrainHeight = Terrain.activeTerrain.SampleHeight(transform.position);
        float targetAltitude = terrainHeight + defaultHeightAboveTerrain;

        // Check if it's time to increase altitude
        if (altitudeChangeCounter >= altitudeChangeThreshold)
        {
            targetAltitude += 20f; // Increase altitude by 20 units
            altitudeChangeCounter = 0; // Reset counter
        }
        else
        {
            altitudeChangeCounter++; // Increment counter
        }

        // Smoothly adjust altitude
        currentAltitude = Mathf.Lerp(currentAltitude, targetAltitude, altitudeLerpSpeed * Time.deltaTime);

        // Check if roll is necessary based on terrain height
        if (terrainHeight > maxTerrainHeightForRoll)
        {
            // Set desired roll angle based on terrain slope
            float desiredRollAngle = Mathf.Clamp(terrainHeight - center.y, -45f, 45f);

            // Smoothly adjust roll angle
            currentRollAngle = Mathf.MoveTowards(currentRollAngle, desiredRollAngle, rollSpeed * Time.deltaTime);
        }
        else
        {
            // Reset roll angle if terrain height is within threshold
            currentRollAngle = Mathf.MoveTowards(currentRollAngle, 0f, rollSpeed * Time.deltaTime);
        }

        // Apply roll angle to spaceship rotation
        Vector3 currentEulerAngles = transform.rotation.eulerAngles;
        currentEulerAngles.z = currentRollAngle;
        transform.rotation = Quaternion.Euler(currentEulerAngles);
    }
}