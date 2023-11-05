using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burnable : MonoBehaviour
{
    public float fireHealth;
    public virtual void TakeFireDamage(float dmg)
    {
        fireHealth -= dmg;
        if(fireHealth <= 0)
        {
            OnFireDestroy();
            Destroy(gameObject);
        }
    }

    public virtual void OnFireDestroy()
    {
        
    }
}
