using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    //lista para manejar el log de la bitacora 
    public static List<string> bitacora = new List<string>();

    public static void insertar_bitacora(string accion) {
        bitacora.Add(accion);
        
    }

    public static void EscribirBitacora()
    {
        try
        {
            
            StreamWriter sw = new StreamWriter("C:\\Users\\sharolin\\Desktop\\bitacora.txt");

            for (int i = 0; i < bitacora.Count; i++)
            {
                sw.WriteAsync(bitacora[i] + "\n");
            }            
            sw.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: ESCRIBIR ARCHIVO" + e.Message);
        }
        finally
        {
            Console.WriteLine("Executing finally block. ESCRIBIR ARCHIVO");
        }
    }

    public static void insertar_lista_espacios(crear_espacio.espacio espacio) {
        lista_imagen_sillas.Add(espacio);
    }
    public static void insertar_lista(string var1, string var2) {
        lista_espacios_imagen.Add(var1, var2);
    }
    public static bool Insertar_lista_imagen_pos_muebles(string piso, Dictionary<string, string> muebles) {
        if (lista_piso_muebles.Count <= 6)
        {
            if (verificar_espacio_doble_piso(piso) == false)
            {
                lista_piso_muebles.Add(piso, muebles);
                return true;
            }
            return false;

        }
        else {
            if (EditorUtility.DisplayDialog("ERROR 0001", "\n　　NO SE PUEDE CREAR MAS DE 6 ESPACIOS!!!!","Ok"))
            {
                SceneManager.LoadScene("crear_espacio");
            }
            return false;
        }


    }
    //manejo del error de mismo imagen en el diferentes pisos
    public static bool verificar_espacio_doble_piso(string piso) {
        if (lista_piso_muebles.ContainsKey(piso)){
            if (EditorUtility.DisplayDialog("ERROR 0004", "\n　　NO PUEDE HABER 2 ESPACIO CON ESE MISMO PISO!!!!", "Ok"))
            {
                SceneManager.LoadScene("crear_espacio");
            }
            return true;
        }
        return false;

    
    }
}
