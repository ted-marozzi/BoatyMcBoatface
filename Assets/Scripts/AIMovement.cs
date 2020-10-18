using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AIMovement : MonoBehaviour
{

    private float moveForce = 10f, chanceDirChange = 0.2f;
    public int seed = 1;


    private int rotDir = 1;
    private float maxDistWall = 75f, rotScale = 0.1f, timer = 0f;
    
    
    

    private Rigidbody rigidbody;
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
                rotDir = rotDir*-1;
            }
            
        }
        
        
        
        
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


    
}
