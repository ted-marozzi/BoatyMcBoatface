// This script is for managing lv2 pirate ships
// It gives 'level clear' when all enemy ships are defeated

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagement : MonoBehaviour
{
    public GameObject LevelControl;

    public GameObject SkullSprite1;
    public GameObject SkullSprite2;
    public GameObject SkullSprite3;

    void Update()
    {
        if (transform.childCount == 2)
        {
            SkullSprite1.SetActive(false);
        }
        if (transform.childCount == 1)
        {
            SkullSprite2.SetActive(false);
        }
        if (transform.childCount == 0)
        {
            SkullSprite3.SetActive(false);
            LevelControl.GetComponent<LevelGeneralControl>().LevelClear();
        }
    }
}
