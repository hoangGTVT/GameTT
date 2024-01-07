using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovent : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] waypoint;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 3f;
    private SpriteRenderer Sp;

    private void Start()
    {
        Sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(waypoint[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            Sp.flipX = true;
            if (currentWaypointIndex >= waypoint.Length)
            {
                currentWaypointIndex = 0;
               Sp.flipX=false;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoint[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
