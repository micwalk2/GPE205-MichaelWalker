<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerSpawner spawner;
    public MapGenerator mapGenerator;

    // List that holds player(s)
    public List<PlayerController> players;
    public List<AIController> aiPlayers;
    public int maxSpawnedPickups;
    [HideInInspector] public int numSpawnedPickups;

    // Awake is called before Start
    void Awake()
    {
        bool hasMapGenerated = false;

        if (instance == null)
        {
            instance = this;

            // Don't destroy if new scene loaded
            DontDestroyOnLoad(gameObject);

            // Find the player spawner and add it to spawner
            spawner = FindObjectOfType<PlayerSpawner>();

            // Generate the map
            mapGenerator.GenerateMap();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Spawn the player(s)
        spawner.SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerSpawner spawner;
    public MapGenerator mapGenerator;

    // List that holds player(s)
    public List<PlayerController> players;
    public List<AIController> aiPlayers;
    public int maxSpawnedPickups;
    [HideInInspector] public int numSpawnedPickups;

    // Awake is called before Start
    void Awake()
    {
        bool hasMapGenerated = false;

        if (instance == null)
        {
            instance = this;

            // Don't destroy if new scene loaded
            DontDestroyOnLoad(gameObject);

            // Find the player spawner and add it to spawner
            spawner = FindObjectOfType<PlayerSpawner>();

            // Generate the map
            mapGenerator.GenerateMap();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Spawn the player(s)
        spawner.SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
>>>>>>> main
