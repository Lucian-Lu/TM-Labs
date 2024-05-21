using UnityEngine;
using Pathfinding;

public class EnemyManager : MonoBehaviour
{
    private AIPath aiPath;
    private AIDestinationSetter destinationSetter;

    void Awake()
    {
        aiPath = GetComponent<AIPath>();
        destinationSetter = GetComponent<AIDestinationSetter>();
    }

    void Start()
    {
        
    }
}
