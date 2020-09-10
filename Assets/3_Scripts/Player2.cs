using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public Vector3 myPos { private set; get; }
    

    public void InitPlayer(int x, int z)
    {
        myPos = new Vector3(x, 0f, z);
    }

    public void Move(Vector3 moveVec)
    {   
        myPos += moveVec;
        transform.position += moveVec;
        
    }
}
