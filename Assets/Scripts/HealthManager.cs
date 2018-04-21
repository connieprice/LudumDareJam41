using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    public int health;
    public int maxHealth;
    public GameManager gm;
    public Text healthText;
    private HealthManager enemyHealth;
    public Text enemyHealthText;


    // Use this for initialization
    void Start()
    {

        maxHealth = 3;
        health = maxHealth;
        updateHealth();

    }

    public void TakeDamage()
    {

        health--;
        Debug.Log(health);
        updateHealth();


        if (health <= 0)
        {
            Debug.Log("Dead");
            // updateHealth();
            gm.startNextRound();

        }
    }

    public void updateHealth()
    {
    
            // enemyHealth = getEnemy();
            healthText.text = health.ToString() + " / 3";
            // enemyHealthText.text = enemyHealth.health.ToString() + " / 3";



    }

    public HealthManager getEnemy (){

        if (gm.tc.currentPlayer.gameObject == this.gameObject)
        {
            return gm.tc.GetOtherPlayer().gameObject.GetComponent<HealthManager>();
        }
        else
        {
            return gm.tc.currentPlayer.gameObject.GetComponent<HealthManager>();
        }

    }
}