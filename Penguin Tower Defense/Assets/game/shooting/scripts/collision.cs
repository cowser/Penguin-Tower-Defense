using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OWS.ObjectPooling;
public class collision : MonoBehaviour
{
    int dmg, affect;
    private isDead ship;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "pirate") {
            dmg = gameObject.GetComponent<bulletVar>().dmg;
            affect = gameObject.GetComponent<bulletVar>().affect;
            ship = collision.gameObject.GetComponent<isDead>();

            if (ship.immunity == affect) {
                dmg = 0;
            }
            else if (ship.superEffective == affect) {
                dmg *= 2;
            }
            ship.hp -= dmg;
            
            Debug.Log("Damage taken: " + dmg + " and affect: " + affect + "HP left: " + ship.hp);
            gameObject.SetActive(false);
        }
    }
}
