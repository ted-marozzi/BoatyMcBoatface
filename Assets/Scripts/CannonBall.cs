// Script for Straight-shooting cannonball, no gravity

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CannonBall : MonoBehaviour
{
    public GameObject createOnDestroy;
    public Rigidbody rb;
    public float velocity;
    public string tagToDamage = "Enemy";
    public bool type1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (type1)
        {
            //this.transform.Translate(velocity * Time.deltaTime);
            rb.position += transform.forward * Time.deltaTime * velocity;

        }
    }

    // Handle collisions
    void OnTriggerEnter(Collider col)
    {
        // Destroy self
        Destroy(this.gameObject);
        GameObject obj = Instantiate(this.createOnDestroy);
        obj.transform.position = this.transform.position;

        // Destroy Object
        
        if (col.gameObject.tag == tagToDamage)
        {
            Destroy(col.gameObject);
        }
        
    }
}
