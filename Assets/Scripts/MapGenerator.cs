using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] gridPrefabs;
    public float roomWidth = 50f;
    public float roomHeight = 50f;
    public int rows;
    public int cols;
    public bool isMapOfTheDay = false;
    public bool isRandomSeed = false;
    public int mapSeed;

    [HideInInspector]
    public Room[,] roomGrid;

    public GameObject playerSpawnerObject;

    public void Start()
    {
    }

    // Generates the map
    public void GenerateMap()
    {
        // If map of the day is enabled...
        if (isMapOfTheDay)
        {
            // ... use the date as the seed
            mapSeed = DateToInt(DateTime.Now.Date);
        }
        else if (isRandomSeed)
        {
            // ... use current date/time for seed
            mapSeed = DateToInt(DateTime.Now);
        }
        UnityEngine.Random.InitState(mapSeed);

        // Clear out the grid - "column" is X, "row" is Y
        roomGrid = new Room[cols, rows];

        // For each row...
        for (int currentRow = 0; currentRow < rows; currentRow++)
        {
            // ... for each column in that row...
            for (int currentCol = 0; currentCol < cols; currentCol++)
            {
                // ... figure out the position of the room...
                float xPosition = roomWidth * currentCol;
                float zPosition = roomHeight * currentRow;
                Vector3 newPosition = new Vector3(xPosition, 0.0f, zPosition);

                // ... create a new grid at the appropriate location...
                GameObject tempRoomObj = Instantiate(RandomRoomPrefab(), newPosition, Quaternion.identity) as GameObject;

                // ... set its parent...
                tempRoomObj.transform.parent = this.transform;

                // ... give it a meaningful name...
                tempRoomObj.name = "Room_" + currentCol + "," + currentRow;

                // ... get the room object...
                Room tempRoom = tempRoomObj.GetComponent<Room>();

                // ... and save it to the grid.
                roomGrid[currentCol, currentRow] = tempRoom;

                // Open the doors
                // If we are on the bottom row, open the north door...
                if (currentRow == 0)
                {
                    tempRoom.doorNorth.SetActive(false);
                }
                else if (currentRow == rows - 1)
                {
                    // ... otherwise, if we are on the top row, open the south door...
                    tempRoom.doorSouth.SetActive(false);
                }
                else
                {
                    // ... otherwise, we are in the middle, so open both doors.
                    tempRoom.doorNorth.SetActive(false);
                    tempRoom.doorSouth.SetActive(false);
                }

                // If we are on the left column, open the east door...
                if (currentCol == 0)
                {
                    tempRoom.doorEast.SetActive(false);
                }
                else if (currentCol == cols - 1)
                {
                    // ... otherwise, if we are on the right column, open the west door...
                    tempRoom.doorWest.SetActive(false);
                }
                else
                {
                    // ... otherwise, we are in the middle, so open both doors.
                    tempRoom.doorEast.SetActive(false);
                    tempRoom.doorWest.SetActive(false);
                }
            }
        }
        // Get reference to the PlayerSpawner object
        PlayerSpawner playerSpawner = playerSpawnerObject.GetComponent<PlayerSpawner>();
    }

    // Returns a random room prefab
    public GameObject RandomRoomPrefab()
    {
        return gridPrefabs[UnityEngine.Random.Range(0, gridPrefabs.Length)];
    }

    // Converts date to an integer
    public int DateToInt(DateTime dateToUse)
    {
        // Add our date up and return it
        return dateToUse.Year + dateToUse.Month + dateToUse.Day + dateToUse.Hour + dateToUse.Minute + dateToUse.Second + dateToUse.Millisecond;
    }
}
