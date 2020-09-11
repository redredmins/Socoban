using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    public float speed;
    protected bool isMove;
    protected Vector3 destination;

    protected void Update()
    {
        if (isMove == true)
        {
            Move();
        }
    }

    public void Move()
    {
        if (Vector3.Distance(transform.position, destination) < 1f)
        {
            SetNewDestination();
        }

        Vector3 dir = (destination - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;
    }

    public abstract void Stop();

    protected abstract void SetNewDestination();
}
