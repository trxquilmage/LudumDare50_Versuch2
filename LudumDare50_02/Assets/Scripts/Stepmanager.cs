using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stepmanager : MonoBehaviour
{
    public static Stepmanager Instance;
    [SerializeField] GameObject stepPrefab;
    [SerializeField] List<Step> steps;
    [SerializeField] Transform startingPoint;
    [SerializeField] Transform endpoint;
    [SerializeField] float stepOffset;
    float escalatorLength;

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
        escalatorLength = Vector3.Distance(startingPoint.position, endpoint.position);
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

        for(int i = 0; i < amountOfStairs; i++) 
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
    }

    void MoveallSteps()
    {
        Vector3 velocity = startingPoint.forward * (escalatorLength * BeatManager.instance.BPM / (stepOffset * 60 * BeatManager.instance.gapBetweenSteps));
        foreach (Step step in steps)
        {
            MoveStep(step, velocity);
        }

    }
    void MoveStep(Step step, Vector3 velocity)
    {
        Vector3 direction = startingPoint.forward;
        step.transform.position += velocity * Time.deltaTime;
    }

    void Respawn(Step step)
    {
        Debug.Log("Respawn");
        Vector3 Respawnpoint = steps[steps.Count - 1].transform.position - startingPoint.forward * stepOffset;
        step.transform.position = Respawnpoint;
        steps.Remove(step);
        steps.Add(step);

    }

    public void CheckIfShouldRespawn(Step step)
    {
        if (Vector3.Distance(step.transform.position, startingPoint.position) >= escalatorLength)
        {
            Respawn(step);
        }
    }

}
