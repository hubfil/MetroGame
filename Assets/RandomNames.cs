using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class RandomNames : MonoBehaviour
{

     enum Snames
    {
        Авиамоторная,
Академическая,
Александровскийсад,
Алексеевская,
Алтуфьево,
Аннино,
Арбатская,
Автозаводская,
Аэропорт
    }

    public GameObject stationHolder;

    public GameObject station3Dprefab;
    public float scale;

    public Marshrutizator marshrutizator;
    public GameObject TargetText;

    public NavMeshSurface navMesh1;
    public GameObject plane1;
    public GameObject[] builders;


    void Start()
    {
        string[] enums = Enum.GetNames(typeof(Snames));
        string randomItem;


        int stationCount = stationHolder.transform.childCount;

        marshrutizator.stations3D = new GameObject[stationCount];
        builders = new GameObject[stationCount];

        for (int i = 0; i < stationCount;  i++)
        {
            randomItem = enums[UnityEngine.Random.Range(0, enums.Length - 1)];
            stationHolder.transform.GetChild(i).name = randomItem;
            stationHolder.transform.GetChild(i).gameObject.
                transform.GetChild(0).
                GetComponent<TextMeshProUGUI>().text = randomItem;
            stationHolder.transform.GetChild(i).gameObject.
                transform.GetChild(0).
                GetComponent<TextMeshProUGUI>().color = Color.black;
            stationHolder.transform.GetChild(i).gameObject.
                AddComponent<StationClicker>();
            Create3DStation(stationHolder.transform.GetChild(i).position, i, randomItem);

        }
        Debug.Log("BuildNavMesh started");
        plane1.SetActive(false);
        builders = GameObject.FindGameObjectsWithTag("builder");
        foreach (GameObject a in builders)
        {
            Debug.Log(a.name + " BuildNavMesh");
            a.isStatic = true;
            //a.GetComponent<NavMeshSurface>().BuildNavMesh();
        }
    }

    void Update()
    {

    }

    void Create3DStation(Vector2 v2, int index,string name)
    {
        Vector3 v3 = new Vector3
        (
            v2.x * scale,
            0,
            v2.y * scale
        );
        marshrutizator.stations3D[index] = 
Instantiate(station3Dprefab, v3, Quaternion.identity);
        marshrutizator.stations3D[index].isStatic = true;



            Instantiate(TargetText, v3+ Vector3.up * 10, Quaternion.identity).
            GetComponent<TextMeshPro>().text = name;

    }
}
