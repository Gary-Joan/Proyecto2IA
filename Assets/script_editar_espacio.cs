using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class script_editar_espacio : MonoBehaviour
{
    Dictionary<string, string> muebles = new Dictionary<string, string>();
    String silla, mesa, gabinete, comoda, banco;
    String piso_entrante;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("drop1").GetComponent<Dropdown>().value = getvalor_imagen(GameStatus.lista_imagen_sillas[GameStatus.espacio_seleccionado].imagen);
        GameObject.Find("drop2").GetComponent<Dropdown>().value = getvalor_posicion(GameStatus.lista_imagen_sillas[GameStatus.espacio_seleccionado].silla);
        GameObject.Find("drop3").GetComponent<Dropdown>().value = getvalor_posicion(GameStatus.lista_imagen_sillas[GameStatus.espacio_seleccionado].mesa); ;
        GameObject.Find("drop4").GetComponent<Dropdown>().value = getvalor_posicion(GameStatus.lista_imagen_sillas[GameStatus.espacio_seleccionado].gabinete); ;
        GameObject.Find("drop5").GetComponent<Dropdown>().value = getvalor_posicion(GameStatus.lista_imagen_sillas[GameStatus.espacio_seleccionado].comoda); ;
        GameObject.Find("drop6").GetComponent<Dropdown>().value = getvalor_posicion(GameStatus.lista_imagen_sillas[GameStatus.espacio_seleccionado].banco); ;
        piso_entrante = GameStatus.lista_imagen_sillas[GameStatus.espacio_seleccionado].imagen;
    }

 

    private int getvalor_imagen(string imagen)
    {
        if (imagen == "mario") { return 1; }
        else if (imagen == "luigi") { return 2; }
        else if (imagen == "yoshi") { return 3; }
        else if (imagen == "peach") { return 4; }
        else if (imagen == "toad")  { return 5; }
        else if (imagen == "bowser"){ return 6; }
        return 0;

    }
    private int getvalor_posicion(string imagen)
    {
        if (imagen == "Noreste") { return 1; }
        else if (imagen == "Sureste") { return 2; }
        else if (imagen == "Centro") { return 3; }
        else if (imagen == "Noroeste") { return 4; }
        else if (imagen == "Suroeste") { return 5; }
        return 0;

    }
    public void guardar() {

        if (GameStatus.contador_espacio == 7)
        {
            if (EditorUtility.DisplayDialog("ERROR", "No se puede editar ningun espacio, borre 1", "OK", "Menu principal"))
            {              
                return;
            }
            return;
        }
        //insertamos los valores de los drop en la lista de muebles
        muebles.Add(silla, "silla");
        muebles.Add(mesa, "mesa");
        muebles.Add(gabinete, "gabinete");
        muebles.Add(comoda, "comoda");
        muebles.Add(banco, "banco");

        if (EditorUtility.DisplayDialog("Edicion de espacio.", "\n¿Desea Guardar los cambios?", "Si", "No"))
        {
            //aqui agregamos al diccionario el espacio con su imagen
            GameStatus.lista_imagen_sillas[GameStatus.espacio_seleccionado].imagen = GameStatus.piso;
            GameStatus.lista_imagen_sillas[GameStatus.espacio_seleccionado].silla = silla;
            GameStatus.lista_imagen_sillas[GameStatus.espacio_seleccionado].mesa = mesa;
            GameStatus.lista_imagen_sillas[GameStatus.espacio_seleccionado].gabinete = gabinete;
            GameStatus.lista_imagen_sillas[GameStatus.espacio_seleccionado].comoda = comoda;
            GameStatus.lista_imagen_sillas[GameStatus.espacio_seleccionado].banco = banco;
            //
            GameStatus.lista_piso_muebles.Remove(piso_entrante);
            GameStatus.Insertar_lista_imagen_pos_muebles(GameStatus.piso, muebles);
            SceneManager.LoadScene("lista_editar_espacio");
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
       

    }
    public void regresar()
    {
       
        SceneManager.LoadScene("MainMenu");
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void mueble_posicion_change(Dropdown sender)
    {   if (sender.name == "drop1") {
            if (GameStatus.espacio_seleccionado == 0) {GameStatus.lista_espacios_imagen["imagen_1"] = get_imagen_nuevo_espacio(sender) ;
            }
            else if (GameStatus.espacio_seleccionado == 1){GameStatus.lista_espacios_imagen["imagen_2"] = get_imagen_nuevo_espacio(sender);
            }
            else if (GameStatus.espacio_seleccionado == 2){GameStatus.lista_espacios_imagen["imagen_3"] = get_imagen_nuevo_espacio(sender);
            }
            else if (GameStatus.espacio_seleccionado == 3){GameStatus.lista_espacios_imagen["imagen_4"] = get_imagen_nuevo_espacio(sender);
            }
            else if (GameStatus.espacio_seleccionado == 4){GameStatus.lista_espacios_imagen["imagen_5"] = get_imagen_nuevo_espacio(sender);
            }
            if (GameStatus.espacio_seleccionado == 5) { GameStatus.lista_espacios_imagen["imagen_6"] = get_imagen_nuevo_espacio(sender);
            }

        }
        else if (sender.name == "drop2")
        {
            silla = sender.options[sender.value].text;
            //muebles.Add(sender.options[sender.value].text, "silla");
           


        }
        else if (sender.name == "drop3")
        {
            mesa = sender.options[sender.value].text;
           // muebles.Add(sender.options[sender.value].text, "mesa");


        }
        else if (sender.name == "drop4")
        {
            gabinete = sender.options[sender.value].text;
            //muebles.Add(sender.options[sender.value].text, "gabinete");
       

        }
        else if (sender.name == "drop5")
        {
            comoda = sender.options[sender.value].text;
           // muebles.Add(sender.options[sender.value].text, "comoda");


        }
        else
         if (sender.name == "drop6")
        {
            banco = sender.options[sender.value].text;
            //muebles.Add(sender.options[sender.value].text, "banco");


        }
    }

    private string get_imagen_nuevo_espacio(Dropdown sender)
    {
        switch (sender.value)
        {
            case 1:

                GameStatus.piso = "mario";
                return GameStatus.piso;
            case 2:

                GameStatus.piso = "luigi";

                return GameStatus.piso;
            case 3:

                GameStatus.piso = "yoshi";

                return GameStatus.piso;
            case 4:

                GameStatus.piso = "peach";

                return GameStatus.piso;
            case 5:

                GameStatus.piso = "toad";

                return GameStatus.piso;
            case 6:

                GameStatus.piso = "bowser";

                return GameStatus.piso;
            default:
                Debug.Log("error");
                return "";
        }
    }
}
