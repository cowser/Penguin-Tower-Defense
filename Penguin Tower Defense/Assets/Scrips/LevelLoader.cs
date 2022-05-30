using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    Scene level;
    int AmountofLevels;

    private void Awake()
    {
        // Kontrollerar så endast en LevelLoader kan existera
        GameObject[] objs = GameObject.FindGameObjectsWithTag("KeepAlive");
        for (int i = 0; i < objs.Length; i++)
        {
            for (int v = 0; v < objs.Length; v++)
            {
                if (objs[v] == null || objs[i] == null) {
                    break;
                }
                else if (objs[i].ToString() == objs[v].ToString() && i != v)
                {
                    Debug.Log("Deleted Duplicate of object:" + objs[v].ToString());
                    Destroy(objs[v]);
                    objs[v] = null;
                    break;
                }
            }
        }
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i] != null)
            {
                DontDestroyOnLoad(objs[i]);
            }
           
        }
        //Hämtar totalla antalet scener
        AmountofLevels = SceneManager.sceneCountInBuildSettings;

    }
    private void FixedUpdate()
    {
        if (this.enabled) //Om scriptet är på
        {
            this.enabled = false;
            LoadNextLevel();
        }
    }

    public void LoadNextLevel() //Loads nextlevel
    {
        // Hämtar laddad scen
        level = SceneManager.GetActiveScene();
        if ( (level.buildIndex + 1) < AmountofLevels)
        {
            SceneManager.LoadScene(1 + level.buildIndex);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
        
    }

    public void LoadSelectedLevel(int levelIndex) {
        SceneManager.LoadScene(levelIndex);
    }

    public void LoadMenu() {
        SceneManager.LoadScene(0);
    }

    public void RestartLevel() {
        SceneManager.LoadScene(level.buildIndex);
    }

}
