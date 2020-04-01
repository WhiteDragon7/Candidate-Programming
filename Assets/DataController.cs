using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataController : MonoBehaviour
{
    GridLayoutGroup grid;
    public GameObject game;
    Text[] txt;

    private void Awake()
    {
        grid = GetComponent<GridLayoutGroup>();
    }
    public void CrearDataText(int n, List<string> data)
    {
        //para evitar problemas al realizar el re-load
        grid.constraintCount = n;//cantidad de filas
        for (int i = 0; i < data.Count; i++)
        {
            Instantiate<GameObject>(game,this.transform);
        }
        txt = this.GetComponentsInChildren<Text>();
        for (int i = 0; i < txt.Length; i++)
        {
            txt[i].text = data[i];
            //Debug.Log(headers[i]);
        }
        
    }


    public void LimpiarData()
    {
        for (int i = 0; i < txt.Length; i++)
        {
            Destroy(txt[i].gameObject);
        }
        //Destroy(this.gameObject);
    }
}
