// Health Manager Script for the Player Ship
// Might be modified later to allow use for enemy ship as well

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxHP = 10;
    public int currentHP = 0;
    public Text textbox;
    string[] enemyTags = { "Enemy" };

    //public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        UpdateHP(currentHP);
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
        UpdateHP(currentHP);
    }

    // Used collisionExit to ensure there will only be one count per collision
    void OnCollisionExit(Collision col) {
        // Handles collision with enemy
        foreach(string tag in enemyTags)
        {
            if (col.gameObject.tag == tag)
            {
                DamagePlayer(1);

                Destroy(col.gameObject); //Destroy the rubber duck, only for testing
            }
        }
        
    }


    public void DamagePlayer(int damage)
    {
        currentHP -= damage;

        //healthBar.SetHealth(curHealth);
    }

    // Returns HP
    public int GetHP()
    {
        return currentHP;
    }

    // Prints hp to textbox, will change to hp bar later.
    void UpdateHP(int hp)
    {
        textbox.text = "HP: " + hp;
    }
}
