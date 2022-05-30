using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] Image Font_window;
    [SerializeField] Sprite[] Turret_pictures_down;
    [SerializeField] Sprite[] Turret_pictures_front;
    [SerializeField] Image[] Turret_objects;
    [SerializeField] GameObject ResourcesMain;
    [SerializeField] GameObject UpgradeMain;
    GameObject Tower;
    GameObject oldTower;

    private void Awake()
    {
        for (int i = 0; i < Turret_pictures_down.Length; i++)
        {
            Turret_objects[i].sprite = Turret_pictures_down[i];
        }
        
    }

    public void upgrade(int pressed)
    {
        Font_window.sprite = Turret_pictures_front[pressed];
    }

    public void delete() {
        UpgradeSelect[] Towers = FindObjectsOfType<UpgradeSelect>();
        foreach (UpgradeSelect tower in Towers) {
            if (tower.GetTower().name == Tower.transform.name) {
                tower.DeleteTower();
                SetUpgradeWindow(false);
                break;
            }
        }
    }

    public void setTower(GameObject tower) {
        if (oldTower == null){
            oldTower = tower;
        }
        else {
            if (oldTower != tower) {
                foreach (Transform eachChild in oldTower.transform)
                {
                    if (eachChild.name == "RangeVisual")
                    {
                        eachChild.gameObject.SetActive(false);
                    }
                }
            }
        }
        oldTower = tower;
        Tower = tower;
    }   

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleResources() {
        if (ResourcesMain.activeSelf)
        {
            ResourcesMain.SetActive(false);
        }
        else
        {
            ResourcesMain.SetActive(true);
        }
    }
    public void ToggleUpgradeWindow()
    {
        if (UpgradeMain.activeSelf)
        {
            UpgradeMain.SetActive(false);
        }
        else
        {
            UpgradeMain.SetActive(true);
        }
    }

    public void SetUpgradeWindow(bool on)
    {
        if (on)
        {
            UpgradeMain.SetActive(true);
        }
        else
        {
            UpgradeMain.SetActive(false);
        }
    }
}
