using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthOrb : ElementalOrb
{
    public float range;
    public override void Use()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, range))
        {
            Debug.Log(hit.collider.gameObject);

            if (hit.collider.CompareTag("Grow"))
            {
                hit.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
}
