using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirTowerDoor : MonoBehaviour
{
    public Transform doorLinePoint;
    public GameObject cylinder;
    LineRenderer lr;
    public Transform door;
    public float maxWeight;
    public WeightTrigger trigger;
    public float speed;
    public GameObject depositTrigger;
    public LineRenderer towerLR;

    // Start is called before the first frame update
    void Start()
    {
        lr = cylinder.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(2, doorLinePoint.position);

        if(trigger.weight > 0)
        {
            Vector3 newPos = new Vector3(door.localPosition.x, (trigger.weight / maxWeight), door.localPosition.z);
            door.localPosition = Vector3.Lerp(door.localPosition, newPos, Time.deltaTime * speed);
        }
        else if(trigger.weight == 0)
        {
            door.localPosition = Vector3.Lerp(door.localPosition, Vector3.zero, Time.deltaTime * speed); ;
        }

        if(door.localPosition.y > 2)
        {
            depositTrigger.SetActive(true);
        }
        
    }
}
