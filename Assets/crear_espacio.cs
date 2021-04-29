using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class crear_espacio : MonoBehaviour
{
    // Start is called before the first frame update
    public List<string> lista_pisos;
    Dictionary<string, string> muebles = new Dictionary<string, string>();
   
 
    public int contador=0;
    public Dropdown drop;

    //objetipo tipo espacio

    public class espacio { 
        public string imagen {
            get;
            set;
        }
        public string silla {
            get;
            set;
        }
        public string mesa
        {
            get;
            set;
        }
        public string gabinete
        {
            get;
            set;
        }
        public string comoda
        {
            get;
            set;
        }
        public string banco
        {
            get;
            set;
        }

    }

    public espacio esp = new espacio();
    //cuadro de alertas
       void Start()
    {     
    }
    public void piso_valuechange(Dropdown sender) {

        switch (sender.value)
        {
            case 1:
               
                GameStatus.piso = "mario";
                esp.imagen = GameStatus.piso;
                break;
            case 2:

                GameStatus.piso = "luigi";
                esp.imagen = GameStatus.piso;
                break;
            case 3:
  
                GameStatus.piso = "yoshi";
                esp.imagen = GameStatus.piso;
                break;
            case 4:

                GameStatus.piso = "peach";
                esp.imagen = GameStatus.piso;
                break;
            case 5:

                GameStatus.piso = "toad";
                esp.imagen = GameStatus.piso;
                break;
            case 6:

                GameStatus.piso = "bowser";
                esp.imagen = GameStatus.piso;
                break;
            default:
                Debug.Log("error");
                break;
        }
    }
    public void mueble_posicion_change(Dropdown sender) {
        if (sender.name == "drop2") {
            if (Ingresar_muebles_a_espacio(sender.options[sender.value].text, "silla")) {
                esp.silla = sender.options[sender.value].text;
            }
        }
        else if (sender.name == "drop3")
        {

            if (Ingresar_muebles_a_espacio(sender.options[sender.value].text, "mesa"))
            {
                esp.mesa = sender.options[sender.value].text;
            }

        }
        else if (sender.name == "drop4")
        {
            if (Ingresar_muebles_a_espacio(sender.options[sender.value].text, "gabinete"))
            {
                esp.gabinete = sender.options[sender.value].text;
            }

        }
        else if (sender.name == "drop5")
        {

            if (Ingresar_muebles_a_espacio(sender.options[sender.value].text, "comoda"))
            {
                esp.comoda = sender.options[sender.value].text;
            }

        }
        else
         if (sender.name == "drop6")
        {
            if (Ingresar_muebles_a_espacio(sender.options[sender.value].text, "banco"))
            {
                esp.banco = sender.options[sender.value].text;
            }

        }
    }
    //metodo que ingresa los muebles y donde vamos aver que no se repitan los muebles en el espacio
    public bool Ingresar_muebles_a_espacio(string posicion, string mueble) {
        if (!muebles.ContainsKey(posicion))
        {
            muebles.Add(posicion, mueble);
            return true;
        }
        else {
            if (EditorUtility.DisplayDialog("ERROR 0002", "\n¡¡¡¡Ya existe este mueble en otra posicion!!!!", "Ok"))
            {
                return false;
            }
            return false;

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void regresar() {
        SceneManager.LoadScene("MainMenu");
    }
    //inicializar de espacios
    
    public void mandardatos() {
        
        GameStatus.insertar_lista("imagen_" + GameStatus.contador_espacio.ToString(), GameStatus.piso);
        GameStatus.contador_espacio++;
        GameStatus.insertar_lista_espacios(esp);

        //No se podrá crear más de 6 espacios debido a la limitación de los pisos
        //metodo dentro del gamestatus para ver si hay mas de 6 espacios si lo hay-- tira error

        //aqui tambien ingresamos los espacios a la lista global de espacios
        if (GameStatus.Insertar_lista_imagen_pos_muebles(esp.imagen, muebles))
        {

            if (EditorUtility.DisplayDialog("EXITO!!", "Escenario Creado!!\n¿Desea crea otro objeto o regresar al menu principal?", "Crear otro", "Menu principal"))
            {
                //aqui agregamos al diccionario el espacio con su imagen

                SceneManager.LoadScene("crear_espacio");
            }
            else
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
