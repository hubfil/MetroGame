using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    public Transform targetT;
    public Transform ginger1, ginger2, purple1, purple2;
    public Transform exit1, exit2;

    void Start()
    {
        ginger1 = GameObject.Find("ginger1").GetComponent<Transform>();
        ginger2 = GameObject.Find("ginger2").GetComponent<Transform>();
        purple1 = GameObject.Find("purple1").GetComponent<Transform>();
        purple2 = GameObject.Find("purple2").GetComponent<Transform>();
        exit1 = GameObject.Find("exit1").GetComponent<Transform>();
        exit2 = GameObject.Find("exit2").GetComponent<Transform>();





    }

    void Update()
    {

    }

    public void DirectionButton(string direction)
    {
        Debug.Log("Btton clicked");
        switch (direction)
        {
            case "ginger1":
                targetT.position = ginger1.position + Vector3.down * 5;
                break;
            case "ginger2":
                targetT.position = ginger2.position + Vector3.down * 5;
                break;
            //purple
            case "purple1":
                targetT.position = purple1.position + Vector3.down * 5;
                break;
            case "purple2":
                targetT.position = purple2.position + Vector3.down * 5;
                break;      
            case "exit1":
                targetT.position = exit1.position + Vector3.down * 5;
                break;

            case "exit2":
                targetT.position = exit2.position + Vector3.down * 5;
                break;

            default:
                Debug.Log(direction + "не распознал");
                break;


        }
    }
}
