using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class removeTree : MonoBehaviour
{

    public TreeInstance[] treeArray;
    public List<TreeInstance> treeArrayC = new List<TreeInstance>();
    private TerrainData terr;
    public GameObject gO;

    private RaycastHit vision;
    public float rayLenght;

    // Start is called before the first frame update
    void Start()
    {
        rayLenght =  8.0f;

        initTrees();
    }
    void initTrees() {
        treeArray = Terrain.activeTerrain.terrainData.treeInstances;
        treeArrayC.AddRange(treeArray);
        terr = Terrain.activeTerrain.terrainData;
        Debug.Log("trees.." + treeArrayC.Count);

    }
    
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward*rayLenght,Color.red,0.5f);
        if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out vision)){
            if(vision.collider.name != "Terrain") {
                Debug.Log(vision.collider.name);
                if(gO != null) {
                    if (gO.name == vision.collider.name) {

                    }
                    else {
                        gO.SetActive(true);
                    }
                }
                
                gO= GameObject.Find(vision.collider.name);
                gO.SetActive(false);
            }
                
        }
    }
   
}
