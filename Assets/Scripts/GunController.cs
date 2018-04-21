using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    private RaycastHit hit;
    private float reach;
    private bool rayHit;
    private string enemyTag;
    public TurnController tc;

    // Use this for initialization
    void Start() {

        reach = 200f;
        enemyTag = "Player";

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

    }

    private void Shoot (){

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, reach))
        {
            if (hit.transform.gameObject.tag == enemyTag)
            {
                if (this.gameObject == tc.currentPlayer.gameObject)
                {
                    // Hit enemy
                    Debug.Log("Kaboom");

                }
            }
        }

    }

}
