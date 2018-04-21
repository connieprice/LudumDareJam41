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

        reach = Mathf.Infinity;
        enemyTag = "Player";

    }

    // Update is called once per frame
    void Update()
    {
        if (tc.currentPlayer != null && this.gameObject == tc.currentPlayer.gameObject)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }

    }

    private void Shoot (){

        Debug.Log(tc.hasShot);


        if (!tc.hasShot)
        {

            tc.hasShot = true;
            Debug.Log("111");

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, reach))
            {
                Debug.Log("222");

                if (hit.transform.gameObject.tag == enemyTag)
                {
                    Debug.Log("333");

                    if (tc.currentPlayer != null)
                    {

                        Debug.Log("444");

                        // Hit enemy
                        Debug.Log("Kaboom");
                        // hit.transform.gameObject.GetComponent<FirstPersonController>();
                        GameObject enemy = tc.GetOtherPlayer().gameObject;
                        enemy.GetComponent<HealthManager>().TakeDamage();
                    }
                }
            }
        }
    }
}
