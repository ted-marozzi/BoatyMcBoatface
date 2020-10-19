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

    //Health bar settings
    public Vector2 healthBarPos = new Vector2(20, 40);
    public Vector2 healthBarSize = new Vector2(60, 20);
    Texture2D healthBarTexture;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        UpdateHP(currentHP);
        //Health Bar Initialize
        healthBarTexture = new Texture2D(1, 1, TextureFormat.RGB24, false);
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
        //UpdateHP(currentHP);

        //TESTING ONLY start
        if (Input.GetKeyDown(KeyCode.P))
        {
            DamagePlayer(1);
        }
        //TESTING ONLY end

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
        textbox.text = hp + "/" + maxHP;
    }

    //Show Health bar
    void OnGUI()
    {
        GUI.BeginGroup(new Rect(healthBarPos.x, healthBarPos.y, healthBarSize.x, healthBarSize.y));
        // draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, healthBarSize.x * currentHP / maxHP, healthBarSize.y));
        GUI.Box(new Rect(0, 0, healthBarSize.x, healthBarSize.y), healthBarTexture);
        GUI.EndGroup();

        GUI.EndGroup();
    }
}
