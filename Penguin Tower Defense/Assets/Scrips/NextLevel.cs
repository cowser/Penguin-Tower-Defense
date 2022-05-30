using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public void LoadNextLevel() {
        FindObjectOfType<LevelLoader>().LoadMenu();
    }
}
