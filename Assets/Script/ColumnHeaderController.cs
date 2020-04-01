using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColumnHeaderController : MonoBehaviour
{   
    public GameObject game;

    public void CrearHeaders(string[] headers)
    {
        Text[] txt;
        for (int i = 0; i < headers.Length; i++)
        {
            Instantiate<GameObject>(game,this.transform);
        }
        
        txt = this.GetComponentsInChildren<Text>();        
        for (int i = 0; i < headers.Length; i++)
        {
            Debug.Log(headers[i]);
            txt[i].text=headers[i];
            //Debug.Log(headers[i]);
        }
    }
    public void LimpiarColum()
    {

        Text[] txt;
        txt = this.GetComponentsInChildren<Text>();
        for (int i = 0; i < txt.Length; i++)
        {
            Destroy(txt[i].gameObject);

        }
        //Destroy(this.gameObject);
    }
}
