using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    Scene level;


    private void Awake()
    {
        // Kontrollerar s� endast en LevelLoader kan existera
        GameObject[] objs = GameObject.FindGameObjectsWithTag("KeepAlive");
        if (objs.Length > 1) {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        // H�mtar laddad scen
        level = SceneManager.GetActiveScene();

    }
    void Start()
    {
        SceneManager.LoadScene(1+level.buildIndex);
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
