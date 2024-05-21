using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyController : MonoBehaviour
{
    public AIPath aiPath;
    void Update()
    {
        Vector3 localScale = transform.localScale;

        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            localScale.x = -Mathf.Abs(localScale.x);
        } 
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            localScale.x = Mathf.Abs(localScale.x);
        }

        transform.localScale = localScale;
    }
}
