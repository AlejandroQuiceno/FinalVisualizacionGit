using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    public int width = 256; 
    public int height = 256;

    public float depth = 20;

    public float scale = 20f;

    public float offsetX = 100f;
    public float offsetY = 100f;

    public float movespeedX = 0f;
    public float movespeedY = 0f;

    //private void Start()
    //{
    //    offsetX = Random.Range(0f, 9999f);
    //    offsetY = Random.Range(0f, 9999f);
    //}

    private void Update()
    {
        //terrain update
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    private void FixedUpdate()
    {
        //terrain changes
        offsetX = offsetX + (movespeedX / 100);
        offsetY = offsetY + (movespeedY / 100);

    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);

        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }
        }

        return heights;
    }

    float CalculateHeight(int x, int y)
    {
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }


}