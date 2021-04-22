using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class script_lista_editar : MonoBehaviour
{
    public UnityEngine.UI.ToggleGroup ToggleGroup;
    // Start is called before the first frame update
    void Start()
    {
        if (ToggleGroup == null) ToggleGroup = GetComponent<ToggleGroup>();
    }
    public void LogSelectedToggle()
    {
        // May have several selected toggles
        foreach (Toggle toggle in ToggleGroup.ActiveToggles())
        {
            Debug.Log(toggle, toggle);
        }

        // OR

        Toggle selectedToggle = ToggleGroup.ActiveToggles().FirstOrDefault();
        if (selectedToggle != null)
            Debug.Log(selectedToggle, selectedToggle);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
