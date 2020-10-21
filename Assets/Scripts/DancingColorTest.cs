using UnityEngine;

public class DancingColorTest : MonoBehaviour
{
    Light lt;

    //[Range(0, 256)]
   public float max = 256;

    //[Range(0, 256)]
    public float min = 0;

    [Range(0, 256)]
    public int speed = 60;

    float interval = 60.0f;

   
    void Start()
    {
        lt = GetComponent<Light>();

        //max = Mathf.Max(lt.color.r, Mathf.Max(lt.color.g, lt.color.b));
        //min = Mathf.Min(lt.color.r, Mathf.Min(lt.color.g, lt.color.b));
    }

    // Darken the light completely over a period of 2 seconds.
    void Update()
    {



        if (interval > 0)
        {
            interval -= Time.deltaTime * speed;
        }
        else
        {
            interval = 60.0f;
            lt.color = new Color(Random.Range(min,max), Random.Range(min, max), Random.Range(min, max), 1) * Time.deltaTime;
    
        } 


    }
        
}