using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Mover
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
        float randomX = Random.Range(-20f, 20f);
        float randomZ = Random.Range(-20f, 20f);
        destination = new Vector3(randomX, 0f, randomZ);
        Debug.Log(gameObject.name + " 자동차 목적지 : " + destination);
    }
}
