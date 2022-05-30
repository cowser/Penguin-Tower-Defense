using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class TowerSeeking : shoot
{
    // bool ang�ende vad som ska targetas, anv�nds inte �nnu
    [SerializeField] private bool targetFirst = true;
    // hur l�ngt tornet ser och kan targeta skepp
    [SerializeField][Range(2, 15)] public float Range = 1;
    [SerializeField] public bool spin = true;
    public GameObject gun;
    private bool oneShoot = false;
    private bool hasFound = false;


    void FixedUpdate()
    {

        int which2target = 0;


        LayerMask pirates = LayerMask.GetMask("pirates");

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, Range, pirates);
        //Debug.Log(colliders);


        if (colliders.Length > 0)
        {

            hasFound = true;

            float howFar = colliders[0].GetComponent<FollowPath>().HowFarIn;
            // h�r kollar vi vilken av skeppen som har kommit l�ngst p� banan beroende p� en float som ligger i followath sripten
            for (int i = 0; i < colliders.Length; i++)
            {
                if(howFar < colliders[i].GetComponent<FollowPath>().HowFarIn) { 
                    howFar = colliders[i].GetComponent<FollowPath>().HowFarIn;
                    which2target = i;
                }
            }
            // R�knar ut vikeln mellan tv� positioner allts� skeppets XY position och tornets XY position.

            if (spin == true) { 
                // I samma veva omvandlar vi radianerna till vanliga grader med "(180 / Mathf.PI) *".
                float lookAtAngle = (180 / Mathf.PI) * Mathf.Atan2(colliders[which2target].transform.position.y - transform.position.y, colliders[which2target].transform.position.x - transform.position.x);
                //Sen roterar vi tornet i Z leden eftersom det �r s� man f�r till tv� dimensioell rotation.
                transform.rotation = Quaternion.Euler(0, 0, lookAtAngle); 
            }


            if (oneShoot == false) {
                gun.GetComponent<shoot>().startShooting();
                oneShoot = true;
            }
        }
        if (hasFound == true && colliders.Length == 0) {
            hasFound = false;
            oneShoot = false;
            gun.GetComponent<shoot>().stopShooting();
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Range);
    }



    /*
    int RaysToShoot = 60;
    int RayDistance = 2;
    float angle = 0;
    */

    // Albin Kod


    //string name = colliders[which2target].name;

    /*
    for (int i = 0; i < RaysToShoot; i++)
    {
        float x = Mathf.Sin(angle);
        float y = Mathf.Cos(angle);
        angle += 2 * Mathf.PI / RaysToShoot;
        Vector3 dir = new Vector3(transform.position.x + x * RayDistance, transform.position.y + y * RayDistance, 0);
        RaycastHit2D hit = Physics2D.Raycast(dir, dir);
        Debug.DrawLine(transform.position, dir, Color.green);

    }*/

    // if (hit && name == hit.collider.name)
    //{

    // Debug.DrawLine(transform.position, hit.point, Color.red);


}


