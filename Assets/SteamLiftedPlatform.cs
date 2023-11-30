using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamLiftedPlatform : MonoBehaviour
{
    public bool colliding;
    public float upSpeed;
    float timer;
    bool startTimer;
    public float maxHeight;
    public float minHeight;
    float waitTimer;
    public float waitTime;
    bool moveDown;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;
            if(timer >= 1f)
            {
                colliding = false;
                timer = 0;
                startTimer = false;
            }
        }

        if(transform.localPosition.y < maxHeight)
        {
            if (colliding)
            {
                transform.Translate(transform.up * upSpeed * Time.deltaTime);
            }
        }

        if(transform.localPosition.y >= maxHeight)
        {
            waitTimer += Time.deltaTime;
            if(waitTimer >= waitTime)
            {
                moveDown = true;
                colliding = false;
                //if(transform.childCount > 1)
                //{
                //    Destroy(transform.GetChild(1).gameObject);
                //}
                waitTimer = 0;
            }
        }

        if(transform.localPosition.y > minHeight)
        {
            if (moveDown)
            {
                transform.Translate(-transform.up * upSpeed * Time.deltaTime);
            }
        }

        if(transform.localPosition.y <= minHeight)
        {
            moveDown = false;
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FirstPersonMovement>())
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<FirstPersonMovement>())
        {
            other.transform.SetParent(null);
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.GetComponent<Steam>())
        {
            other.transform.SetParent(transform.parent);
            other.transform.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;
            Debug.Log("colliding with steam");
            colliding = true;

            if(transform.position.y >= maxHeight)
            {
                Destroy(other.gameObject);
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.collider.GetComponent<Steam>())
        {
            startTimer = true;
        }
    }
}
