// This script is used for main camera to track player ship 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    public float offsetX = 0;
    public float offsetZ = -35;

    // Update is called once per frame
    void Update()
    {
        // Move with playership
        this.transform.localPosition = new Vector3(
            player.transform.localPosition.x + offsetX, 
            this.transform.localPosition.y, 
            player.transform.localPosition.z + offsetZ
            );
    }
}
