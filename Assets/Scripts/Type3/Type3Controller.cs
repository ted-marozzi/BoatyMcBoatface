// COMP30019 Graphics and Interaction Project 1, September 2020
// Controller for "flight-simulator" style camera and terrain re-generation

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Type3Controller : MonoBehaviour
{
    // Speed of Movement
    public float moveSpeed = 15;
    public float rotateSpeed = 1;
    public float[] cannonOffset = { 0.0f, 1.0f, 5.8f };
    public GameObject cannonTemplate;

    Rigidbody rb;
    float yaw = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {

        // Camera Movement
        float df = 0.0f, r = 0.0f;
        if (Input.GetKey(KeyCode.W)) { df += 1.0f; }
        if (Input.GetKey(KeyCode.A)) { r -= 1.0f; }
        if (Input.GetKey(KeyCode.D)) { r += 1.0f; }
        yaw += r;

        rb.position += transform.forward * df * Time.deltaTime * moveSpeed;
        rb.transform.localEulerAngles = new Vector3(0f, yaw, 0f) * rotateSpeed;

        //Fire
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject cannonball = GameObject.Instantiate<GameObject>(cannonTemplate);
            cannonball.transform.localRotation = this.transform.localRotation;
            cannonball.transform.localPosition = this.transform.localPosition + transform.right * cannonOffset[0] + transform.forward * cannonOffset[2] + new Vector3(0.0f, cannonOffset[1], 0.0f);
        }

    }
}
