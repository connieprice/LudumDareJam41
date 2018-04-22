using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    private RaycastHit hit;
    private string enemyTag;
    private Vector3 direction;
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

            direction = Vector3.forward;
            direction.y = direction.y + (endOfRay.transform.position.y - tc.currentPlayer.gameObject.transform.position.y);
            float tempY = direction.y / Vector3.Magnitude(endOfRay.transform.position - tc.currentPlayer.gameObject.transform.position);
            direction.y = tempY;

            if (Physics.Raycast(tc.currentPlayer.gameObject.transform.position, transform.TransformDirection(direction), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(tc.currentPlayer.gameObject.transform.position, transform.TransformDirection(direction), Color.green, 100f);
                // Do stuff for hitting any obj
                lr.SetPosition(1, hit.point);

                if (hit.transform.gameObject.tag == enemyTag)
                {
                    if (tc.currentPlayer != null)
                    {
                        // Deal damage
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