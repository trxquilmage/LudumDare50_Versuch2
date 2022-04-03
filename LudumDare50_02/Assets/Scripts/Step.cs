using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour
{
    List<GameObject> Obstacles;
    public InputManager.Inputs input;
    // Start is called before the first frame update
    void Start()
    {
        Obstacles = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void LateUpdate()
    {
        Stepmanager.Instance.CheckIfShouldRespawn(this);
    }
    public void DeleteObstacles()
    {
        if (Obstacles.Count != 0)
        {
            for (int i = Obstacles.Count-1; i >= 0; i--)
            {
                Destroy(Obstacles[i]);
            }

        }
        input = 0;
    }
    public void AddObstacle(GameObject obstacle)
    {
        Obstacles.Add(obstacle);
    }

}
