using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    string path = Application.dataPath + "/StreamingAssets/treepositions.txt";
    public List<string> lines = new List<string>();
    public Transform treesParent;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log(path);
        Instance = this;
        StreamWriter writer = new StreamWriter(path, true);
        foreach (var terrain in terrains)
        {
            foreach(var tree in terrain.terrainData.treeInstances) 
            {
                Vector3 treePos = Vector3.Scale(tree.position, terrain.terrainData.size) + terrain.GetPosition();
                writer.WriteLine(treePos.x.ToString() + "," + treePos.y.ToString() + "," +treePos.z.ToString());


                //Instantiate(treePrefabs[0], treePos, Quaternion.identity);
                //if (!holder.treePositions.Contains(treePos))
                //{
                //    holder.treePositions.Add(treePos);
                //}
                
                //treePositions.Add(treePos);
            }
            List<TreeInstance> newTrees = new List<TreeInstance>(0);
            terrain.terrainData.treeInstances = newTrees.ToArray();
            writer.Close();
        }

        StreamReader reader = new StreamReader(path);

        string line = reader.ReadLine();

        while (!reader.EndOfStream)
        {
            lines.Add(reader.ReadLine());
        }

        reader.Close();

        foreach (var l in lines)
        {
            string[] split = l.Split(',');
            Vector3 pos = new Vector3(float.Parse(split[0]), float.Parse(split[1]), float.Parse(split[2]));
            GameObject newTree = Instantiate(treePrefabs[0], pos, Quaternion.identity);
            newTree.transform.SetParent(treesParent);
        }


        //foreach (var treePos in holder.treePositions)
        //{
        //    int rand = Random.Range(0, treePrefabs.Length);
        //    Instantiate(treePrefabs[rand], holder.treePositions[index], Quaternion.identity);

        //    index++;
        //}

    }



}
