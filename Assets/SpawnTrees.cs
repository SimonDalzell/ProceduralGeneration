using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrees : MonoBehaviour
{   
    public GameObject drawTrees;    
    public GameObject drawBush; 
    public float raycastDistance = 100000f;
    private float numTreesToSpawn;
    private float numBushesToSpawn;
    public int treesSpawned;
    public int bushSpawned;
    public Vector3 previous = new Vector3 (0,0,0);
    public void Generate()
    {
        GameObject myObject = GameObject.Find("Mesh");
        Transform headTransform = myObject.transform;
        Mesh mesh = myObject.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;

   
           for (var i = 0; i < vertices.Length; i+=1000)
           {
                Vector3 randVector = new Vector3(UnityEngine.Random.Range(-20.0f, 20.0f), 0, UnityEngine.Random.Range(-20.0f, 20.0f));
                //Debug.Log(vertices[i]);                
                 Vector3 vertexWorldPosition = headTransform.TransformPoint(vertices[i]);               
                if ((treesSpawned < numTreesToSpawn)&&(vertices[i].y > 8)&&(vertices[i].y < 12)&&(Vector3.Distance(previous, vertices[i]) > 100))
                {
                    Debug.Log(vertices[i]);
                    GameObject tClone = Instantiate(drawTrees, vertexWorldPosition + randVector, transform.rotation);
                    for (int j = 0; j < numBushesToSpawn; j++)                    
                    {
                           Vector3 randVector2 = new Vector3(UnityEngine.Random.Range(-50.0f, 50.0f), 0, UnityEngine.Random.Range(-50.0f, 50.0f));
                           GameObject bClone = Instantiate(drawBush, vertexWorldPosition + randVector2, transform.rotation);
                    }
                    
                    treesSpawned++;
                    previous = vertices[i];                  
                }
                        
           }
    }
    void Start()
    {        
         
    }
     public void adjustTreeNumber(float newTreeNum)
    {
        numTreesToSpawn = newTreeNum;
    }
     public void adjustBushNumber(float newBushNum)
    {
        numBushesToSpawn = newBushNum;
    }


           
   


}