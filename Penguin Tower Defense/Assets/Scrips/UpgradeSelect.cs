using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSelect : MonoBehaviour
{
    private GameObject Tower;
    public int TowerCost;
    // Start is called before the first frame update
    public void OnMouseDown()
    {

        Debug.Log("Pressed ID: "+ this.gameObject.transform.name);
        
        foreach (Transform eachChild in transform)
        {
            if (eachChild.name == "RangeVisual")
            {
                if (eachChild.gameObject.activeSelf) {
                    FindObjectOfType<GameUI>().SetUpgradeWindow(false);
                    eachChild.gameObject.SetActive(false);
                }
                else
                {
                    FindObjectOfType<GameUI>().setTower(this.gameObject);
                    FindObjectOfType<GameUI>().SetUpgradeWindow(true);
                    eachChild.gameObject.SetActive(true);
                }
            }
        }
    }

    public void DeleteTower() {
        double tmpTowerCost = TowerCost;
        tmpTowerCost *= 0.8;
        TowerCost = (int)tmpTowerCost;

        Debug.Log("Deleted ID:" + this.gameObject.transform.name);
        GameObject.Find("Coins").GetComponent<coins>().Coins += TowerCost;
        GameObject.Destroy(this.gameObject);
    }

    public void SetTower(GameObject tower) {
        Tower = tower;
    }
    public Transform GetTower()
    {
        return(this.transform);
    }
}
