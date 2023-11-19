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

        if(transform.position.y < maxHeight)
        {
            if (colliding)
            {
                transform.Translate(transform.up * upSpeed * Time.deltaTime);
            }
        }

        if(transform.position.y >= maxHeight)
        {
            waitTimer += Time.deltaTime;
            if(waitTimer >= waitTime)
            {
                moveDown = true;
            }
        }

        if(transform.position.y > minHeight)
        {
            if (moveDown)
            {
                transform.Translate(-transform.up * upSpeed * Time.deltaTime);
            }
        }

        if(transform.position.y <= minHeight)
        {
            moveDown = false;
        }



    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.GetComponent<Steam>())
        {
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
