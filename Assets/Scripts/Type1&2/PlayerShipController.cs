// Player ship Controller
// WASD Move, related to camera.
// Cannon Shooting out in Straight line, no Gravity

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 15f;
    public float rotateSpeed = 500f;
    public float[] cannonOffset = { 0.0f, 1.0f, 5.8f };

    // Moving direction relative to cemara orientation
    Vector3 forwardDirection = new Vector3(0.0f, 0.0f, 1.0f);
    Vector3 rightDirection = new Vector3(1.0f, 0.0f, 0.0f);

    Vector3 movementDirection;

    public GameObject cannonTemplate;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move
        float df = 0.0f, dr = 0.0f;
        if (Input.GetKey(KeyCode.W)) { df += 1.0f; }
        if (Input.GetKey(KeyCode.S)) { df -= 1.0f; }
        if (Input.GetKey(KeyCode.D)) { dr += 1.0f; }
        if (Input.GetKey(KeyCode.A)) { dr -= 1.0f; }
        movementDirection = ((forwardDirection * df) + (rightDirection * dr)).normalized;

        // Rotate towards its direction of movement
        this.transform.localRotation = Quaternion.LookRotation(movementDirection);
        
        rb.position += movementDirection * Time.deltaTime * moveSpeed;

        //Fire
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject cannonball = GameObject.Instantiate<GameObject>(cannonTemplate);
            cannonball.transform.localRotation = this.transform.localRotation;
            cannonball.transform.localPosition = this.transform.localPosition + transform.right * cannonOffset[0] + transform.forward * cannonOffset[2] + new Vector3(0.0f, cannonOffset[1], 0.0f);
        }
    }
}
