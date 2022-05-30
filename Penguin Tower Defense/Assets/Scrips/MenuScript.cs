using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuScript : MonoBehaviour
{
    static int selectedLevel = 1;
    int amountOfLevles;
    float ContollX, ContollY;
    bool waited = false, running_waitfor = false;
    
    LevelLoader levelloader;
    GameObject LevelSelect;

    [SerializeField] Button selectLevel_start;

    [SerializeField] Sprite[] Maps;

    [SerializeField] Image myIMGcomponent1;
    [SerializeField] Image myIMGcomponent2;
    [SerializeField] Image myIMGcomponent3;

    void Awake()
    {
        amountOfLevles = SceneManager.sceneCountInBuildSettings - 3;
        Debug.Log("Levels: "+amountOfLevles);
        StartCoroutine(Waitfor(1f));
        levelloader = GameObject.FindObjectOfType<LevelLoader>();
        selectLevel_start.onClick.AddListener(selectLevel);
        //Laddar in första bilderna
        myIMGcomponent1.sprite = Maps[amountOfLevles-1];
        myIMGcomponent2.sprite = Maps[0];
        myIMGcomponent3.sprite = Maps[1];
    }

    public void SelectButton()
    {
        FindObjectOfType<Button>().Select();
    }

    void selectLevel()
    {
        levelloader.LoadSelectedLevel(selectedLevel);
    }

    void CheckSelected()
    {
        if (EventSystem.current.currentSelectedGameObject && EventSystem.current.currentSelectedGameObject.activeInHierarchy) //Om en knapp är selected
        {
            
        }
        else //Markera en knapp
        {
            SelectButton();
        }
    }
    void Update()
    {
        ContollX = Input.GetAxisRaw("Horizontal");
        ContollY = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        if (waited == true)
        {
            if (ContollX == -1) //Left
            {
                SelectLevel_picture_left();
                waited = false;
            }
            else if (ContollX == 1) //Right
            {
                SelectLevel_picture_right();
                waited = false;
            }
            else if (ContollY == 1) // Up
            {
                CheckSelected();
            }
            else if (ContollY == -1) //Down
            {
                CheckSelected();
            }
        }
        else {
            if (running_waitfor == false)
            {
                StartCoroutine(Waitfor(0.1f));
            }
        }
    }

    private IEnumerator Waitfor(float wait_secounds)
    {
        running_waitfor = true;
        yield return new WaitForSeconds(wait_secounds);
        waited = true;
        running_waitfor = false;
    }

    public void SelectLevel_picture_left()
    {
        
        if (selectedLevel < amountOfLevles)
        {
            selectedLevel++;
        }
        else {
            selectedLevel = 1;
        }

        if (selectedLevel > 1)
        {
            //Picture Switch                                  selected = 2
            myIMGcomponent1.sprite = Maps[selectedLevel - 2]; // [0]
            myIMGcomponent2.sprite = Maps[selectedLevel - 1]; // [1]
            myIMGcomponent3.sprite = Maps[selectedLevel];     // [2]
        }
        else {
            //Picture Switch                                  selected
            myIMGcomponent1.sprite = Maps[amountOfLevles - 1]; // [4]
            myIMGcomponent2.sprite = Maps[selectedLevel - 1]; // [0]
            myIMGcomponent3.sprite = Maps[selectedLevel];     // [1]
        }
        
    }

    public void SelectLevel_picture_left_change()
    {
        int tmpselectedLevel;
        if (selectedLevel < amountOfLevles)
        {
            tmpselectedLevel = selectedLevel + 1;
        }
        else
        {
            tmpselectedLevel = 1;
        }

        if (tmpselectedLevel > 1)
        {
            //Picture Switch                                  selected = 2
            myIMGcomponent1.sprite = Maps[tmpselectedLevel]; // [0]
        }
        else
        {
            //Picture Switch                                  selected
            myIMGcomponent1.sprite = Maps[amountOfLevles - 3]; // [4]
        }

    }

    public void SelectLevel_picture_right()
    {
        if (selectedLevel > 1)
        {
            selectedLevel--;
        }
        else
        {
            selectedLevel = amountOfLevles;
        }

        if (selectedLevel > 1)
        {
            //Picture Switch                                  selected = 2
            myIMGcomponent1.sprite = Maps[selectedLevel - 2]; // [0]
            myIMGcomponent2.sprite = Maps[selectedLevel - 1]; // [1]
            myIMGcomponent3.sprite = Maps[selectedLevel];     // [2]
        }
        else
        {
            //Picture Switch                                  selected
            myIMGcomponent1.sprite = Maps[amountOfLevles - 1]; // [4]
            myIMGcomponent2.sprite = Maps[selectedLevel - 1]; // [0]
            myIMGcomponent3.sprite = Maps[selectedLevel];     // [1]
        }

    }

    public void SelectLevel_picture_right_change()
    {
        int tmpselectedLevel;
        if (selectedLevel > 1)
        {
            tmpselectedLevel = selectedLevel - 1;
        }
        else
        {
            tmpselectedLevel = amountOfLevles;
        }

        if (tmpselectedLevel > 1)
        {
            //Picture Switch                                  selected = 2
            myIMGcomponent3.sprite = Maps[tmpselectedLevel-2]; // [0]
        }
        else
        {
            //Picture Switch                                  selected
            myIMGcomponent3.sprite = Maps[amountOfLevles-1]; // [4]
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
