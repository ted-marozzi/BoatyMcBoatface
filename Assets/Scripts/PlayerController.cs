using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Controller
    public float moveSpeed = 15f;
    public float rotateSpeed = 15f;
    Rigidbody rb;
    float rotate;
    CannonControl cannon;

    // Key Assignment
    KeyCode forwardKey = KeyCode.W;
    KeyCode leftKey = KeyCode.A;
    KeyCode rightKey = KeyCode.D;
    KeyCode fireKey = KeyCode.Space;

    bool gameOn;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cannon = GetComponent<CannonControl>();
        rotate = 0f;
        gameOn = true;
    }


    void Update()
    {
        
        // Movement
        float df = 0.0f, r = 0.0f;
        if (Input.GetKey(forwardKey)) { df += 1.0f; }
        if (Input.GetKey(leftKey)) { r -= 1.0f; }
        if (Input.GetKey(rightKey)) { r += 1.0f; }
        rotate += r;
        if (gameOn)
        {
            rb.position += transform.forward * df * Time.deltaTime * moveSpeed;
            rb.transform.localEulerAngles = new Vector3(0f, rotate, 0f) * rotateSpeed;
        }
        

        // Fire Cannon
        if (Input.GetKeyDown(fireKey) && gameOn)
        {
            cannon.fireCannon();
        }
    }

    public void playerControlOff()
    {
        this.gameOn = false;
    }

    public void playerControlOn()
    {
        this.gameOn = true;
    }
}
