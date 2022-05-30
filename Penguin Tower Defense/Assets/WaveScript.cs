using System.Collections;
using System.Collections.Generic;
//using static System.Collections.IEnumerable;

using UnityEngine;

public class WaveScript : MonoBehaviour
{
    int CurrentRound = 0;
    bool WaveRunning = false;
    Vector2 SpawnPos;
    List<GameObject> WaveEnemies = new List<GameObject>();
    List<int> Enemyint = new List<int>();
    string[] waves;

    bool victoryAchieved = false;

    //public GameObject Ship;

    private void Awake()
    {

        var WaveText = Resources.Load("Waves") as TextAsset; ;
        //string[] AllWords = ReadAllLines(Application.streamingAssetsPath, "Waves.txt");

       // string[] tmpWave = WaveText.text.Split('-');


        //int yeh;

        waves = WaveText.text.Split(char.Parse("\n"));



        // List<int>.Parse(WaveText.text.Split('\n'), tmpWave);


        int maxWave = waves.Length;

        for (int i = 0; i < maxWave-1; i++) { 

            Debug.Log(waves[i] + " |");
            
        }

    }

    private void Start()
    {
       Vector2 pos1 = GameObject.Find("p").transform.position;
       Vector2 pos2 = GameObject.Find("p (1)").transform.position;
       SpawnPos = pos1 - pos2;
    }

    private void OnMouseUp()
    {
        if(!WaveRunning && !victoryAchieved) {

            WaveRunning = true;
            Debug.Log(CurrentRound);

            string[] tmp = waves[CurrentRound].Split(char.Parse(","));

            int roundLength = tmp.Length;
            Enemyint.Clear();

            for (int i = 0; i < roundLength; i++)
            {
                int value = int.Parse(tmp[i]);
                Debug.Log(value);
                Enemyint.Add( value );
            }

            StartCoroutine(waiter());

        }

    }

    IEnumerator waiter()
    {
        int listSize = Enemyint.Count; ;
            
        for (int i = 0; i < listSize; i++)
        {

            Debug.Log("Enemies/Ship"+Enemyint[i].ToString());

            GameObject EnemyShip = Instantiate((GameObject)Resources.Load("Enemies/Ship"+Enemyint[i].ToString(), typeof(GameObject)), SpawnPos, Quaternion.identity);

            WaveEnemies.Add(EnemyShip);
            yield return new WaitForSeconds(2);
        }
        //Wait for 2 seconds
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (WaveRunning)
        {
            
            int enemiesAmount = WaveEnemies.Count;
            bool cleared = true;
            for (int i = 0; i < enemiesAmount; i++)
            {
                if (WaveEnemies[i] == null && WaveEnemies.Count == Enemyint.Count)
                {



                }
                else { cleared = false; break; }
            }

            if (cleared == true)
            {
                CurrentRound++;
                WaveRunning = false;
                WaveEnemies.Clear();

                if (CurrentRound == waves.Length - 1)
                {
                    victoryAchieved = true;
                    FindObjectOfType<LevelLoader>().LoadSelectedLevel(2); //Victory
                }
            }

        }

        //color.color = new Color32(145, 0, 0, 165);

        if (WaveRunning)
        {
            GetComponent<SpriteRenderer>().material.color = new Color32(32, 32, 32, 255); ;
        }
        else
        {
            GetComponent<SpriteRenderer>().material.color = new Color32(40, 217, 161, 255); ;
        }
           

        }
    }

