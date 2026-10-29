using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class ConectarAPI : MonoBehaviour
{
    string texto_endpoint = "http://localhost:3000/";
    [Header("GET")]
    //--------------GET----------------
    [SerializeField] TMP_Text textoGet;
    [Header("POST")]

    //--------------POST---------------
    [SerializeField] TMP_InputField input_nombre;
    [SerializeField] TMP_InputField input_precio;
    [SerializeField] TMP_Dropdown input_marca;
    [Header("PUT")]

    //--------------PUT---------------
    [SerializeField] TMP_InputField put_input_indice;
    [SerializeField] TMP_InputField put_input_nombre;
    [SerializeField] TMP_InputField put_input_precio;
    [SerializeField] TMP_Dropdown put_input_marca;

    [Serializable]

    class Papitas
    {
        public string nombre;
        public int precio;
        public string marca;
    }
    
    class Frituras
    {
        public Papitas[] papitas;
    }

    enum Marcas
    {
        Doritos, Takis, Chips, Cheetos, Sabritas
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input_marca.ClearOptions();

        List<string> listaOpciones = new List<string>();
        for(int i = 0; i < 5; i++)
        {
            listaOpciones.Add(((Marcas) i).ToString());
        }

        input_marca.AddOptions(listaOpciones);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ConsultarPapitas()
    {
        StartCoroutine(GetPapitas());
    }

    IEnumerator GetPapitas()
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(texto_endpoint);
        yield return webRequest.SendWebRequest();
        Debug.Log(webRequest.downloadHandler.text);

        Frituras frituras = JsonUtility.FromJson<Frituras>(webRequest.downloadHandler.text);
        textoGet.text = "";
        foreach(Papitas papitas in frituras.papitas)
        {
            textoGet.text += "\n----\nMarca: " + papitas.marca +
            "\nNombre: " + papitas.nombre + "\nPrecio: " + papitas.precio;
        }

        //textoGet.text = webRequest.downloadHandler.text;
    }

    public void CrearPapitas()
    {
        Papitas papitas = new Papitas();
        papitas.nombre = input_nombre.text;
        papitas.precio = int.Parse(input_precio.text);
        papitas.marca = ((Marcas)input_marca.value).ToString();

        string texto_papitas = JsonUtility.ToJson(papitas);

        Debug.Log(texto_papitas);
        StartCoroutine(PostPapitas(texto_papitas));
    }

    IEnumerator PostPapitas(string texto_json)
    {
        UnityWebRequest webRequest = UnityWebRequest.Post(texto_endpoint, texto_json, "application/json");
        yield return webRequest.SendWebRequest();
        Debug.Log(webRequest.downloadHandler.text);
    }
}
