using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameEvent : MonoBehaviour
{

    public void HideMainMenu()
    {
        GameManager.Instance.HideMenu();
    }

    
}
