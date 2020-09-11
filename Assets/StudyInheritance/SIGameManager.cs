using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SIGameManager : MonoBehaviour
{
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
