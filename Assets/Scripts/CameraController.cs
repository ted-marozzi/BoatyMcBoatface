using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float yawSpeed = 15f;
    public float pitchSpeed = 15f;

    Rigidbody rb;
    float[] yawLimit = { -90f, 90f };
    float[] pitchLimit = { -60f, 60f };
    float pitch = 0.0f;
    float yaw = 0.0f;
    float initialPitch = 32.5f; //65 degree around x-axis


    // Start is called before the first frame update
    void Start()
    {
        pitch = initialPitch;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        pitch -= Input.GetAxis("Mouse Y");
        yaw += Input.GetAxis("Mouse X");

        rb.transform.localEulerAngles = new Vector3(pitch * pitchSpeed, yaw * yawSpeed, 0f);
    }
}
