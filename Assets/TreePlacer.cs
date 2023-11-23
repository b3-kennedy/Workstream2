using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TreePlacer : MonoBehaviour
{

    public static TreePlacer Instance;

    public GameObject[] treePrefabs;
    public  Terrain[] terrains;
    List<Vector3> treePositions = new List<Vector3>();
    public TreePositionHolder holder;
    int index;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        foreach (var terrain in terrains)
        {
            foreach(var tree in terrain.terrainData.treeInstances) 
            {
                Vector3 treePos = Vector3.Scale(tree.position, terrain.terrainData.size) + terrain.GetPosition();
                if (!holder.treePositions.Contains(treePos))
                {
                    holder.treePositions.Add(treePos);
                }
                
                treePositions.Add(treePos);
            }
            List<TreeInstance> newTrees = new List<TreeInstance>(0);
            terrain.terrainData.treeInstances = newTrees.ToArray();

        }

        foreach (var treePos in holder.treePositions)
        {
            int rand = Random.Range(0, treePrefabs.Length);
            Instantiate(treePrefabs[rand], holder.treePositions[index], Quaternion.identity);

            index++;
        }

    }



}
