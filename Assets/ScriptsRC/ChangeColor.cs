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
        // Rastgele bir renk oluştur
        Color randomColor = new Color(Random.value, Random.value, Random.value);

        // Oluşturulan rastgele rengi bir materyalde kullanarak nesnenin rengini değiştir
        platformObject.GetComponent<Renderer>().material.color = randomColor;
        enemyObject.GetComponent<Renderer>().material.color = randomColor;
        hardLight2D.Color = randomColor;
    }
}
