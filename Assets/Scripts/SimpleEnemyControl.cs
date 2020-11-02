// Manual control for enemy ships
// For video shooting only
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyControl : MonoBehaviour
{

    public KeyCode fireKey;
    private bool chasePlayer = true;
    private float speed = 10.0f;
    public GameObject player;
    private float timer = 0f;
    Rigidbody rb;
    CannonControl cannon;
    public int seed = 1;

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(seed);
        
        rb = GetComponent<Rigidbody>();
        cannon = GetComponent<CannonControl>();
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer+= Time.deltaTime;
        float step = speed * Time.deltaTime;
        keepFlat();
        // Moves toward player
        if (chasePlayer)
        {
            transform.LookAt(player.transform);
            transform.position += transform.forward * Time.deltaTime * speed;
            
        }
        float var = Random.Range(1,4);
        // Fire Cannon
        if (timer>5.0f + var)
        {
            timer = 0;
            cannon.fireCannon();
        }
    }
    
    void keepFlat() {
        
        Vector3 tmp = transform.localEulerAngles;

        tmp.x = 0;
        tmp.z = 0;

        transform.localEulerAngles = tmp;

    }

}


