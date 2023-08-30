using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading; 

public class WaterGen : MonoBehaviour
{

    const int mapChunkSize = 241;
    public float noiseScale;
    public int octaves;
    public float persistance;
    public float lacunarity;
    public int seed;
    public Vector2 offset;
    public TerrainType[] regions;
    public bool autoUpdate;
    public enum DrawMode {NoiseMap,ColourMap,Mesh};
    public DrawMode drawMode;
    public float meshHeightMultiplier;
    public AnimationCurve meshHeightCurve;
    public int levelOfDetail;
    public bool Generate = false;
    public float Increment;
    public bool started = false;
    
  
   
    void Start()
    {             
    
    }

    void Update()
    {
        Thread.Sleep(80);
        if (started == true)
        {
            GenerateWater();
        }
        
        
        
    }
  
    public void GenerateWater()
    {
        started = true;
        float[,] noiseMap = Noise.GenerateNoiseMap(mapChunkSize, mapChunkSize, seed, noiseScale, octaves, persistance, lacunarity, offset); 
        Color[] colourMap = new Color[mapChunkSize * mapChunkSize];          
        offset = new Vector2(Increment++, Increment++);
       
       
        for (int y = 0; y < mapChunkSize; y++)
        {
            for (int x = 0; x < mapChunkSize; x++)
            {
                float currentHeight = noiseMap [x,y];

                for (int i = 0; i< regions.Length; i++)
                {
                    if (currentHeight <= regions[i].height)
                    {
                        colourMap[y * mapChunkSize + x] = regions[i].colour;
                        
                        break;
                    }
                }
            }    
        }
         WaterDisplayer display = FindObjectOfType<WaterDisplayer> ();
         if (drawMode == DrawMode.NoiseMap)
         {
             display.DrawTexture (TextureGenerator.TextureFromHeightMap(noiseMap));
         }
          else if (drawMode == DrawMode.ColourMap) 
         {
             display.DrawTexture (TextureGenerator.TextureFromColourMap(colourMap, mapChunkSize,mapChunkSize));
         }       
         else if (drawMode == DrawMode.Mesh)
         {
             display.DrawMesh(MeshGenerator.generateTerrainMesh(noiseMap, meshHeightMultiplier, meshHeightCurve, levelOfDetail), TextureGenerator.TextureFromColourMap(colourMap, mapChunkSize,mapChunkSize));
         }

    }

     void OnValidate ()
    {
       
        if (lacunarity < 1)
        {
            lacunarity = 1;
        }
        if (octaves < 0 )
        {
            octaves = 0;
        }
       
    }

}

 [System.Serializable]
public struct WaterType
{
    public string name;
    public float height;
    public Color colour;
 
}

