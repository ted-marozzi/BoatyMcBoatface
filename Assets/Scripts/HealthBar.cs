//This script is originally from https://weeklyhow.com/how-to-make-a-health-bar-in-unity/
//Modified by Bixin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public HealthManager playerHealth;

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthManager>();
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = playerHealth.maxHP;
        healthBar.value = playerHealth.maxHP;
    }

    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }
}
