using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirOrb : ElementalOrb
{
    public float dissipateTime;
    public float timer;
    public float range;
    public float force;
    public float buoyantPlatformForce;
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
                if (hit.collider.gameObject.GetComponent<BuoyantPlatform>())
                {
                    Debug.Log("buoyant");
                    hit.transform.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * buoyantPlatformForce);
                }
                else if(!hit.collider.GetComponent<BuoyantPlatform>())
                {
                    hit.transform.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * force, ForceMode.Impulse);
                }
                
            }
        }

        AudioSource.PlayClipAtPoint(soundEffect, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= dissipateTime + GameManager.Instance.bonusAirTime)
        {
            Destroy(gameObject);
            timer = 0;
        }
    }

    private void OnDisable()
    {
        timer = 0;
    }

    public override void UI()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, range))
        {

            if (hit.collider.CompareTag("Rotor"))
            {
                UIManager.Instance.ChangeCrosshairState(UIManager.CrosshairState.DROP);
            }

            if (hit.transform.GetComponent<Rigidbody>())
            {

                UIManager.Instance.ChangeCrosshairState(UIManager.CrosshairState.DROP);
            }
        }
    }
}
