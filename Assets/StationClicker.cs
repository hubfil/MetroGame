using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StationClicker : MonoBehaviour, IPointerClickHandler
{

    public GameObject Marshrutizator;

    void Start()
    {
        Marshrutizator = GameObject.Find("Marshrutizator");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(gameObject.name + " Clicked");
        Marshrutizator.GetComponent<Marshrutizator>().SelectStation(gameObject);
    }
}
