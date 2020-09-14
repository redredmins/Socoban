using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour, IMover
{
    public float speed;
    protected bool isMove;
    protected Vector3 destination;


    void Start()
    {
        isMove = true;
        destination = new Vector3(0f, 0f, 0f);
    }

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
    
    public void Stop()
    {
        isMove = false;
    }

    protected void SetNewDestination()
    {
        float randomY = Random.Range(0f, 20f);
        destination = new Vector3(transform.position.x, randomY, transform.position.z);
        Debug.Log("비행기 목적지 : " + destination);
    }
}
