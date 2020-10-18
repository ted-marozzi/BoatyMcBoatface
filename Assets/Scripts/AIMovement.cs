using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AIMovement : MonoBehaviour
{

    private float moveForce = 10f, chanceDirChange = 0.25f;
    public int seed = 1;


    private int rotDir = 1;
    private float maxDistWall = 75f, rotScale = 0.25f, timer = 0f;
    
    
    

    private new Rigidbody rigidbody;
    private Vector3 moveDir;
    public LayerMask toAvoid;
    private System.Random ran;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
       
        ran = new System.Random(seed);
        
    }

    // Update is called once per frame
    void Update()
    {
        

        timer += Time.deltaTime;

        if(timer > 1f)
        {
            timer = 0f;
            double ranDouble = ran.NextDouble();

            //Debug.Log( "Timer "  + timer + "Next double " + ranDouble + " Chance " + chanceDirChange);

            if( ranDouble < chanceDirChange)
            {
                rotDir = -1;
                Debug.Log("Hi this is less than");
            } else if (ranDouble >= chanceDirChange && ranDouble <= 1 - chanceDirChange) {
                rotDir = 0;
            } else {
                rotDir = 1;
            }
            
        }

        keepFlat();
        
        if(Physics.Raycast(transform.position, transform.forward, maxDistWall, toAvoid))
        {
            Debug.Log("Trying to avoid wall");
            transform.Rotate(0, rotScale, 0);
        } else {
            transform.Rotate(0, rotScale*rotDir, 0);
        } 

        moveDir = transform.forward;
        rigidbody.velocity = moveDir*moveForce;

        
    }

    void keepFlat() {
        
        Vector3 tmp = transform.localEulerAngles;

        tmp.x = 0;
        tmp.z = 0;

        transform.localEulerAngles = tmp;

    }


    
}
