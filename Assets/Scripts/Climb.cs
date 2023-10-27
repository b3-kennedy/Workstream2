using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour
{
    float vertical;
    public float speed;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical") * speed;

        rb.velocity = new Vector3(0, vertical, 0);
    }
}
