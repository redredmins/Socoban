using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyArray : MonoBehaviour
{
    // 1. 정해진 2차원 어레이의 내용을 바탕으로 8x8 맵에 나무 배치
    // 2. 각 나무의 크기와 색을 랜덤하게 변경

    // 배열
    char[] lovel = new char[8]
    {
        '0', '0', '0', '0', '0', '0', '0', '0'
    };

    // 2차원 배열
    char[,] levelMap = new char[5,8]
    {
        { 'T', 'T', 'T', '.', 'T', '.', 'T', 'T' },
        { 'T', '.', '.', 'T', 'T', '.', '.', 'T' },
        { 'T', 'T', '.', '.', 'T', '.', '.', 'T' },
        { '.', 'T', '.', '.', 'T', '.', 'T', 'T' },
        { 'T', 'T', '.', 'T', 'T', 'T', 'T', 'T' }
    };

    // 3차원 배열
    char[,,] threeArray = new char[2,3,4]
    {
        { { '0', '1', '2', '0' }, { '3', '4', '5', '3' }, { '3', '4', '5', '3' } },
        { { '0', '1', '2', '0' }, { '3', '4', '5', '3' }, { '3', '4', '5', '3' } }
    };

    // 가변 배열
    char[][] array = new char[8][]
    {
        new char[8] { 'T', 'T', 'T', '.', 'T', '.', 'T', 'T' }, // 0
        new char[8] { 'T', '.', '.', 'T', 'T', '.', '.', 'T' },
        new char[8] { 'T', 'T', '.', '.', 'T', '.', '.', 'T' },
        new char[3] { '.', '.', 'T' },                          // 3
        new char[5] { 'T', '.', '.', 'T', '.' },
        new char[8] { 'T', '.', '.', '.', '.', '.', '.', 'T' },
        new char[8] { '.', 'T', '.', '.', 'T', '.', 'T', 'T' },
        new char[8] { 'T', 'T', '.', 'T', 'T', 'T', 'T', 'T' }
    };

    public GameObject treePrefab;
    public Transform landTrans;
    public Color[] treeColors;


    void Start()
    {
        // 가변 배열의 크기 가져오는 방법
        int sizeOfArray = array.Length; // => 8
        int sizeOfArrayInArrat = array[3].Length; // => 3

        // 2차원 배열의 크기 가져오는 방법
        int firstSizeOfMap = levelMap.GetLength(0); // => 5
        int secSizeOfMap = levelMap.GetLength(1);   // => 8

        // 3차원 배열 크기
        int thirdSizeOfArray = threeArray.GetLength(2); // => 4

        CreateMap();
    }

    void CreateMap()
    {
        for (int z = 0; z < levelMap.GetLength(0); z++)
        {
            for (int x = 0; x < levelMap.GetLength(1); x++)
            {
                if (levelMap[z,x] == 'T')
                {
                    GameObject treeObj = Instantiate(treePrefab, landTrans);

                    Vector3 newPos = new Vector3(x, 0.5f, -z);
                    Vector3 correction = new Vector3((levelMap.GetLength(1) * 0.5f), 0f, -(levelMap.GetLength(0) * 0.5f));
                    treeObj.transform.localPosition = newPos - correction - new Vector3(-0.5f, 0f, 0.5f);

                    float randomNum = Random.Range(0.7f, 1.3f);
                    Vector3 randomScale = new Vector3(randomNum, randomNum, randomNum);
                    treeObj.transform.localScale = randomScale;

                    int randomIndex = Random.Range(0, treeColors.Length);
                    treeObj.GetComponent<Tree>().leafRenderer.material.color = treeColors[randomIndex];

                    //Renderer[] treeChildRenderers = treeObj.GetComponentsInChildren<Renderer>();
                }
            }
        }
    }
}
