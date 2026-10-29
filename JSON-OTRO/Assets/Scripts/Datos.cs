using System;
using System.Collections;
using UnityEngine;

public class Datos : MonoBehaviour
{
    string datos_texto;

    class Jugador
    {
        public int vidas;
        public float energia;
        public int dinero;
        public InfoJugador info_jugador;
        public Items[] inventario;
    }

    [Serializable]
    class InfoJugador
    {
        public string nombre;
        public string color_favorito;
        public int edad;
    }

    [Serializable]
    class Items
    {
        public string nombre_item;
        public string descripcion;
        public int cantidad;
        public Costo costco;
    }

    [Serializable]
    class Costo
    {
        public int compra;
        public int venta;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*
        datos_texto = "{\r\n    \"vidas\" : 15,\r\n    \"energia\" : 30,\r\n    \"dinero\" : 300,\r\n\r\n    \"info_jugador\" : {\r\n        \"nombre\" : \"Pedro123\",\r\n        \"color_favorito\" : \"verde\",\r\n        \"edad\" : 15,\r\n        \"cumpleanos\" : {\r\n            \"dia\" : 10,\r\n            \"mes\" : 4\r\n        }\r\n    },\r\n\r\n    \"inventario\" : [\r\n        {\r\n            \"nombre_item\" : \"Espada de fuego\",\r\n            \"descripcion\" : \"Espada forjada por los elfos nativos del fuego\",\r\n            \"cantidad\" : 1,\r\n            \"costco\" : {\r\n                \"compra\" : 300,\r\n                \"venta\" : 340\r\n            }\r\n        },\r\n        {\r\n            \"nombre_item\" : \"Arco\",\r\n            \"descripcion\" : \"Arco para disparar flechas\",\r\n            \"cantidad\" : 2,\r\n            \"costco\" : {\r\n                \"compra\" : 90,\r\n                \"venta\" : 110\r\n            }\r\n        },\r\n        {\r\n            \"nombre_item\" : \"Flechas de cuerno de unicornio\",\r\n            \"descripcion\" : \"Flechas hechas con cuernos de unicornio cazados duarnte la primavera por enanos salvajes.\",\r\n            \"cantidad\" : 500,\r\n            \"costco\" : {\r\n                \"compra\" : 20,\r\n                \"venta\" : 30\r\n            }\r\n        }\r\n    ]\r\n}";

        Jugador objeto_jugador = JsonUtility.FromJson<Jugador>(datos_texto);

        Debug.Log(objeto_jugador.inventario[2].costco.compra);
        */

        /*
        Jugador objeto_jugador = new Jugador();
        objeto_jugador.vidas = 4;
        objeto_jugador.energia = 50;
        objeto_jugador.dinero = 100;

        objeto_jugador.info_jugador = new InfoJugador();
        objeto_jugador.info_jugador.nombre = "vicksvaporub";
        objeto_jugador.info_jugador.color_favorito = "Verde";
        objeto_jugador.info_jugador.edad = 22;

        objeto_jugador.inventario = new Items[2];

        objeto_jugador.inventario[0] = new Items();
        objeto_jugador.inventario[0].nombre_item = "Zapato";
        objeto_jugador.inventario[0].descripcion = "Un papo";
        objeto_jugador.inventario[0].cantidad = 5;
        objeto_jugador.inventario[0].costco = new Costo();
        objeto_jugador.inventario[0].costco.compra = 1;
        objeto_jugador.inventario[0].costco.venta = 2;

        objeto_jugador.inventario[1] = new Items();
        objeto_jugador.inventario[1].nombre_item = "Chicle";
        objeto_jugador.inventario[1].descripcion = "Chicle bomba que si pega";
        objeto_jugador.inventario[1].cantidad = 10;
        objeto_jugador.inventario[1].costco = new Costo();
        objeto_jugador.inventario[1].costco.compra = 6;
        objeto_jugador.inventario[1].costco.venta = 9;

        

        string dato_texto = JsonUtility.ToJson(objeto_jugador);

        Debug.Log(dato_texto);

        */

        /*
        string datos_incriptados = AESEncryption.Encrypt(datos_texto);

        Debug.Log(datos_incriptados);

        //PlayerPrefs.SetString("datos", dato_texto);

        Debug.Log(dato_texto);
        */

        //INICIA MiFuncion. PASA A SER CORUTINA.
        StartCoroutine(MiFuncion(24));

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator MiFuncion(int valor)
    {
        Debug.Log("bai");
        Debug.Log("hola" + valor);
        yield return new WaitForSeconds(2);
        Debug.Log("vamonos");
        yield return 0;
    }
}
