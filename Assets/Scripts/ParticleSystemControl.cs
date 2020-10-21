using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemControl : MonoBehaviour
{
    public float lifeTime;

    void Update()
    {
        // Make particle system self-destruct after playing
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
