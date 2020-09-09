using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody rigidbody;

    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        transform.position = new Vector3(-0.5f, 0.5f, -0.5f);
    }

    void Update()
    {
        //Move();
        CellMove();
    }

    void CellMove()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0f, 0f, 1f); 
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0f, 0f, -1f); 
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1f, 0f, 0f); 
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1f, 0f, 0f); 
        }
    }

    void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        //Vector3 movePos = (new Vector3(inputX, 0, inputZ)).normalized; // 가야할 방향(크기가 1)
        //movePos = movePos * speed; // 가야할 방향으로 스피드 값만큼 간 위치
        //movePos = movePos * Time.deltaTime; // 프레임률에 따른 보정값
        //rigidbody.MovePosition(transform.position + movePos); // 현재 위치에서 가야할 위치를 더해줌

        Vector3 velocity = new Vector3(inputX, 0, inputZ);
        velocity = velocity * speed;
        velocity.y = rigidbody.velocity.y;

        rigidbody.velocity = velocity;

    }
}
