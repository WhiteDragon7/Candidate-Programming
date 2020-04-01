using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{
    Text txt;
    private void Awake()
    {
        txt = GetComponentInChildren<Text>();        
    }
    public void NamelesTitle(string str)
    {
        txt.text = str;
    }

    public void LimpiarTitle()
    {
        txt.text = string.Empty;
    }
}