using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stepmanager : MonoBehaviour
{
    public static Stepmanager Instance;
    [SerializeField] List<Step> steps;
    [SerializeField] Transform StartingPoint;
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
        Quaternion quaternion = Quaternion.LookRotation(endpoint.position - StartingPoint.position);
        StartingPoint.rotation = quaternion;
        escalatorLength = Vector3.Distance(StartingPoint.position, endpoint.position);
    }

    // Update is called once per frame
    void Update()
    {
        MoveallSteps();
    }

    void MoveallSteps()
    {
        Vector3 velocity = StartingPoint.forward * (escalatorLength * BeatManager.instance.BPM / (stepOffset * 60 * BeatManager.instance.gapBetweenSteps));
        foreach (Step step in steps)
        {
            MoveStep(step, velocity);
        }
    }
    void MoveStep(Step step, Vector3 velocity)
    {
        Vector3 direction = StartingPoint.forward;
        step.transform.position += velocity * Time.deltaTime;

        if (Vector3.Distance(step.transform.position, StartingPoint.position) >= escalatorLength)
        {
            Respawn(step);
        }
    }

    void Respawn(Step step)
    {
        Debug.Log("Respawn");
        Vector3 Respawnpoint = steps[steps.Count - 1].transform.position - StartingPoint.forward * stepOffset;

    }

}
