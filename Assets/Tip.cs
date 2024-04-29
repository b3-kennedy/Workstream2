using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tip : MonoBehaviour
{

    public string tipText;
    public float fontSize;
    public float timeToDissapear;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FirstPersonMovement>())
        {
            UIManager.Instance.ShowTip(tipText, fontSize, timeToDissapear);
            Destroy(transform.parent.gameObject);
        }
    }
}
