using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private float timer = 0f;
    private float spawnDelay = 1.25f;
    public GameObject duckTemplate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > spawnDelay)  {
            float xPos = Random.Range(0.5f, 2.5f);
            
            float yPos = 1.3f;
            float zPos = Random.Range(3.5f, 7f);
            Vector3 pos = new Vector3(xPos, yPos, zPos);

         
            GameObject duck = GameObject.Instantiate<GameObject>(duckTemplate);
            duck.transform.localRotation = this.transform.localRotation;
            duck.transform.localPosition = pos;
            timer = 0;
            
        }
    }
}
