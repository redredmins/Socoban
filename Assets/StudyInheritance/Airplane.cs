using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : Mover
{

    void Start()
    {
        isMove = true;
        destination = new Vector3(0f, 0f, 0f);
    }
    
    public override void Stop()
    {
        isMove = false;
    }

    protected override void SetNewDestination()
    {
        float randomY = Random.Range(0f, 20f);
        destination = new Vector3(transform.position.x, randomY, transform.position.z);
        Debug.Log("비행기 목적지 : " + destination);
    }
}
