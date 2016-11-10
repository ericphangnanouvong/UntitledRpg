using UnityEngine;
using System.Collections.Generic;


public class MapGenerator : MonoBehaviour
{

    public string TileSpriteRootGameObjectName = "Tiled Object";

    public int XTiles;
    public int YTiles;
    public int Logs;

    public GameObject GrassTile1;
    public GameObject GrassTile2;
    public GameObject Environment1;
   

    void Start()
    {
        TileSpriteRootGameObjectName = "Map";

        CreateSpriteTiledGameObject(XTiles, YTiles, Logs,
            GrassTile1, GrassTile2, Environment1, TileSpriteRootGameObjectName);

    }


    public static void CreateSpriteTiledGameObject(float XTiles, float YTiles, int Logs,
        GameObject SpriteLevelFile1, GameObject SpriteLevelFile2, GameObject SpriteLevelFile3, string RootObjectName)
    {

        float spriteX = 32;
        float spriteY = 16;

        GameObject rootObject = new GameObject();
        rootObject.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        rootObject.name = RootObjectName;

        //list holding all tiles
        List<GameObject> Rooms = new List<GameObject>();
        Rooms.Add(SpriteLevelFile1);
        Rooms.Add(SpriteLevelFile2);

        List<Vector3> TilePositions = new List<Vector3>();
        List<Vector3> TileVector = new List<Vector3>();


        int currentObjectCount = 0;
        int currentColumn = 0;
        int currentrow = 0;
        int numberOfLogs = 0;

        Vector3 currentLocation = new Vector3(0.0f, 0.0f, 0.0f);
        Vector3 startLocation = new Vector3(0.0f, 0.0f, 0.0f);

        //create map
        while (currentrow < YTiles)
        {
            int maxRandomRange = Rooms.Count + 1;
            int x = Random.Range(1, maxRandomRange);

            GameObject gridObject = Instantiate(Rooms[x - 1], currentLocation, Quaternion.identity) as GameObject;
            TilePositions.Add(currentLocation);
            TileVector.Add(new Vector3(currentrow, -currentColumn, 0));
            currentObjectCount++;
            gridObject.transform.SetParent(rootObject.transform);
            gridObject.name = "Grass Tile Position: (" + currentrow + ", " + -currentColumn + ")";
            currentLocation.x = currentLocation.x + 32;
            currentLocation.y = currentLocation.y - 16;
            currentColumn++;

            //move to next row
            if (currentColumn >= XTiles)
            {
                startLocation.x += 32;
                startLocation.y += 16;
                currentColumn = 0;
                currentrow++;
                currentLocation.x = startLocation.x;
                currentLocation.y = startLocation.y;
            }
        }

        while(numberOfLogs < Logs)
        {
            int maxRandomRange = TilePositions.Count + 1;
            int x = Random.Range(1, maxRandomRange);
            GameObject gridObject = Instantiate(SpriteLevelFile3, TilePositions[x-1], Quaternion.identity) as GameObject;
            gridObject.transform.SetParent(rootObject.transform);
            gridObject.name = "Environment Position: (" + TileVector[x-1].x + ", " + TileVector[x - 1].y + ")";
            TilePositions.RemoveAt(x - 1);
            TileVector.RemoveAt(x - 1);
            numberOfLogs++;
        }
    }
}
