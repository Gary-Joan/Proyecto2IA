using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class script_lista_editar : MonoBehaviour
{
    public UnityEngine.UI.ToggleGroup ToggleGroup;
    Texture2D myTexture;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var entry in GameStatus.lista_espacios_imagen) {
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
                GameStatus.espacio_seleccionado = 0;

            }
            else if (selectedToggle.isOn && selectedToggle.name == "espacio_2") {

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

    public void ir() {
        SceneManager.LoadScene("editar_espacio");
    }

    public void regresar()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
