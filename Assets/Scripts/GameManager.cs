using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 
    char[][] stage = new char[10][]
    {
        //              0    1    2    3    4    5    6    7    8    9
        new char[10] { 'W', 'W', 'W', 'W', 'W', '.', 'W', 'W', 'W', '.'}, // 0
        new char[10] { 'W', '.', '.', '.', 'W', '.', 'W', 'G', 'W', '.'}, // 1
        new char[10] { 'W', '.', 'I', '.', 'W', '.', 'W', 'G', 'W', '.'}, // 2
        new char[10] { 'W', '.', 'I', '.', 'W', '.', 'W', 'G', 'W', '.'}, // 3
        new char[10] { 'W', 'W', 'W', '.', 'W', 'W', 'W', '.', 'W', '.'}, // 4
        new char[10] { '.', 'W', 'W', '.', '.', 'P', '.', '.', 'W', '.'}, // 5
        new char[10] { '.', 'W', '.', 'I', '.', 'W', '.', '.', 'W', '.'}, // 6
        new char[10] { '.', 'W', '.', '.', '.', 'W', 'W', 'W', 'W', '.'}, // 7
        new char[10] { '.', 'W', 'W', 'W', 'W', 'W', '.', '.', '.', '.'}, // 8
        new char[10] { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.'}  // 9
    };

    public Transform stageTransform;
    public GameObject wallPrefab;


    void Start()
    {
        for(int z = 0; z < stage.Length; ++z)
        {
            for(int x = 0; x < stage[z].Length; ++x)
            {
                if (stage[z][x] == 'W')
                {
                    GameObject wallObj = Instantiate(wallPrefab, stageTransform);

                    Vector3 newPos = new Vector3(x, 0.5f, -z);
                    Vector3 correction = new Vector3((stage[z].Length * 0.5f), 0f, -(stage.Length * 0.5f));
                    wallObj.transform.localPosition = newPos - correction - new Vector3(-0.5f, 0f, 0.5f);
                }
            }
        }

    }

}
