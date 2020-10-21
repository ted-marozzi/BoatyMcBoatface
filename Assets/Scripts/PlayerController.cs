using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Movement
    public float moveSpeed = 15f;
    public float rotateSpeed = 15f;
    Rigidbody rb;
    float rotate;

    // Cannon
    public Vector3 cannonOffset;
    public GameObject cannonTemplate;
    public float fireInterval;
    float timecount;


    // Key Assignment
    KeyCode forwardKey = KeyCode.W;
    KeyCode leftKey = KeyCode.A;
    KeyCode rightKey = KeyCode.D;
    KeyCode fireKey = KeyCode.Space;

    //Sound Effect
    AudioSource fireAudio;

    //Particle Effect
    public GameObject fireEffect;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rotate = 0f;
        fireAudio = GetComponent<AudioSource>();
        timecount = 0.0f;
    }


    void Update()
    {
        timecount += Time.deltaTime;

        // Movement
        float df = 0.0f, r = 0.0f;
        if (Input.GetKey(forwardKey)) { df += 1.0f; }
        if (Input.GetKey(leftKey)) { r -= 1.0f; }
        if (Input.GetKey(rightKey)) { r += 1.0f; }
        rb.position += transform.forward * df * Time.deltaTime * moveSpeed;
        rotate += r;
        rb.transform.localEulerAngles = new Vector3(0f, rotate, 0f) * rotateSpeed;

        // Fire Cannon
        if (Input.GetKeyDown(fireKey) && timecount > fireInterval)
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
