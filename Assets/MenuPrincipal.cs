using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPrincipal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    { }
    // Update is called once per frame
    void Update()
    {   }
    public void cargar_escena(string escena) {
        GameStatus.insertar_bitacora("[ERROR]Se Regreso a Menu Principal -- " + DateTime.Now.ToString("hh:mm:ss"));
        SceneManager.LoadScene(escena);
    }

}
