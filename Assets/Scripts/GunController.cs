using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    private RaycastHit hit;
    private string enemyTag;
    public TurnController tc;
    public LineRenderer lr;
    public Transform endOfRay;

    // Use this for initialization
    void Start() {
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

    private void Shoot ()
    {
        if (tc.hasShot == false)
        {
            tc.hasShot = true;

            lr = tc.currentPlayer.gameObject.GetComponent<LineRenderer>();
            lr.SetPosition(0, tc.currentPlayer.transform.position);

            if (lr.enabled == false)
            {
                lr.enabled = true;
            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                // Do stuff for hitting any obj

                lr.SetPosition(1, hit.transform.position);

                if (hit.transform.gameObject.tag == enemyTag)
                {
                    if (tc.currentPlayer != null)
                    {
                        // Deal damage
                        Debug.Log("Enemy Hit");
                        GameObject enemy = tc.GetOtherPlayer().gameObject;
                        enemy.GetComponent<HealthManager>().TakeDamage();
                    }
                }
            } 
            else
            {
                // Do stuff for missing all objs
                lr.SetPosition(1, endOfRay.transform.position);
            }
        }
    }
}
