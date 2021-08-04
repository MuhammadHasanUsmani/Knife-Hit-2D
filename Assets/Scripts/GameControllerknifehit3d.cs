using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//this script cannot function properly without GameUI
//let Unity know about it with this attribute
[RequireComponent(typeof(GameUI))]
public class GameControllerknifehit3d : MonoBehaviour
{
    //we can get this instance from other scripts very easily
    public static GameControllerknifehit3d Instance { get; private set; }

    int currentLog = 0;
    [Header("LogPrefebs")]
    public List<GameObject> logPrefebs = new List<GameObject>();
    [SerializeField] GameObject SpawnyLog;

    //logPrefebs  currentlog;
    [SerializeField]   Vector3 logSpawnPosition = new Vector3 () ;

    [SerializeField]
    private int knifeCount;

    [Header("Knife Spawning")]
    [SerializeField]
    private Vector3 knifeSpawnPosition;
    [SerializeField]
    //this will be a prefab of the knife. You will create the prefab later.
    private GameObject knifeObject;

    //reference to the GameUI on GameController's game object
    public GameUI GameUI { get; private set; }

    private void Awake()
    {
        //simple kind of a singleton instance (we're only in 1 scene)
        Instance = this;

        GameUI = GetComponent<GameUI>();
    }

    private void Start()
    {
        knifeCount = Random.Range(1, 3);
        //update the UI as soon as the game starts
        GameUI.SetInitialDisplayedKnifeCount(knifeCount);
        //also spawn the first knife
        SpawnKnife();
        SpawnLog();
    }
    

    //this will be called from KnifeScript
    public void OnSuccessfulKnifeHit()
    {
        if (knifeCount > 0)
        {
            SpawnKnife();
        }
        else
        {
            StartGameOverSequence(true);
        }
    }

    //a pretty self-explanatory method
    private void SpawnKnife()
    {
        knifeCount--;
        Instantiate(knifeObject, knifeSpawnPosition, Quaternion.identity);
    }

    private void SpawnLog()
    {
<<<<<<< HEAD
        Instantiate(logPrefebs[currentLog], logPrefebs[currentLog].transform.position, logPrefebs[currentLog].transform.rotation);
=======
>>>>>>> parent of d20c205 (Score system and High Score system implementation)

        
            print("firstlog");

        

        Instantiate(SpawnyLog, logSpawnPosition, Quaternion.identity);
            
        
    }

    //the public method for starting game over
    public void StartGameOverSequence(bool win)
    {
        StartCoroutine("GameOverSequenceCoroutine", win);
    }

    //this is a coroutine because we want to wait for a while when the player wins
    private IEnumerator GameOverSequenceCoroutine(bool win)
    {
        if (win)
        {
            //make the player realize it's game over and he won
            //you can also add a nice animation of the breaking log
            //but this is outside the scope of this tutorial
            yield return new WaitForSecondsRealtime(0.3f);
            //Feel free to set different values for knife count and log's rotation pattern
            //instead of just restarting. This would make it feel like a new, harder level.
            NewLog();
           
        }
        else
        {
            GameUI.ShowRestartButton();
        }
    }
    public void SpawnLogMotor()
    {
        if (knifeCount <= 0)
        {
            
            
            knifeCount = Random.Range(1, 3);

            //update the UI as soon as the game starts
            GameUI.SetInitialDisplayedKnifeCount(knifeCount);
            Destroy(GameObject.FindGameObjectWithTag("Log"));
            currentLog++;
            if (currentLog >= logPrefebs.Count)
            {
                currentLog = 0;
            }
            Instantiate(logPrefebs[currentLog], logPrefebs[currentLog].transform.position, logPrefebs[currentLog].transform.rotation);

            print(currentLog);
        }
            if (currentLog > 5)
            {
                Instantiate(logPrefebs[Random.Range(2, logPrefebs.Count - 1)], logSpawnPosition, Quaternion.identity);
                print("restart");
            }
    }
    public void NewLog()
    {
        //restart the scene by reloading the currently active scene
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        SpawnLogMotor();
        SpawnKnife();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
