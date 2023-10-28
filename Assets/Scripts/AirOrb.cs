using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirOrb : ElementalOrb
{
    public float dissipateTime;
    float timer;
    public float range;
    public float force;
    public AudioClip soundEffect;

    // Start is called before the first frame update
    void Start()
    {
    }

    public override void Use()
    {
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, range))
        {
            Debug.Log(hit.collider.gameObject);

            if (hit.collider.CompareTag("Rotor"))
            {
                hit.collider.gameObject.GetComponent<Windmill>().canRotate = true;
            }
            if (hit.transform.GetComponent<Rigidbody>())
            {
                hit.transform.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * force, ForceMode.Impulse);
            }
        }

        AudioSource.PlayClipAtPoint(soundEffect, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= dissipateTime)
        {
            Destroy(gameObject);
            timer = 0;
        }
    }

    private void OnDisable()
    {
        timer = dissipateTime;
    }
}
