// This script is used for main camera to track player ship and other camera functions

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        // Move with playership along z-axis
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, player.transform.localPosition.z);
    }
}
