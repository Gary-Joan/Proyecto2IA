using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class script_eliminar_espacio : MonoBehaviour
{
    public UnityEngine.UI.ToggleGroup ToggleGroup;
    Texture2D myTexture;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var entry in GameStatus.lista_espacios_imagen)
        {
            Debug.Log(entry.Key + ":" + entry.Value);
            myTexture = Resources.Load(entry.Value) as Texture2D;
            GameObject rawImage = GameObject.Find(entry.Key);
            rawImage.GetComponent<RawImage>().texture = myTexture;
        }



    }
    public void LogSelectedToggle()
    {
        // May have several selected toggles

        // OR

        Toggle selectedToggle = ToggleGroup.ActiveToggles().FirstOrDefault();
        if (selectedToggle != null)
        {
            if (selectedToggle.isOn && selectedToggle.name == "espacio_1")
            {
                GameStatus.espacio_seleccionado = 0;

            }
            else if (selectedToggle.isOn && selectedToggle.name == "espacio_2")
            {

                GameStatus.espacio_seleccionado = 1;
            }
            else if (selectedToggle.isOn && selectedToggle.name == "espacio_3")
            {

                GameStatus.espacio_seleccionado = 2;
            }
            else if (selectedToggle.isOn && selectedToggle.name == "espacio_4")
            {

                GameStatus.espacio_seleccionado = 3;
            }
            else if (selectedToggle.isOn && selectedToggle.name == "espacio_5")
            {

                GameStatus.espacio_seleccionado = 4;

            }
            else if (selectedToggle.isOn && selectedToggle.name == "espacio_6")
            {

                GameStatus.espacio_seleccionado = 5;
            }

        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void eliminar_espacio()
    {

        switch (GameStatus.espacio_seleccionado) {

            case 0:
                if (eliminado_mensaje()) {
                    GameStatus.lista_espacios_imagen.Remove("imagen_1");
                    SceneManager.LoadScene("eliminar_espacio");
                }

                break;
            case 1:

                if (eliminado_mensaje())
                {
                    GameStatus.lista_espacios_imagen.Remove("imagen_2");
                    SceneManager.LoadScene("eliminar_espacio");
                }

                break;
            case 2:

                if (eliminado_mensaje())
                {
                    GameStatus.lista_espacios_imagen.Remove("imagen_3");
                    SceneManager.LoadScene("eliminar_espacio");
                }

                break;
            case 3:
                if (eliminado_mensaje())
                {
                    GameStatus.lista_espacios_imagen.Remove("imagen_4");
                    SceneManager.LoadScene("eliminar_espacio");
                }

                break;
            case 4:

                if (eliminado_mensaje())
                {
                    GameStatus.lista_espacios_imagen.Remove("imagen_5");
                    SceneManager.LoadScene("eliminar_espacio");
                }

                break;
            case 5:
                if (eliminado_mensaje())
                {
                    GameStatus.lista_espacios_imagen.Remove("imagen_6");
                    SceneManager.LoadScene("eliminar_espacio");
                }

                break;
            default:
                break;


        }


    }
    public bool eliminado_mensaje() {
        if (EditorUtility.DisplayDialog("Eliminacion de espacio.", "\n¿Desea eliminar el espacio?", "Si", "No"))
        {
            //aqui agregamos al diccionario el espacio con su imagen
            return true;
        }
        else
        {
            return false;
        }

    }
    public void regresar()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
