using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform caveEntrancePont;
    public Transform caveExitPoint;

    public Transform caveTerrainExit;
    public Transform caveTerrainEntrance;

    public GameObject directionalLight;

    public Color defaultAmbience;

    public Material defaultSkybox;
    public Material blackSkybox;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        defaultAmbience = RenderSettings.ambientLight;
    }

}
