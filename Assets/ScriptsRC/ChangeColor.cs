using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{   
    public GameObject platformObject;
    public GameObject enemyObject;
    public HardLight2D hardLight2D;

    void Start()
    {
        // Random Color Create
        Color randomColor = new Color(Random.value, Random.value, Random.value);

        // Change the color of the object by using the generated random color in a material
        platformObject.GetComponent<Renderer>().material.color = randomColor;
        enemyObject.GetComponent<Renderer>().material.color = randomColor;
        hardLight2D.Color = randomColor;
    }
}
