using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleTest : MonoBehaviour
{
    public Transform player;
    public float distance;
    public float speed;

    private Vector3 center;
    private float angle = 0f;

    void Start()
    {
        center = player.position;
    }

    void Update()
    {
        float distanceFromPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceFromPlayer < distance)
        {
            // Move towards the player
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            // Circle around the player
            angle += speed * Time.deltaTime;

            Vector3 offset = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0) * distance;

            transform.position = center + offset;
        }
    }
}



