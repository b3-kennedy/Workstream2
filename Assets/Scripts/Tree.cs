using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Burnable
{
    public GameObject log;
    public GameObject burnedTreeStump;
    public float cuttingHealth;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float dmg)
    {
        cuttingHealth -= dmg;
        if(cuttingHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public override void OnFireDestroy()
    {
        if(burnedTreeStump != null)
        {
            Instantiate(burnedTreeStump, transform.position, Quaternion.identity);
        }
        
    }
}
