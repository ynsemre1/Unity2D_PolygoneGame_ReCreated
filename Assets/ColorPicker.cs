using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Color"))
        {
            // Çarpışma yapan objenin rengini al
            Color objectColor = other.GetComponent<Renderer>().material.color;

            // Alınan rengi kullanabilirsiniz
            Debug.Log("Çarpışan objenin rengi: " + objectColor);

            // Topun rengini değiştirmek isterseniz:
            GetComponent<Renderer>().material.color = objectColor;
        }
    }
}
