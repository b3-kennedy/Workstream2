using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{

    public int maxItems;
    public bool parentToChild;
    public string preferredTag;

    public bool CanPlace(string tag)
    {
        if(tag == preferredTag)
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
