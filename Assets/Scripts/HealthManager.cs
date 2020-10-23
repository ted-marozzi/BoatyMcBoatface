﻿// Health Manager Script for the Player Ship
// Might be modified later to allow use for enemy ship as well

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxHP = 10;
    public int currentHP = 0;
    string[] enemyTags = { "Enemy" } ;
    string cannonTag = "Cannonball";

    public HealthBar healthBar;
    public int damageByCollision;
    public int damageByCannon;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        healthBar.SetHealth(currentHP);
    }

    // Update is called once per frame
    void Update()
    {
        // Handles Gameover
        if (currentHP <= 0)
        {
            // Show Gameover screen
            Debug.Log("GAME OVER");
        }

        // TESTING ONLY start
        // Press P to due damage to player
        if (Input.GetKeyDown(KeyCode.P))
        {
            DamagePlayer(1);
        }
        // TESTING ONLY end

    }

    // Used collisionExit to ensure there will only be one count per collision
    void OnCollisionExit(Collision col) {

        // Handles collision with enemy
        foreach(string tag in enemyTags)
        {
            if (col.gameObject.tag == tag)
            {
                DamagePlayer(damageByCollision);
            }
        }

        // Handles collision with cannonball (get hit by enemy)
        if (col.gameObject.tag == cannonTag)
        {
            DamagePlayer(damageByCannon);
        }
    }

    public void DamagePlayer(int damage)
    {
        currentHP -= damage;
        healthBar.SetHealth(currentHP);
    }
}
