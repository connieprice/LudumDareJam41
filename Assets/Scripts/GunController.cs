using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    private RaycastHit hit;
    private float reach;
    private bool rayHit;
    private string enemyTag;
    public TurnController tc;
    public LineRenderer lr;
    public Transform endRay;

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
        
        if (!tc.hasShot)
        {

            tc.hasShot = true;

            lr = tc.currentPlayer.gameObject.GetComponent<LineRenderer>();

            lr.SetPosition(0, tc.currentPlayer.transform.position);

            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, reach))
            {
                lr.SetPosition(1, hit.transform.position);
            } else
            {
                lr.SetPosition(1, endRay.position);
            }

            if (!lr.enabled)
            {
                lr.enabled = true;
            }


            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, reach))
            {


                if (hit.transform.gameObject.tag == enemyTag)
                {

                    if (tc.currentPlayer != null)
                    {
                        // Hit enemy
                        Debug.Log("Enemy Hit");
                        // hit.transform.gameObject.GetComponent<FirstPersonController>();
                        GameObject enemy = tc.GetOtherPlayer().gameObject;
                        enemy.GetComponent<HealthManager>().TakeDamage();
                    }
                }
            }
        }
    }
}
