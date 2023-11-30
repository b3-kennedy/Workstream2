using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public GameObject puzzle1Prefab;
    public GameObject puzzle2Prefab;
    public GameObject puzzle3Prefab;
    public GameObject puzzle4Prefab;

    [Header("Main Menu")]
    public GameObject mainMenuCam;
    public GameObject mainMenu;
    public GameObject fadePanel;



    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        defaultAmbience = RenderSettings.ambientLight;
        mainMenu.SetActive(true);
        
    }

    public void Quit()
    {
        Application.Quit();
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
