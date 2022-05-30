using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    
    public GameObject tower;
    public GameObject RangeView;
    [SerializeField][Range(1f, 3f)] float TowerFootprint = 2f;
    public bool isDragging = false;
    public bool SafeToPlace = false;
    [SerializeField] public int towerCost = 50;

    private void Awake()
    {
        RangeView.SetActive(false);
    }


    private void Start()
    {
        isDragging = true;
        RangeView.SetActive(true);
        RangeView.GetComponent<RangeScript>().enabled = true;
    }


    /*
    public void OnMouseDown()
    {
        if(isDragging == false) { 
            if (gameObject.GetComponent<DragAndDrop>().enabled == true)
            {
                RangeView.SetActive(true);

                //RangeView.GetComponent<RangeScript>().enabled = true;
                Instantiate(tower, transform.position, Quaternion.identity);
                isDragging = true;
            }
        }
    }
    */


    public void OnMouseUp()
    {


    }

    void FixedUpdate()
    {
        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);

            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, TowerFootprint);

            SafeToPlace = true;
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].name != gameObject.name && (colliders[i].tag == "Track" || colliders[i].tag == "Tower" || colliders[i].tag == "NoTowerPlace"))
                {
                    SafeToPlace = false;
                    break;
                }
            }
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {

            //Debug.Log(SafeToPlace);
            GameObject g = GameObject.Find("Coins");
            if (SafeToPlace == true && g.GetComponent<coins>().Coins - towerCost >= 0)
            {
                isDragging = false;
                RangeView.SetActive(false);
                this.GetComponent<TowerMenu>().enabled = true;
                //RangeView.GetComponent<RangeScript>().enabled = false;
                gameObject.GetComponent<DragAndDrop>().enabled = false;
                gameObject.GetComponent<TowerSeeking>().enabled = true;
                g.GetComponent<coins>().Coins -= towerCost;

            }
        }

        if (Input.GetMouseButtonDown(1)) {

            Destroy(gameObject);


        }




    }


    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, TowerFootprint);
    }



}