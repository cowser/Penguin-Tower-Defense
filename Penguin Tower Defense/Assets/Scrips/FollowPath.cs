using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{

    public float HowFarIn = 0;

    int currentpos = 1;
    [SerializeField][Range(1, 10)]float speed = 2f;
    bool ded = false;
    [SerializeField]Transform[] a;
    GameObject temp;

    void Start() {
        temp = GameObject.FindGameObjectWithTag("Path");
        a = temp.GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        /*if (ded == false&&gameObject.transform.position == a[currentpos].position) {
            currentpos++;
        }*/

        if (currentpos == a.Length-1) {
            EnemyController ec = gameObject.GetComponent<EnemyController>();
            ec.DealDamage();
            //Debug.Log("EnemyIsDead");
            ded = true;
            Destroy(gameObject);
        }
        else {
            if(transform.position.x == a[currentpos].position.x && transform.position.y == a[currentpos].position.y)
            {
                currentpos++;
                rotera();
            }

            HowFarIn += speed * Time.deltaTime;
            gameObject.transform.position = Vector2.MoveTowards(transform.position, a[currentpos].position, speed * Time.deltaTime);

        }
       
        
    }
    void rotera() {
        float dy = a[currentpos].position.y - transform.position.y;
        float dx = a[currentpos].position.x - transform.position.x;
        Vector2 dir = new Vector2(dx, dy);
        // The step size is equal to speed times frame time.
        float singleStep = 2000 * Time.deltaTime;

        Quaternion targetrot = Quaternion.LookRotation(Vector3.forward, dir);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetrot, singleStep);
    }
    
}
