using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : Burnable
{
    public GameObject charcoal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnFireDestroy()
    {
        //Instantiate(charcoal, transform.position, Quaternion.identity);
    }
}
