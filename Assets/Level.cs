using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{

    public static Level Instance;

    public GameObject waterFall;
    public GameObject windMill;
    public GameObject vineWall;
    public GameObject door;
    public GameObject steamTurbine;

    public GameObject battery;
    public TextMeshPro batteryText;
    public GameObject doorLight;
    public GameObject openButton;

    [HideInInspector] public UnityEvent puzzleComplete;

    public Material green;

    public bool turbineOn;

    private void Awake()
    {
        Instance = this;
        puzzleComplete.AddListener(LevelComplete);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (windMill.GetComponent<Windmill>().canRotate)
        {
            waterFall.SetActive(false);
        }
        else
        {
            waterFall.SetActive(true);
        }
    }

    void LevelComplete()
    {
        doorLight.GetComponent<Renderer>().material = green;
        openButton.GetComponent<Renderer>().material = green;
        battery.GetComponent<Renderer>().material = green;
        batteryText.text = "100%";
    }
}
