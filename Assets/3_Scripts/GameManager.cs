using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 가변 배열
    char[][] stage = new char[10][]
    {
        //              0    1    2    3    4    5    6    7    8    9
        new char[10] { 'W', 'W', 'W', 'W', 'W', '.', 'W', 'W', 'W', '.'}, // 0
        new char[10] { 'W', '.', '.', '.', 'W', '.', 'W', 'G', 'W', '.'}, // 1
        new char[10] { 'W', '.', 'I', '.', 'W', '.', 'W', 'G', 'W', '.'}, // 2
        new char[10] { 'W', '.', 'I', '.', 'W', '.', 'W', 'G', 'W', '.'}, // 3
        new char[10] { 'W', 'W', 'W', '.', 'W', 'W', 'W', '.', 'W', '.'}, // 4
        new char[10] { '.', 'W', 'W', 'P', '.', '.', '.', '.', 'W', '.'}, // 5
        new char[10] { '.', 'W', '.', 'I', '.', 'W', '.', '.', 'W', '.'}, // 6
        new char[10] { '.', 'W', '.', '.', '.', 'W', 'W', 'W', 'W', '.'}, // 7
        new char[10] { '.', 'W', 'W', 'W', 'W', 'W', '.', '.', '.', '.'}, // 8
        new char[10] { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.'}  // 9
    };

    

    public Transform stageTransform;

    public GameObject wallPrefab;   // 1
    public GameObject itemBoxPrefab;// 2
    public GameObject goalPrefab;   // 3 프리팹을 복제해서 사용

    public Player2 player;       // - 씬 위에 하나 있고, 위치만 변경




    void Start()
    {
        for(int z = 0; z < stage.Length; ++z)
        {
            for(int x = 0; x < stage[z].Length; ++x)
            {
                switch(stage[z][x])
                {
                    case 'P':
                        SetPropPosition(player.gameObject, x, z);
                        player.InitPlayer(x, z);
                        break;

                    case 'W': // if (stage[z][x] == 'W') 와 같은 의미
                        LeavePropOnStage(wallPrefab, x, z);
                        break;

                    case 'I':
                        LeavePropOnStage(itemBoxPrefab, x, z);
                        break;

                    case 'G':
                        LeavePropOnStage(goalPrefab, x, z);
                        break;
                }
            }
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) == true)
        {
            // 플레이어 위치 : [5][5]
            // 플레이어의 위 : [4][5]

            Vector3 upVoctor = new Vector3(0f, 0f, 1f);
            int upZ = (int)(player.myPos.z - upVoctor.z);
            int upX = (int)(player.myPos.x);
            Debug.Log("UP x : " + upX + ", z : " + upZ);
            char upProp = stage[upZ][upX];

            if (upProp == 'W') return;
            else
            {
                player.Move(upVoctor);
            }

        }

    }

    void LeavePropOnStage(GameObject propPrefab, int x, int z)
    {
        GameObject obj = Instantiate(propPrefab, stageTransform);

        SetPropPosition(obj, x, z);
    }

    void SetPropPosition(GameObject prop, int x, int z)
    {
        Vector3 newPos = new Vector3(x, 0f, -z);
        Vector3 correction = new Vector3((stage[z].Length * 0.5f), 0f, -(stage.Length * 0.5f));
        prop.transform.localPosition = newPos - correction - new Vector3(-0.5f, 0f, 0.5f);
    }

}
