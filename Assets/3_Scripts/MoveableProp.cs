using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableProp : MonoBehaviour
{
    public Vector3 myPos { private set; get; } // 인덱스 값

    Vector3 destination;
    public bool isMoving { private set; get; }
    

    public void Init(int x, int z)
    {
        myPos = new Vector3(x, 0f, z);
        destination = transform.position;
        isMoving = false;
    }

    void Update()
    {
        if (isMoving == false) return;

        Vector3 movePos = Vector3.Lerp(transform.position, destination, 0.2f);
        transform.position = movePos;

        if (Vector3.Distance(transform.position, destination) < 0.005f)
        {
            isMoving = false;
            transform.position = destination;
        }
    }

    public void Move(Vector3 moveVec)
    {   
        isMoving = true;
        myPos = new Vector3((myPos.x + moveVec.x), 0f, (myPos.z - moveVec.z));
        destination = transform.position + moveVec;

        transform.LookAt(destination);
    }
}
