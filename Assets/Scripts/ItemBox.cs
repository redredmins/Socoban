using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    //public Collider[] colliders;
    public Color touchColor;
    Color originColor;

    Renderer renderer;


    void Start()
    {
        renderer = GetComponent<Renderer>();
        originColor = renderer.material.color;
    }
    
    void OnTriggerEnter(Collider collider)
    {
        //Debug.Log(collider.gameObject.name + " 이 부딪힘");

        SetTouchColor(collider.tag);
    }

    void OnTriggerStay(Collider collider)
    {
        SetTouchColor(collider.tag);
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Goal")
        {
            renderer.material.color = originColor;
        }
    }

    void SetTouchColor(string tag)
    {
        if (tag == "Goal")
        {
            renderer.material.color = touchColor;
        }
    }

    void CellMove(Vector3 colliderPos)
    {
        Vector3 myPos = transform.position;
        float xDist = colliderPos.x - myPos.x;
        float zDist = colliderPos.z - myPos.z;
        if (xDist > zDist)
        {
            if (myPos.x > colliderPos.x) // right
            {

            }
            else // left
            {

            }
        }
        else
        {
            if (myPos.z > colliderPos.z) // up
            {

            }
            else
            {

            }

        }
    }
}
