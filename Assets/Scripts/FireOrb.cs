using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOrb : ElementalOrb
{

    
    public float range;
    public AudioClip extinguish;
    public AudioClip flamethrower;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Use()
    {
        //temporary raycast, ideally would use particle collision
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, range))
        {
            Debug.Log(hit.collider.gameObject);

            if (hit.collider.CompareTag("Burnable"))
            {
                Destroy(hit.collider.gameObject);
            }
        }
        AudioSource.PlayClipAtPoint(flamethrower, transform.position);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            AudioSource.PlayClipAtPoint(extinguish, transform.position);
            Destroy(gameObject);
        }
    }
}
