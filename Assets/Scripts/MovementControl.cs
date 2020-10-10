// Type 1 Player ship
// WASD Move Control
// Cannon Shooting out in Straight line, no Gravity

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 15f;
    public float rotateSpeed = 15f;
    public bool fire_type1;
    float cannonOffsetForward = 5.80f;
    float cannonOffsetUp = 1.0f;

    float rotation = 0.0f;

    public GameObject cannonTemplate;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Rotation
        if (Input.GetKey(KeyCode.A)) { rotation -= 1.0f; }
        if (Input.GetKey(KeyCode.D)) { rotation += 1.0f; }
        rb.transform.localEulerAngles = new Vector3(0f, rotation, 0f) * rotateSpeed;

        //Move forward
        float f = 0.0f;
        if (Input.GetKey(KeyCode.W)) { f += 1.0f; }
        rb.position += transform.forward * f * Time.deltaTime * moveSpeed;

        //Fire
        if (Input.GetKeyDown(KeyCode.Space) & fire_type1)
        {
            GameObject cannonball = GameObject.Instantiate<GameObject>(cannonTemplate);
            cannonball.transform.localRotation = this.transform.localRotation;
            cannonball.transform.localPosition = transform.forward * cannonOffsetForward + this.transform.localPosition + new Vector3(0.0f,cannonOffsetUp,0.0f);
        }
    }
}
