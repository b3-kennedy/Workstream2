using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthOrb : ElementalOrb
{
    public float range;
    public Transform vines;
    Transform spawnedVine;
    public float growSpeed;
    float timer;
    float growth;
    public float maxGrowTime;
    public GameObject startClimb;
    public GameObject endClimb;


    private void Awake()
    {
        growth = 0.3f;
    }

    public override void Use()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, range))
        {
            Debug.Log(hit.normal);


            if(spawnedVine == null)
            {
                if (hit.normal.x == 1)
                {
                    UIManager.Instance.ChangeCrosshairState(UIManager.CrosshairState.DROP);

                    spawnedVine = Instantiate(vines, hit.point, Quaternion.identity);
                    spawnedVine.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                }
                if (hit.normal.x == -1)
                {
                    UIManager.Instance.ChangeCrosshairState(UIManager.CrosshairState.DROP);
                    spawnedVine = Instantiate(vines, hit.point, Quaternion.identity);
                    spawnedVine.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                }

                if (hit.normal.z == 1)
                {
                    UIManager.Instance.ChangeCrosshairState(UIManager.CrosshairState.DROP);
                    spawnedVine = Instantiate(vines, hit.point, Quaternion.identity);
                    spawnedVine.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
                }
                if (hit.normal.z == -1)
                {
                    UIManager.Instance.ChangeCrosshairState(UIManager.CrosshairState.DROP);
                    spawnedVine = Instantiate(vines, hit.point, Quaternion.identity);
                    spawnedVine.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                }

                if (hit.normal.y > .4f)
                {
                    UIManager.Instance.ChangeCrosshairState(UIManager.CrosshairState.DROP);
                    spawnedVine = Instantiate(vines, hit.point, Quaternion.identity);
                    spawnedVine.eulerAngles = new Vector3(0, Camera.main.transform.parent.eulerAngles.y + 90, 90);
                    spawnedVine.GetChild(0).tag = "ClimbableVines";
                }
            }




            if (hit.collider.CompareTag("Grow"))
            {
                hit.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            spawnedVine = null;
            growth = 0;
        }

        if(spawnedVine != null)
        {
            if (Input.GetButton("Fire1"))
            {
                growth += Time.deltaTime * growSpeed;
                timer += Time.deltaTime;


                transform.localScale -= new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime)/(5f + GameManager.Instance.bonusEarthTime);

                

                spawnedVine.transform.localScale = new Vector3(growth, spawnedVine.transform.localScale.y, spawnedVine.transform.localScale.z);

                if (timer >= maxGrowTime + GameManager.Instance.bonusEarthTime)
                {
                    Destroy(gameObject);
                }

                
            }
        }





    }

    public override void UI()
    {
        Debug.Log("UI");

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, range))
        {

            Debug.Log("in raycast");

            if (hit.normal.x == 1)
            {
                UIManager.Instance.ChangeCrosshairState(UIManager.CrosshairState.DROP);
            }
            if (hit.normal.x == -1)
            {
                UIManager.Instance.ChangeCrosshairState(UIManager.CrosshairState.DROP);
            }

            if (hit.normal.z == 1)
            {
                UIManager.Instance.ChangeCrosshairState(UIManager.CrosshairState.DROP);
            }
            if (hit.normal.z == -1)
            {
                UIManager.Instance.ChangeCrosshairState(UIManager.CrosshairState.DROP);

            }

            if (hit.normal.y > .4f)
            {
                UIManager.Instance.ChangeCrosshairState(UIManager.CrosshairState.DROP);

            }

            if (hit.collider.GetComponent<EnvironmentElement>() || hit.collider.GetComponent<ElementalOrb>())
            {
                UIManager.Instance.ChangeCrosshairState(UIManager.CrosshairState.GRAB);
            }

        }

        //if(spawnedVine != null)
        //{
        //    UIManager.Instance.ChangeCrosshairState(UIManager.CrosshairState.DEFAULT);
        //}
    }
}
