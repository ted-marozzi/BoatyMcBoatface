using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController: MonoBehaviour
{
    // Speed of Movement
    public float moveSpeed = 15f;
    public float rotateSpeed = 15f;
    public float[] cannonOffset = { 0.0f, 1.0f, 5.8f };
    public GameObject cannonTemplate;

    Rigidbody rb;
    float rotate;

    // Key Assignment
    KeyCode forwardKey = KeyCode.W;
    KeyCode leftKey = KeyCode.A;
    KeyCode rightKey = KeyCode.D;
    KeyCode fireKey = KeyCode.Space;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rotate = 0f;
    }


    void Update()
    {

        // Camera Movement
        float df = 0.0f, r = 0.0f;
        if (Input.GetKey(forwardKey)) { df += 1.0f; }
        if (Input.GetKey(leftKey)) { r -= 1.0f; }
        if (Input.GetKey(rightKey)) { r += 1.0f; }

        rb.position += transform.forward * df * Time.deltaTime * moveSpeed;
        rotate += r;
        rb.transform.localEulerAngles = new Vector3(0f, rotate, 0f) * rotateSpeed;

        //Fire
        if (Input.GetKeyDown(fireKey))
        {
            GameObject cannonball = GameObject.Instantiate<GameObject>(cannonTemplate);
            cannonball.transform.localRotation = this.transform.localRotation;
            cannonball.transform.localPosition = this.transform.localPosition + transform.right * cannonOffset[0] + transform.forward * cannonOffset[2] + new Vector3(0.0f, cannonOffset[1], 0.0f);
        }
    }
}
