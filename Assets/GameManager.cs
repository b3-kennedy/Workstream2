using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform player;
    public Transform playerSpawn;

    public Transform caveEntrancePont;
    public Transform caveExitPoint;

    public Transform caveTerrainExit;
    public Transform caveTerrainEntrance;

    public GameObject directionalLight;

    public Color defaultAmbience;

    public Material defaultSkybox;
    public Material blackSkybox;

    public GameObject pauseMenu;
    



    [Header("Respawn Points")]
    public Transform[] puzzlePositions;

    public Transform puzzle1SpawnPoint;
    public Transform puzzle2SpawnPoint;
    public Transform puzzle3SpawnPoint;
    public Transform puzzle4SpawnPoint;
    public Transform puzzle5SpawnPoint;

    public GameObject puzzle1Prefab;
    public GameObject puzzle2Prefab;
    public GameObject puzzle3Prefab;
    public GameObject puzzle4Prefab;
    public GameObject puzzle5Prefab;

    [Header("Main Menu")]
    public GameObject mainMenuCam;
    public GameObject mainMenu;
    public GameObject fadePanel;

    public LineRenderer airTower;
    public LineRenderer earthTower;
    public LineRenderer fireTower;
    public LineRenderer waterTower;

    [Header("Upgrades")]
    public float bonusAirTime;
    public float bonusEarthTime;

    

   

    public GameObject playerCam;

    bool played;

    [Header("Cutscenes")]
    public GameObject castleDoor;
    public PlayableDirector director;
    public PlayableDirector finalCutsceneDirector;




    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        defaultAmbience = RenderSettings.ambientLight;
        mainMenu.SetActive(true);
        
    }

    public void FinalCutscene()
    {
        
        Debug.Log("final");
        finalCutsceneDirector.gameObject.SetActive(true);
        finalCutsceneDirector.Play();
        StartCoroutine(WaitForFinalCutscene((float)finalCutsceneDirector.duration));
    }

    IEnumerator WaitForFinalCutscene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        MainMenu();
    }

    public void Quit()
    {
        Application.Quit();
    }


    private void Update()
    {
        if(airTower.enabled && earthTower.enabled && fireTower.enabled && waterTower.enabled && !played)
        {
            OpenCastleDoor();
            played = true;
        }
    }

    public void OpenCastleDoor()
    {
        director.gameObject.SetActive(true);
        playerCam.SetActive(false);
        director.Play();
        Debug.Log(director.duration);
        StartCoroutine(WaitForCutscene((float)director.duration));
        //castleDoor.SetActive(false);
    }

    IEnumerator WaitForCutscene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        playerCam.SetActive(true);
    }




    public void ResetPuzzle1()
    {
        Destroy(puzzlePositions[0].gameObject);
        var puzzle = Instantiate(puzzle1Prefab);
        puzzlePositions[0] = puzzle.transform;
        player.transform.position = puzzle1SpawnPoint.position;

    }

    public void ResetPuzzle2()
    {
        Destroy(puzzlePositions[1].gameObject);
        var puzzle = Instantiate(puzzle2Prefab);
        puzzlePositions[1] = puzzle.transform;
        player.transform.position = puzzle2SpawnPoint.position;

    }

    public void ResetPuzzle3()
    {
        Destroy(puzzlePositions[2].gameObject);
        var puzzle = Instantiate(puzzle3Prefab);
        puzzlePositions[2] = puzzle.transform;
        player.transform.position = puzzle3SpawnPoint.position;

    }

    public void ResetPuzzle4()
    {
        Destroy(puzzlePositions[3].gameObject);
        var puzzle = Instantiate(puzzle4Prefab);
        puzzlePositions[3] = puzzle.transform;
        player.transform.position = puzzle4SpawnPoint.position;

    }

    public void ResetPuzzle5()
    {
        Destroy(puzzlePositions[4].gameObject);
        var puzzle = Instantiate(puzzle5Prefab);
        puzzlePositions[4] = puzzle.transform;
        player.transform.position = puzzle5SpawnPoint.position;
    }

    public void StartGameTransition()
    {
        Debug.Log("started game");
        mainMenu.SetActive(false);
        fadePanel.GetComponent<Animator>().SetTrigger("transition");


    }
    public void HideMenu()
    {
        
        mainMenuCam.SetActive(false);
        player.gameObject.SetActive(true);
        player.transform.position = playerSpawn.position;
        UIManager.Instance.crosshair.gameObject.SetActive(true);


    }
    


    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Island");
    }


    public void MainMenuTransition()
    {
       
        fadePanel.GetComponent<Animator>().SetTrigger("transition");

    }

}
