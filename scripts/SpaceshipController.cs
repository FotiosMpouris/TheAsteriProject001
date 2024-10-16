using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public bool throttle => Input.GetKey(KeyCode.Space); 

    public float pitchPower, rollPower, yawPower, enginePower;

    private float activeRoll, activePitch, activeYaw;

    private void Update()
    {
        // Debug statement to check if throttle input is detected
        Debug.Log("Throttle: " + throttle);

        if (throttle)
        {
            // Debug statement to check if the throttle condition is activated
            //Debug.Log("Throttle activated");

            transform.position += transform.forward * enginePower * Time.deltaTime;

            activePitch = Input.GetAxisRaw("Vertical") * pitchPower * Time.deltaTime;
            activeRoll = Input.GetAxisRaw("Horizontal") * rollPower * Time.deltaTime;
            activeYaw = Input.GetAxisRaw("Yaw") * yawPower * Time.deltaTime;

            transform.Rotate(activePitch * pitchPower * Time.deltaTime,
                activeYaw * yawPower * Time.deltaTime,
                -activeRoll * rollPower * Time.deltaTime,
                Space.Self);
        }
        else
        {
            // Debug statement to check if the throttle condition is not activated
           // Debug.Log("Throttle not activated");

            activePitch = Input.GetAxisRaw("Vertical") * (pitchPower/2) * Time.deltaTime;
            activeRoll = Input.GetAxisRaw("Horizontal") * (rollPower/2) * Time.deltaTime;
            activeYaw = Input.GetAxisRaw("Yaw") * (yawPower/2) * Time.deltaTime;

            transform.Rotate(activePitch * pitchPower * Time.deltaTime,
                activeYaw * yawPower * Time.deltaTime,
                -activeRoll * rollPower * Time.deltaTime,
                Space.Self);
        }
    }
}
