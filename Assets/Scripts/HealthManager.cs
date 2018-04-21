using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HealthManager : NetworkBehaviour {

	[SyncVar]
	public int health;
	public int maxHealth;
	//public GameManager gm;

	// Use this for initialization
	void Start ()
	{

		maxHealth = 3;
		health = maxHealth;

	}

	public void TakeDamage ()
	{
		health--;

		if (health <= 0)
		{
			Debug.Log("Dead");
			//gm.startNextRound();

		}
	}
}
