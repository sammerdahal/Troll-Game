using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject target; // Assign the player GameObject manually
    public float yOffset = 1f; // Optional offset for better framing

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // Follow the player's position with an optional Y-offset
            transform.position = new Vector3(
                target.transform.position.x,
                target.transform.position.y + yOffset,
                -10
            );
        }
        else
        {
            Debug.LogWarning("Target is not assigned to the camera.");
        }
    }
}
