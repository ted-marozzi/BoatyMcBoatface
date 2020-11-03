using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedBoat : MonoBehaviour
{


	public GameObject boat;
    public ParticleSystem water1;
    public ParticleSystem water2;
    public ParticleSystem smoke;


    int health; 

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        health = boat.GetComponent<HealthManager>().currentHP;
 
            if (health <= 8)
            {
                smoke.Play();
          

            }
            if (health <= 6)
            {
               water1.Play();
            
            }
            if (health <= 5)
            {

                water2.Play();
            }

    }
}
