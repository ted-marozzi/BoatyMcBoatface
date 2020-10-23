// Manual control for enemy ships
// For video shooting only
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyControl : MonoBehaviour
{

    public KeyCode fireKey;
    public bool chasePlayer;
    public float speed = 0.0f;
    public GameObject player;

    Rigidbody rb;
    CannonControl cannon;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cannon = GetComponent<CannonControl>();
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        // Moves toward player
        if (chasePlayer)
        {
            transform.LookAt(player.transform);
            rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Force);
        }

        // Fire Cannon
        if (Input.GetKeyDown(fireKey))
        {
            cannon.fireCannon();
        }
    }
}


