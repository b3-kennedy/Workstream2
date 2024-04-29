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

    public GameObject pauseMenu;

    Transform player;

    public TextMeshProUGUI tipText;

    public GameObject tipsParent;

    public GameObject settingsPanel;

    public GameObject audioSlider;
    

    private void Awake()
    {
        //DontDestroyOnLoad(transform.parent.gameObject);
        //DontDestroyOnLoad(canvas);
        Instance = this;
    }


    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void EnableTips()
    {
        tipsParent.SetActive(!tipsParent.activeSelf);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.player;
        pauseMenu.SetActive(false);
        SetupAudioSlider();
        Cursor.lockState = CursorLockMode.None;

    }

    public void SetupAudioSlider()
    {
        Slider slider = audioSlider.GetComponent<Slider>();
        slider.value = AudioManager.Instance.musicSource.volume;
    }

    public void OnMusicSliderChange()
    {
        Slider slider = audioSlider.GetComponent<Slider>();
        AudioManager.Instance.musicSource.volume = slider.value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowTip(string text, float fontSize, float timeToDissapear)
    {
        tipText.text = text;
        tipText.fontSize = fontSize;
        StartCoroutine(HideTipText(timeToDissapear));
    }

    IEnumerator HideTipText(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        tipText.text = "";
    }

    public void PauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        if (pauseMenu.activeSelf)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            player.GetComponentInChildren<FirstPersonLook>().canLook = false;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            player.GetComponentInChildren<FirstPersonLook>().canLook = true;
        }
        
        
        ;
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
