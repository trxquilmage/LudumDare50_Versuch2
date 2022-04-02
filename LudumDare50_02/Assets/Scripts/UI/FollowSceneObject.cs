using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSceneObject : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        Vector3 wantedPos = Camera.main.WorldToScreenPoint(target.position);
        transform.position = wantedPos;
    }
}
