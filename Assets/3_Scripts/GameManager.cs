using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 한 칸씩 움직이는 소코반

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

    public MoveableProp player;       // - 씬 위에 하나 있고, 위치만 변경

    List<MoveableProp> itemBoxs;
    Dictionary<Vector3, GameObject> goalDic;




    void Start()
    {
        itemBoxs = new List<MoveableProp>();
        goalDic = new Dictionary<Vector3, GameObject>();

        for(int z = 0; z < stage.Length; ++z)
        {
            for(int x = 0; x < stage[z].Length; ++x)
            {
                switch(stage[z][x])
                {
                    case 'P':
                        SetPropPosition(player.gameObject, x, z);
                        player.Init(x, z);
                        break;

                    case 'W': // if (stage[z][x] == 'W') 와 같은 의미
                        LeavePropOnStage(wallPrefab, x, z);
                        break;

                    case 'I':
                        GameObject item = LeavePropOnStage(itemBoxPrefab, x, z);
                        MoveableProp moveableItem = item.GetComponent<MoveableProp>();
                        moveableItem.Init(x, z);
                        itemBoxs.Add(moveableItem);
                        break;

                    case 'G':
                        GameObject goalObj = LeavePropOnStage(goalPrefab, x, z);
                        goalDic.Add(new Vector3(x, 0, z), goalObj);
                        break;
                }
            }
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) == true)
        {
            Vector3 upVector = new Vector3(0f, 0f, 1f);
            MovePlayer(upVector);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) == true)
        {
            Vector3 downVector = new Vector3(0f, 0f, -1f);
            MovePlayer(downVector);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) == true)
        {
            Vector3 leftVector = new Vector3(-1f, 0f, 0f);
            MovePlayer(leftVector);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) == true)
        {
            Vector3 rightVector = new Vector3(1f, 0f, 0f);
            MovePlayer(rightVector);
        }

    }

    void MovePlayer(Vector3 dir)
    {
        int moveZ = (int)(player.myPos.z - dir.z);
        int moveX = (int)(player.myPos.x + dir.x);
        char destination = stage[moveZ][moveX];
        
        switch(destination)
        {
            case 'W':
                break;

            case 'I':
                int nextX = (int)(moveX + dir.x);
                int nextZ = (int)(moveZ - dir.z);
                char nextItem = stage[nextZ][nextX];
                if ((nextItem == 'W' || nextItem == 'I') == false) // 플레이어가 아이템을 밀 수 있음
                {
                    if (nextItem != 'G')
                    {
                        stage[moveZ][moveX] = 'P';
                        stage[nextZ][nextX] = 'I';
                        player.Move(dir);
                        foreach(MoveableProp i in itemBoxs)
                        {
                            if (i.myPos.x == moveX && i.myPos.z == moveZ)
                            {
                                i.Move(dir);
                            }
                        }
                    }
                    else
                    {
                        stage[moveZ][moveX] = 'P';
                        stage[nextZ][nextX] = '.';
                        player.Move(dir);

                        foreach(MoveableProp item in itemBoxs)
                        {
                            //Debug.Log(item.gameObject.name + " 222");
                            //Debug.Log("item.myPos : " + item.myPos.x + ", " + item.myPos.z);
                            //Debug.Log("move : " + moveX + ", " + moveZ);
                            if (item.myPos.x == moveX && item.myPos.z == moveZ)
                            {
                                Debug.Log(item.gameObject.name);
                                item.gameObject.SetActive(false);
                            }
                        }

                        Vector3 goalKey = new Vector3(nextX, 0, nextZ);
                        if (goalDic.ContainsKey(goalKey) == true)
                        {
                            goalDic[goalKey].SetActive(false);
                        }
                        else
                            Debug.LogError("Goal 오브젝트가 없다니!!!");
                    }
                }
                break;

            case '.':
            case 'P':
            case 'G':
                player.Move(dir);
                break;
        }
    }

    GameObject LeavePropOnStage(GameObject propPrefab, int x, int z)
    {
        GameObject obj = Instantiate(propPrefab, stageTransform);

        SetPropPosition(obj, x, z);

        return obj;
    }

    void SetPropPosition(GameObject prop, int x, int z)
    {
        Vector3 newPos = new Vector3(x, 0f, -z);
        Vector3 correction = new Vector3((stage[z].Length * 0.5f), 0f, -(stage.Length * 0.5f));
        prop.transform.localPosition = newPos - correction - new Vector3(-0.5f, 0f, 0.5f);
    }

    /*
    int nextX = moveX + (int)dir.x;
    int nextZ = moveZ - (int)dir.z;
    char nextMove = stage[nextZ][nextX];
    if ((nextMove == 'W' || nextMove == 'I') == false)
    {
        stage[moveZ][moveX] = 'P';
        stage[nextZ][nextX] = 'I';
        MoveableProp ms = GetMoveableProp(moveX, moveZ);
        Debug.Log(ms.gameObject.name);
        ms.Move(dir);
        player.Move(dir);
    }

    MoveableProp GetMoveableProp(int x, int z)
    {
        Debug.Log("item : " + x + ", " + z);

        foreach (var item in itemBoxs)
        {
            int myX = (int)item.myPos.x;
            int myZ = (int)item.myPos.z;
            Debug.Log("my : " + myX + ", " + myZ);
            if (myX == x && myZ == z)
            {
                return item;
            }
        }
        return null;
    }
    */
}

