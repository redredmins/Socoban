using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SIGameManager : MonoBehaviour
{
    /*
    1. 추상 클래스 Mover 를 만드시고,
       추상 메서드 void Move(), void Stop() 선언.
    
    2. Mover를 상속받은 Car, Airplane 클래스를 만드시고,
       자동차는 바닥을 x, z축으로 움직이고,
       비행기는 바닥에서 하늘로(y축)으로 뜨고 착륙하길 반복
       다른 움직임을 하도록 구현.
    
    3. 자동차, 비행기 프리팹 만들어서
       게임 메니저가 랜덤한 위치에 각각 3개, 1개 생성.
    
    4. UI버튼 만들고, 버튼을 누르면 모든 Mover가 멈추도록.
    */

    public GameObject carPrefab;
    public GameObject airplanePrefab;

    Mover[] movers;


    void Start()
    {
        movers = new Mover[4];
        movers[0] = CreateAirplane();
        movers[1] = CreateCar();
        movers[2] = CreateCar();
        movers[3] = CreateCar();
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10f, 10f, 100f, 50f), "STOP"))
        {
            foreach(var mover in movers)
            {
                mover.Stop();
            }
        }
    }

    Car CreateCar()
    {
        Vector3 randomVec = new Vector3(Random.Range(-20f, 20f), 0f, Random.Range(-20f, 20f));
        GameObject carObj = CreateMover(carPrefab, randomVec);
        return carObj.GetComponent<Car>();
    }

    Airplane CreateAirplane()
    {
        Vector3 randomVec = new Vector3(Random.Range(-20f, 20f), Random.Range(10f, 20f), Random.Range(-20f, 20f));
        GameObject airplaneObj = CreateMover(airplanePrefab, randomVec);
        return airplaneObj.GetComponent<Airplane>();
    }

    GameObject CreateMover(GameObject prefab, Vector3 pos)
    {
        return Instantiate(prefab, pos, Quaternion.identity);
    }
}
