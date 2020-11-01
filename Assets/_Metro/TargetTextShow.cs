using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class TargetTextShow : MonoBehaviour
{
    public GameObject player;
    public TextMeshPro TextMeshProPrefab;
    private GameObject textMesh;

    void Start()
    {
        TextMeshPro clone  = Instantiate(TextMeshProPrefab, gameObject.transform);
        clone.text = gameObject.name;
        textMesh = clone.gameObject;
    }

    void Update()
    {
        textMesh.transform.LookAt(player.transform.position);
        textMesh.transform.Rotate(0, 180, 0);
    }
}
