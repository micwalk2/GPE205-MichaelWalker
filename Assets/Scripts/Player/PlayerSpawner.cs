using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    public PlayerController playerControllerPrefab;
    public PawnSpawnPoint[] spawnPoints;

    private bool hasMapGenerated = false;

    // Start is called before the first frame update
    public void Start()
    {
        spawnPoints = FindObjectsOfType<PawnSpawnPoint>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SpawnPlayer()
    {   
        // Instantiate playerPrefab at point using GetRandomSpawnPoint()
        PawnSpawnPoint spawnPoint = GetRandomSpawnPoint();
        GameObject player = Instantiate(playerPrefab, spawnPoint.transform.position, Quaternion.identity) as GameObject;
        GameObject playerOneController = Instantiate(playerControllerPrefab.gameObject, spawnPoint.transform.position, Quaternion.identity) as GameObject;

        // Set player's controller to the player's pawn
        playerOneController.GetComponent<PlayerController>().pawn = player.GetComponent<Pawn>();

        // Set initial velocity to zero
        Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
        playerRigidbody.velocity = Vector3.zero;
    }

    // Returns a random spawn point
    public PawnSpawnPoint GetRandomSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }
}
