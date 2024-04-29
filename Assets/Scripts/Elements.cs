using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elements : MonoBehaviour
{

    public static Elements Instance;

    public GameObject fireOrb;
    public GameObject waterOrb;
    public GameObject earthOrb;
    public GameObject airOrb;
    public GameObject steamOrb;

    public GameObject steamElement;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }


}
