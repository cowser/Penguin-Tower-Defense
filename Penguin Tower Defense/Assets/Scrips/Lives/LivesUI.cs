using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class LivesUI : MonoBehaviour
{

    public Text livesText;

    void Update()
    {

        livesText.text = "Lives: " + PlayerStats.PlayerLives.ToString();                 //Use with a canvas to show player health

    }
}
