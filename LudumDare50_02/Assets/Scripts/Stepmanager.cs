using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stepmanager : MonoBehaviour
{
    public static Stepmanager Instance;
    [Header("Steps")]
    [SerializeField] Transform parentOfStairs;
    [SerializeField] GameObject stepPrefab;
    [SerializeField] List<Step> steps;
    [SerializeField] Transform startingPoint;
    [SerializeField] Transform endpoint;
    [SerializeField] float stepOffset;
    [Header("Obstacles")]
    [SerializeField] GameObject[] ObstaclePrefabs;
    [SerializeField] Vector3[] ObstacleOffsets;
    float escalatorLength;
    int stepsSpawned;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        Quaternion quaternion = Quaternion.LookRotation(endpoint.position - startingPoint.position);
        startingPoint.rotation = quaternion;
        escalatorLength = (Mathf.FloorToInt(Vector3.Distance(startingPoint.position, endpoint.position) / stepOffset) * stepOffset);
        SpawnAllsteps();
    }

    // Update is called once per frame
    void Update()
    {
        MoveallSteps();
    }

    void SpawnAllsteps()
    {
        float stairLength = Vector3.Distance(startingPoint.position, endpoint.position);
        int amountOfStairs = Mathf.FloorToInt(stairLength / stepOffset);

        for (int i = 0; i < amountOfStairs; i++)
        {
            spawnSingleStep();
        }


    }


    void spawnSingleStep()
    {
        Debug.Log("Spawn");
        Vector3 Spawnpoint = steps[steps.Count - 1].transform.position - startingPoint.forward * stepOffset;
        Step step = Instantiate(stepPrefab, Spawnpoint, steps[0].transform.rotation).GetComponent<Step>();
        steps.Add(step);
        step.transform.parent = parentOfStairs;
    }

    void MoveallSteps()
    {
        float BPS = BeatManager.instance.BPM / 60;
        
        Vector3 velocity = startingPoint.forward * BPS * stepOffset/ BeatManager.instance.beatsProStep;
        foreach (Step step in steps)
        {
            MoveStep(step, velocity);
        }

    }
    void MoveStep(Step step, Vector3 velocity)
    {
        step.transform.position += velocity * Time.deltaTime;
    }

    void Respawn(Step step)
    {
        Debug.Log("Respawn");
        step.DeleteObstacles();
        Vector3 Respawnpoint = steps[steps.Count - 1].transform.position - startingPoint.forward * stepOffset;
        step.transform.position = Respawnpoint;
        steps.Remove(step);
        steps.Add(step);
        BeatManager.instance.IsStepOnBeat();
        stepsSpawned += 1;
        whichObstacleToSpawn(step);


    }

    public void CheckIfShouldRespawn(Step step)
    {
        if (Vector3.Distance(step.transform.position, startingPoint.position) >= escalatorLength)
        {
            Respawn(step);
        }
    }

    public void SpawnObstacle(int Obstacleindex, Step step)
    {
        if (Obstacleindex == -1)
        {
            return;
        }
        Vector3 spawnPosition = step.transform.position + ObstacleOffsets[Obstacleindex];
        GameObject ObjectToSpawn = ObstaclePrefabs[Obstacleindex];
        GameObject obstacle = Instantiate(ObjectToSpawn, spawnPosition, ObjectToSpawn.transform.rotation);
        obstacle.transform.parent = step.transform;
        step.AddObstacle(obstacle);

    }

    public void whichObstacleToSpawn(Step step)
    {
       
        if (stepsSpawned % 5 == 0)
        {
            SpawnObstacle(0, step);
        }

        if (stepsSpawned % 12 == 0)
        {
            SpawnObstacle(1, step);
        }
    }
}
