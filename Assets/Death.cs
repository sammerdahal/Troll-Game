using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject Player;

    void Start()
    {
    }

    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Reset player's position to start point
            Player.transform.position = startPoint.transform.position;

            // Reset gravity to normal if it was inverted
            GravitySwitchPlayer playerScript = other.gameObject.GetComponent<GravitySwitchPlayer>();
            if (playerScript != null)
            {
                playerScript.ResetGravity();
            }
        }
    }
}