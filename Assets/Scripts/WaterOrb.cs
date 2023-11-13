using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterOrb : ElementalOrb
{
    public float range;
    public AudioClip water;
    public AudioClip steamAudio;

    public override void Use()
    {
        //temporary raycast, ideally would use particle collision
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, range))
        {
            if (hit.collider.CompareTag("Element"))
            {
                if(hit.transform.GetComponent<EnvironmentElement>().type == EnvironmentElement.ElementType.FIRE)
                {
                    GameObject steam = Instantiate(Elements.Instance.steamElement, hit.transform.position, Quaternion.identity);
                    AudioSource.PlayClipAtPoint(steamAudio, hit.point);

                }
            }
            else if (hit.collider.CompareTag("WaterFillZone"))
            {
                Debug.Log("fill");
                hit.collider.GetComponent<FillArea>().Fill();
            }
            else if (hit.collider.CompareTag("ControlPanelInside"))
            {
                hit.collider.GetComponent<ActivateDoor>().Open();
            }
        }

        AudioSource.PlayClipAtPoint(water, transform.position);
    }


}
