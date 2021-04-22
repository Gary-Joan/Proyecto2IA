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
    //cuadro de alertas
       void Start()
    {  


   
    }
    public void piso_valuechange(Dropdown sender) {

        switch (sender.value)
        {
            case 1:
                Debug.Log("Case 0");
                GameStatus.piso = "mario";
                break;
            case 2:
                Debug.Log("Case 1");
                GameStatus.piso = "luigi";
                break;
            case 3:
                Debug.Log("Case 2");
                GameStatus.piso = "yoshi";
                break;
            case 4:
                Debug.Log("Case 3");
                GameStatus.piso = "peach";
                break;
            case 5:
                Debug.Log("Case 4");
                GameStatus.piso = "toad";
                break;
            case 6:
                Debug.Log("Case 5");
                GameStatus.piso = "bowser";
                break;
            default:
                Debug.Log("error");
                break;
        }
    }
    public void mueble_posicion_change(Dropdown sender) {
        if (sender.name == "drop2") {
            muebles.Add(sender.options[sender.value].text, "silla");
        
        }
        else if (sender.name == "drop3")
        {
            muebles.Add(sender.options[sender.value].text, "mesa");

        }
        else if (sender.name == "drop4")
        {
            muebles.Add(sender.options[sender.value].text, "gabinete");

        }
        else if (sender.name == "drop5")
        {
            muebles.Add(sender.options[sender.value].text, "comoda");

        }else
         if (sender.name == "drop6")
        {
            muebles.Add(sender.options[sender.value].text, "banco");

        }




    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void regresar() {
        SceneManager.LoadScene("MainMenu");
    }
    public void mandardatos() {
        GameStatus.muebles_posicion = muebles;
        if (EditorUtility.DisplayDialog("EXITO!!", "Escenario Creado!!\n¿Desea ver el escenario o regresar menu principal", "Ver escenario", "Menu principal"))

            SceneManager.LoadScene("espacio");
        else
            SceneManager.LoadScene("MainMenu");

    }
}
