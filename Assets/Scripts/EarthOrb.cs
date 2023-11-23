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
                    spawnedVine = Instantiate(vines, hit.point, Quaternion.identity);
                    spawnedVine.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                }
                if (hit.normal.x == -1)
                {
                    spawnedVine = Instantiate(vines, hit.point, Quaternion.identity);
                    spawnedVine.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                }

                if (hit.normal.z == 1)
                {
                    spawnedVine = Instantiate(vines, hit.point, Quaternion.identity);
                    spawnedVine.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
                }
                if (hit.normal.z == -1)
                {
                    spawnedVine = Instantiate(vines, hit.point, Quaternion.identity);
                    spawnedVine.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                }

                if (hit.normal.y > .4f)
                {
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
        if(spawnedVine != null)
        {
            if (Input.GetButton("Fire1"))
            {
                growth += Time.deltaTime * growSpeed;
                timer += Time.deltaTime;

                spawnedVine.transform.localScale = new Vector3(growth, spawnedVine.transform.localScale.y, spawnedVine.transform.localScale.z);

                if (timer >= maxGrowTime)
                {
                    Destroy(gameObject);
                }

                
            }
        }
    }
}
