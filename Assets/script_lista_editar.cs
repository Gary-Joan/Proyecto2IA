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
           
       
        if (ToggleGroup == null) ToggleGroup = GetComponent<ToggleGroup>();
    }
    public void LogSelectedToggle()
    {
        // May have several selected toggles

        // OR

        Toggle selectedToggle = ToggleGroup.ActiveToggles().FirstOrDefault();
        if (selectedToggle != null)
            Debug.Log(selectedToggle, selectedToggle);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void regresar()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
