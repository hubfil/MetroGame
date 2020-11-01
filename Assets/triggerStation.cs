using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerStation : MonoBehaviour
{
    public GameObject Marshrutizator;

    void Start()
    {
        Marshrutizator = GameObject.Find("Marshrutizator");
    }


    private void OnTriggerEnter(Collider other)
    {
        Marshrutizator.GetComponent<Marshrutizator>().RepeatWay();
    }
}
