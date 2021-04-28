using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class script_lista_espacio_ver : MonoBehaviour
{
    public ToggleGroup ToggleGroup;
    Texture2D myTexture;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var entry in GameStatus.lista_espacios_imagen)
        {
            System.Console.WriteLine(entry.Key + ":" + entry.Value);
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

                enviar_espacio(0);


            }
            else if (selectedToggle.isOn && selectedToggle.name == "espacio_2")
            {
                enviar_espacio(1);
            }
            else if (selectedToggle.isOn && selectedToggle.name == "espacio_3")
            {

                enviar_espacio(2);
            }
            else if (selectedToggle.isOn && selectedToggle.name == "espacio_4")
            {

                enviar_espacio(3);
            }
            else if (selectedToggle.isOn && selectedToggle.name == "espacio_5")
            {

                enviar_espacio(4);

            }
            else if (selectedToggle.isOn && selectedToggle.name == "espacio_6")
            {

                enviar_espacio(5);
            }

        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    void enviar_espacio(int i) {

        GameStatus.piso = GameStatus.lista_imagen_sillas[i].imagen;
        Debug.Log(GameStatus.piso);
        GameStatus.muebles_posicion = GameStatus.lista_piso_muebles[GameStatus.piso];

        foreach (var entry in GameStatus.muebles_posicion)
        {
            Debug.Log(entry.Key + "= " + entry.Value);


        }

    }
    public void ver_espacio()
    {
        SceneManager.LoadScene("espacio");
    }

    public void regresar()
    {
        SceneManager.LoadScene("MainMenu");
    }
}