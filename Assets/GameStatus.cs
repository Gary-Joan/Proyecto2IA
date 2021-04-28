using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    // Start is called before the first frame update
    static public string piso = "";
    static public Dictionary<string, string> muebles_posicion;
    public static Dictionary<string, string> lista_espacios_imagen = new Dictionary<string, string>();
    public static int contador_espacio = 1;
    public static int espacio_seleccionado;
    public static List<crear_espacio.espacio> lista_imagen_sillas = new List<crear_espacio.espacio>();
    public static Dictionary<string, Dictionary<string, string>> lista_piso_muebles = new Dictionary<string, Dictionary<string, string>>();
    public static void insertar_lista_espacios(crear_espacio.espacio espacio) {
        lista_imagen_sillas.Add(espacio);
    }
    public static void insertar_lista(string var1, string var2) {
        lista_espacios_imagen.Add(var1, var2);
    }
    public static void insertar_lista_imagen_pos_muebles(string piso, Dictionary<string, string> muebles) {
        lista_piso_muebles.Add(piso, muebles);
    
    }
    // public static Dictionary<string, string> Lista_espacios_imagen { get => lista_espacios_imagen; set => lista_espacios_imagen = value; }
}
