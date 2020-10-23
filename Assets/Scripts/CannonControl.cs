// This script is used to control cannons on player boat or enemy

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour
{
    // Cannon parameters
    public Vector3 cannonOffset;
    public GameObject cannonTemplate;
    public float fireInterval;
    float timecount;

    // Sound Effect
    AudioSource fireAudio;

    // Particle Effect
    public GameObject fireEffect;

    // Start is called before the first frame update
    void Start()
    {
        fireAudio = GetComponent<AudioSource>();
        timecount = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timecount += Time.deltaTime;
    }

    public void fireCannon()
    {
        if(timecount > fireInterval)
        {
            Vector3 cannonPos = this.transform.localPosition + (transform.right * cannonOffset.x) + (transform.up * cannonOffset.y) + (transform.forward * cannonOffset.z);

            //Effects
            fireAudio.PlayOneShot(fireAudio.clip, 0.7F);
            GameObject obj = Instantiate(this.fireEffect);
            obj.transform.SetParent(this.transform);
            obj.transform.position = cannonPos;

            //Create Cannonball
            GameObject cannonball = GameObject.Instantiate<GameObject>(cannonTemplate);
            cannonball.transform.localRotation = this.transform.localRotation;
            cannonball.transform.localPosition = cannonPos;

            timecount = 0.0f;
        }
    }
}
