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

    //Sound Effect
    public AudioSource explodeAudio;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        explodeAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move towards its direction
        rb.position += transform.forward * Time.deltaTime * velocity;
    }

    // Handle collisions
    void OnTriggerEnter(Collider col)
    {
        if (col.tag != "ParticleSystem")
        {
            // Play sound
            explodeAudio.PlayOneShot(explodeAudio.clip, 1.0F);

            // Explosion Effect
            GameObject obj = Instantiate(this.createOnDestroy);
            obj.transform.position = this.transform.position;

            // Set invisible, wait for sound clip to finish, then destroy self
            this.GetComponent<Renderer>().enabled = false;
            Destroy(gameObject, explodeAudio.clip.length);

            if (col.gameObject.tag == tagToDamage)  {
                Destroy(col.gameObject);
            }	           
        
        }
    }
}
