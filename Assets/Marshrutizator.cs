using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Marshrutizator : MonoBehaviour
{

    public GameObject[] stations3D;

    public GameObject station1, station2;
    public TextMeshProUGUI textMesh1, textMesh2;
    public string deftext1, deftext2;

    public GameObject backGround;
    public GameObject repButton;

    public GameObject AIplayer;
    public GameObject target;

    public float scale;

    public Material m1, m2, defM;
    

    private Vector3 startPosition;




    void Awake()
    {
        deftext1 = textMesh1.text;
        deftext2 = textMesh2.text;

        backGround.SetActive(true);

        AIplayer.SetActive(false);
        target.SetActive(false);

        repButton.SetActive(false);

    }

    void Update()
    {

    }

    public  void SelectStation(GameObject objectClicked)
    {
        if (station2 != null)
        {
            if(station2 == objectClicked)
            {
                station2 = null;
                textMesh2.text = deftext2;

            }
        }
        if (station1 != null )
        {
            if (station1 == objectClicked)
            {
                station1 = null;
                textMesh1.text = deftext1;
            }
            else
            {
                station2 = objectClicked;
                textMesh2.text = station2.name;

            }
        }
        else
        {
            station1 = objectClicked;
            textMesh1.text = station1.name;

        }

        if (station1 != null && station2 != null)
        {
            ShowBestWay(station1, station2);
        }


    }

    void ShowBestWay(GameObject s1, GameObject s2)
    {
        stations3D[s1.transform.GetSiblingIndex()].GetComponent<Renderer>().material = m1;
        stations3D[s2.transform.GetSiblingIndex()].GetComponent<Renderer>().material = m2;


        backGround.SetActive(false);
        AIplayer.SetActive(true);
        target.SetActive(true);

        repButton.SetActive(true);


        Vector2 v2 = s1.transform.position;
        Vector3 v3 = new Vector3
        (
            v2.x * scale,
            0,
            v2.y * scale
        );

        startPosition = v3 + Vector3.up * 3;
        AIplayer.transform.localPosition = startPosition;
         v2 = s2.transform.position;
         v3 = new Vector3
        (
            v2.x * scale,
            0,
            v2.y * scale
        );




        target.transform.localPosition = v3;
        stations3D[s2.transform.GetSiblingIndex()].AddComponent<triggerStation>();
    }


    public void RepeatWay()
    {
        AIplayer.transform.localPosition = startPosition;

    }





    public void RepeatButton()
    {
        backGround.SetActive(true);
        AIplayer.SetActive(false);
        target.SetActive(false);

        stations3D[station1.transform.GetSiblingIndex()].GetComponent<Renderer>().material = defM;
        stations3D[station2.transform.GetSiblingIndex()].GetComponent<Renderer>().material = defM;




        station1 = null;
        textMesh1.text = deftext1;

Destroy(stations3D[station2.transform.GetSiblingIndex()].GetComponent<triggerStation>());
        station2 = null;
        textMesh2.text = deftext2;
        repButton.SetActive(false);

    }


}
