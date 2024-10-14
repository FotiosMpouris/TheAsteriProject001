using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSkybox : MonoBehaviour
{
    public float rotationSpeed = 1f; // Speed of rotation

    void Update()
    {
        // Get the main camera's skybox material
        Material skyboxMaterial = RenderSettings.skybox;

        // Calculate the rotation angle based on time and rotation speed
        float rotationAngle = Time.time * rotationSpeed;

        // Set the rotation to the skybox material
        skyboxMaterial.SetFloat("_Rotation", rotationAngle);
    }
}
