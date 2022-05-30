using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelect : MonoBehaviour
{
    public GameObject tower;
    private int NumberOfType = 1;

    // Start is called before the first frame update
    public void OnMouseDown()
    {

       // Debug.Log("yeahyeahyeah");

        GameObject Tower2Spawn;
        Tower2Spawn = Instantiate(tower, transform.position, Quaternion.identity);
        Tower2Spawn.name = tower.name + " (" + NumberOfType + ")";
        //Lägger in costnaderna för att köpa olika towers.
        if (tower.name == "TestTower") //Basic Penguin
        {
            Tower2Spawn.GetComponent<DragAndDrop>().towerCost = 100;
        }
        else if (tower.name == "TestTower 2") //Super Penguin
        {               
            Tower2Spawn.GetComponent<DragAndDrop>().towerCost = 300;
        }
        else if (tower.name == "TestTower 3") //Tac Penguin
        {
            Tower2Spawn.GetComponent<DragAndDrop>().towerCost = 150;
        }
        //lägger till scriptet för att ta bort toweret.
        Tower2Spawn.AddComponent<UpgradeSelect>();
        Tower2Spawn.GetComponent<UpgradeSelect>().SetTower(this.gameObject);
        Tower2Spawn.GetComponent<UpgradeSelect>().TowerCost = Tower2Spawn.GetComponent<DragAndDrop>().towerCost;
        NumberOfType++;
    }
}
