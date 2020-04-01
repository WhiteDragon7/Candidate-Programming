using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Serialization;

public class LectoJson : MonoBehaviour
{
    
    //[SerializeField]
    //public CollData cData;
    //objData dat;
    public Collection collecttion;
    public string jsonData;
    public string filePath ="/StreamingAssets/JsonChallenge.json";

    Dictionary<string, List<string>> Data;
    private void Start()
    {
        DataLoad();

        //t[0], no importa
        //for (int i = 0; i < t.Length; i++)
        //{
        //    t[i].Trim();
        //    Debug.Log(t[i]);
        //    Debug.Log(t[i].IndexOf(collecttion.ColumnHeaders[0]));
        //    Debug.Log(t[i].);
        //}

        //Debug.Log(collecttion.ColumnHeaders[0]);//usar columnHeaders para almacenar las variables de Data
        //Debug.Log(d.IndexOf(collecttion.ColumnHeaders[0]));

        //cData = JsonUtility.FromJson<CollData>(d);
    }

    public void Imprimir(string str)
    {
        Debug.Log(str);
    }

    public void DataLoad()
    {
        jsonData = File.ReadAllText(Application.dataPath + filePath);
        collecttion = JsonUtility.FromJson<Collection>(jsonData);//guardamos los datos conocidos

        //reconstruimos el formato del campo Data
        string[] t = jsonData.ToString().Split(']');
        string d = "{" + t[1].TrimStart(',') + "]" + t[2];
        //Debug.Log(d);
        //no pude guardar los datos de Data sin tener los nombres de las variables 

        //limpieza de texto para lograr
        //"x"+collecttion.ColumnHeaders[0]+"\" : \""+valor buscado+"\"" 
        //split por ','
        string[] m = d.ToString().Split('[');
        d = m[1];
        t = d.ToString().Split(',');//cadenas separadas

        //List<string>[] Data =new List<string>;
        this.Data = new Dictionary<string, List<string>>();
        List<string> listData = new List<string>();
        for (int j = 0; j < collecttion.ColumnHeaders.Length; j++)//repetimos por la cantidad de ColumnHeaders
        {

            for (int i = 0; i < t.Length; i++) //recorremos la lista de string
            {
                //Debug.Log(t[i]);

                if (t[i].Contains(collecttion.ColumnHeaders[j]))
                {

                    int first = t[i].IndexOf(collecttion.ColumnHeaders[j]) + collecttion.ColumnHeaders[j].Length + 5;
                    int last = t[i].LastIndexOf("\"");
                    string str = t[i].Substring(first, last - first);//valor sustraido
                    listData.Add(str);

                    //Debug.Log(str);
                    //Debug.Log(Data[0]);
                    //diccionario que recibe (collecttion.ColumnHeaders[j]) y (valor sustraido)
                    //collecttion.ColumnHeaders[j] corresponde a Key
                    //Imprimir(Data[j][i]);                   
                }
            }
            this.Data.Add(collecttion.ColumnHeaders[j], listData);
            //Imprimir("hay " + this.Data[collecttion.ColumnHeaders[j]].Count + " string que corresponden a la cabezera : " + collecttion.ColumnHeaders[j]);
            //Imprimir("primer valor " + this.Data[collecttion.ColumnHeaders[j]][0]);

            listData = new List<string>();//limpiamos Data
        }

        TableData();
    }


    void TableData()
    {
        //title
        TitleController tc = GetComponentInChildren<TitleController>();
        tc.NamelesTitle(collecttion.Title);
        //ColumHeaders
        ColumnHeaderController cc = GetComponentInChildren<ColumnHeaderController>();
        cc.CrearHeaders(collecttion.ColumnHeaders);
        //Data       
        List<string> dat = new List<string>();
        foreach (string key in Data.Keys)
        {
            //Debug.Log(key); ColumHeaders
            foreach (string val in Data[key])
            {
                //Debug.Log(val); Data
                dat.Add(val);
            }
        }
        int n = 0;//cantidad de filas
        for (int i = 0; i < Data.Count; i++)
        {
            int m = Data[collecttion.ColumnHeaders[i]].Count;
            if (m>n)
            {
                n = m;
            }
        }

        DataController dc = GetComponentInChildren<DataController>();
        dc.CrearDataText(n,dat);

    }



    //limpiamos datos y tabla; invocado desde el boton
    public void LimpiarTabla()
    {
        TitleController tc = GetComponentInChildren<TitleController>();
        tc.LimpiarTitle();
        ColumnHeaderController cc = GetComponentInChildren<ColumnHeaderController>();
        cc.LimpiarColum();
        DataController dc = GetComponentInChildren<DataController>();
        dc.LimpiarData();

        jsonData = string.Empty;
        collecttion = new Collection();


        ///

        Recrear();
    }






    public GameObject columHeader;
    public GameObject dataObject;
    public void Recrear()
    {
        //Instantiate<GameObject>(columHeader,this.transform);
        //Instantiate<GameObject>(dataObject,this.transform);        
        DataLoad();
    }
}


