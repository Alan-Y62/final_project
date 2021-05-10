using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class AIObjects
{
    public string AIGroupName { get { return m_aiGroupName; } }
    public GameObject objectPrefab { get { return m_prefab; } }
    public int maxAI { get { return m_maxAI; } }
    public int spawnRate { get { return m_spawnRate; } }
    public int spawnAmount { get { return m_maxSpawnAmount; } }
    public bool randomizeStats { get { return m_randomizeStats; } }
    public bool enableSpawner { get { return m_enableSpawner; } }

    [Header("AI Groups Stats")]
    [SerializeField]
    private string m_aiGroupName;
    [SerializeField]
    private GameObject m_prefab;
    [SerializeField]
    [Range(0f, 30f)]
    private int m_maxAI;
    [SerializeField]
    [Range(0f,20f)]
    private int m_spawnRate;
    [SerializeField]
    [Range(0f,10f)]
    private int m_maxSpawnAmount;

    [Header("Main Settings")]
    [SerializeField]
    private bool m_enableSpawner;
    [SerializeField]
    private bool m_randomizeStats;

    public AIObjects(string name, GameObject Prefab, int maxAI, int SpawnRate, int SpawnAmount, bool RandomizeStats)
    {
        this.m_aiGroupName = name;
        this.m_prefab = Prefab;
        this.m_maxAI = maxAI;
        this.m_spawnRate = SpawnRate;
        this.m_maxSpawnAmount = SpawnAmount;
        this.m_randomizeStats = RandomizeStats;
    }
}

public class Ai : MonoBehaviour
{
    public List<Transform> Waypoints = new List<Transform>();

    public float spawnTImer { get { return m_SpawnTimer; } }
    public Vector3 spawnArea { get { return m_SpawnArea; } }
    [Header("Global Stats")]
    [Range(0f, 600f)]
    [SerializeField]
    private float m_SpawnTimer;
    [SerializeField]
    private Color m_SpawnColor = new Color(1.000f, 0.000f, 0.000f, 0.300f);
    [SerializeField]
    private Vector3 m_SpawnArea = new Vector3(20f ,10f ,20f);

    [Header("AI Groups Settings")]
    public AIObjects[] AIObject = new AIObjects[5];
    // Start is called before the first frame update


    //Empty Game Object to keep AI in
    private GameObject m_AIGroupSpawn;

    void Start()
    {
        GetWaypoints();
        RandomiseGroups();
        CreateAIGroups();
        InvokeRepeating("SpawnNPC", 0.5f, spawnTImer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnNPC()
    {
        for(int i = 0; i < AIObject.Count(); i++)
        {
            if(AIObject[i].enableSpawner && AIObject[i].objectPrefab != null)
            {
                GameObject tempGroup = GameObject.Find(AIObject[i].AIGroupName);
                if(tempGroup.GetComponentInChildren<Transform>().childCount < AIObject[i].maxAI)
                {
                    for (int y = 0; y < Random.Range(0,AIObject[i].spawnAmount) ; y++)
                    {
                        Quaternion randomRotation = Quaternion.Euler(Random.Range(-20, 20), Random.Range(0,360), 0);
                        GameObject tempSpawn;
                        tempSpawn = Instantiate(AIObject[i].objectPrefab, RandomPosition(), randomRotation);
                        tempSpawn.transform.parent = tempGroup.transform;
                        tempSpawn.AddComponent<AIMove>();

                    }
                }
            }
        }
    }

    public Vector3 RandomPosition()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-spawnArea.x, spawnArea.x),
            Random.Range(-spawnArea.y, spawnArea.y),
            Random.Range(-spawnArea.z, spawnArea.z)
            );
        randomPosition = transform.TransformPoint(randomPosition * .5f);
        return randomPosition;
    }

    public Vector3 RandomWaypoint()
    {
        int randomWp = Random.Range(0, (Waypoints.Count - 1));
        Vector3 randomWaypoint = Waypoints[randomWp].transform.position;
        return randomWaypoint;
    }

    //Method for putting random values in the AI Group setting
    void RandomiseGroups()
    {
        for (int i = 0; i < AIObject.Count(); i++)
        {
            if(AIObject[i].randomizeStats)
            {
                AIObject[i] = new AIObjects(AIObject[i].AIGroupName, AIObject[i].objectPrefab, Random.Range(1, 30), Random.Range(1, 20), Random.Range(1, 10), AIObject[i].randomizeStats);
            }
        }
    }

    //Method for creating the empty worldobject groups
    void CreateAIGroups()
    {
        for (int i = 0; i < AIObject.Count(); i++)
        {
            m_AIGroupSpawn = new GameObject(AIObject[i].AIGroupName);
            m_AIGroupSpawn.transform.parent = this.gameObject.transform;
        }
    }

    void GetWaypoints()
    {
        Transform[] wpList = this.transform.GetComponentsInChildren<Transform>();
        for (int i = 0; i < wpList.Length; i++)
        {
            if (wpList[i].tag == "waypoint")
            {
                Waypoints.Add(wpList[i]);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = m_SpawnColor;
        Gizmos.DrawCube(transform.position, spawnArea);
    }
}
