using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class EngineAcceleration : MonoBehaviour
{
    public ParticleSystem[] particleSystems; // Reference to the particle systems
    public AudioSource engineSound; // Reference to the audio source

    public float minInterval = 0.5f; // Minimum interval between turning on/off particle systems
    public float maxInterval = 2f; // Maximum interval between turning on/off particle systems

    private float nextToggleTime; // Time for the next toggle

    void Start()
    {
        // Initialize the next toggle time
        nextToggleTime = Time.time + Random.Range(minInterval, maxInterval);

        // Play the engine sound
        engineSound.Play();
    }

    void Update()
    {
        // Check if it's time to toggle the particle systems and audio source
        if (Time.time >= nextToggleTime)
        {
            // Toggle each particle system
            foreach (ParticleSystem ps in particleSystems)
            {
                if (ps.isPlaying)
                {
                    ps.Stop(); // Turn off the particle system
                }
                else
                {
                    ps.Play(); // Turn on the particle system
                }
            }

            // Toggle the audio source
            if (engineSound.isPlaying)
            {
                engineSound.Stop(); // Turn off the audio source
            }
            else
            {
                engineSound.Play(); // Turn on the audio source
            }

            // Set the next toggle time
            nextToggleTime = Time.time + Random.Range(minInterval, maxInterval);
        }
    }
}
