using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Tool
{

    public Vector3 rotation;
    public float range;
    public AudioClip axeHit;
    public float axeDamage;

    public override void OnPickUp()
    {
        Debug.Log("pickup");
        transform.localRotation = Quaternion.Euler(rotation);
    }


    public override void Use()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, range))
        {
            Debug.Log(hit.collider.gameObject);

            if (hit.collider.GetComponent<Cuttable>())
            {
                Destroy(hit.collider.gameObject);
                AudioSource.PlayClipAtPoint(axeHit, hit.point);
            }
            else if (hit.collider.GetComponent<Tree>())
            {
                var tree = hit.collider.GetComponent<Tree>();
                AudioSource.PlayClipAtPoint(axeHit, hit.point);
                GameObject log = Instantiate(tree.log, hit.point, Quaternion.identity);
                tree.TakeDamage(axeDamage);

            }
        }
    }


}
