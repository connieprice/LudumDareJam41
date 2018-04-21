using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    public int health;
    public int maxHealth;
    public GameManager gm;
    public Text healthText;


	// Use this for initialization
	void Start ()
    {

        maxHealth = 3;
        health = maxHealth;
        healthText.text = health.ToString() + " / 3";

	}

    public void TakeDamage ()
    {
        health--;
        healthText.text = health.ToString() + " / 3";

        if (health <= 0)
        {
            Debug.Log("Dead");
            healthText.text = health.ToString() + " / 3";
            gm.startNextRound();

        }
    }
}
