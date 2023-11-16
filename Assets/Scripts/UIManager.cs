using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public enum CrosshairState {DEFAULT, GRAB, DROP};

    public CrosshairState crosshairState;

    public Image crosshair;

    public Sprite grabIcon;
    public Sprite dropIcon;

    public GameObject canvas;

    public TextMeshProUGUI enterText;


    private void Awake()
    {
        DontDestroyOnLoad(transform.parent.gameObject);
        DontDestroyOnLoad(canvas);
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCrosshairState(CrosshairState state)
    {

        crosshairState = state;

        switch (crosshairState)
        {
            case CrosshairState.DEFAULT:
                crosshair.sprite = null;
                crosshair.color = new Color(0, 0, 0, 0);
                break;
            case CrosshairState.GRAB:
                crosshair.sprite = grabIcon;
                crosshair.color = new Color(1, 1, 1, 1);
                break;
            case CrosshairState.DROP:
                crosshair.sprite = dropIcon;
                crosshair.color = new Color(1, 1, 1, 1);
                break;
            default:
                break;
        }
    }

    public void ShowText()
    {
        enterText.gameObject.SetActive(true);
    }

    public void HideText()
    {
        enterText.gameObject.SetActive(false);
    }

}
