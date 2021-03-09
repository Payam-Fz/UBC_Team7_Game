using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float speed = 2f;

    int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetposition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetposition, movementThisFrame);

            if (transform.position == targetposition)
            {
                waypointIndex++;
            }
        }

    }
}
