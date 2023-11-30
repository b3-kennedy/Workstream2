using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windmill : MonoBehaviour
{

    public Transform rotor;
    public bool canRotate;
    public float rotateSpeed;
    public float stopTime;
    public bool noStop;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canRotate)
        {
            rotor.Rotate(new Vector3(rotateSpeed * Time.deltaTime, 0, 0));
            if (!noStop)
            {
                StartCoroutine(Stop());
            }
            
        }
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(stopTime);
        canRotate = false;
    }
}
