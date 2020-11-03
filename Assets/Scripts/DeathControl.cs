using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathControl : MonoBehaviour
{
    public ParticleSystem particleSystem1;
   

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject);
        particleSystem1.Play();

    }

}
