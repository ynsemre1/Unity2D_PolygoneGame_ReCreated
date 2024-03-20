using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHover : MonoBehaviour
{
    public void ShowObject()
    {
        gameObject.SetActive(true);
    }

    public void HideObject()
    {
        gameObject.SetActive(false);
    }
}
