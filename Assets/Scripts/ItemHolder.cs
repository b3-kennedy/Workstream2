using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{

    public int maxItems;
    public bool parentToChild;
    public enum PrefferedObject {ELEMENT, DEFAULT};
    public PrefferedObject prefferedObject;

    public bool CanPlace(PrefferedObject obj)
    {
        if(obj == prefferedObject)
        {
            if (parentToChild)
            {
                if (transform.GetChild(0).childCount < maxItems)
                {
                    return true;
                }
                return false;
            }
            else
            {
                if (transform.childCount < maxItems)
                {
                    return true;
                }
                return false;
            }
        }
        return false;


    }
}
