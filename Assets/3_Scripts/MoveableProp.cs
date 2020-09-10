using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableProp : MonoBehaviour
{
    public Vector3 myPos { private set; get; } // 인덱스 값
    

    public void Init(int x, int z)
    {
        myPos = new Vector3(x, 0f, z);
    }

    public void Move(Vector3 moveVec)
    {   
        myPos = new Vector3((myPos.x + moveVec.x), 0f, (myPos.z - moveVec.z));
        transform.position += moveVec;
        
    }
}
