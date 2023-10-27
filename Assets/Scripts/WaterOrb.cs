using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterOrb : ElementalOrb
{
    public float range;

    public override void Use()
    {
        //temporary raycast, ideally would use particle collision
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, range))
        {
            Debug.Log(hit.collider.gameObject);

            if (hit.collider.CompareTag("Element"))
            {
                if(hit.transform.GetComponent<EnvironmentElement>().type == EnvironmentElement.ElementType.FIRE)
                {
                    GameObject steam = Instantiate(Elements.Instance.steamElement, hit.transform.position, Quaternion.identity);
                }
            }
        }
    }


}
