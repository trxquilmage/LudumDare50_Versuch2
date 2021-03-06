using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour
{
    List<GameObject> Obstacles;
    public InputManager.Inputs input;
    [SerializeField] Transform player;
    // Start is called before the first frame update
    void Start()
    {
        Obstacles = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && Mathf.Abs(transform.position.z-player.transform.position.z)<0.1f) 
        {
            Debug.Log("the palyer is at index:"+ Stepmanager.Instance.steps.IndexOf(this));
        }
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
