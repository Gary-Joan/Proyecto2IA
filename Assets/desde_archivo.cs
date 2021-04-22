using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using Vuforia;
using UnityEngine.UI;

public class desde_archivo : MonoBehaviour
{
    void Start()
    {

        Debug.Log(GameStatus.muebles_posicion   );
        VuforiaARController.Instance.RegisterVuforiaStartedCallback(CreateImageTargetFromSideloadedTexture);
    }
    void Update()
    {
       
    }

    void CreateImageTargetFromSideloadedTexture()
    {
        var objectTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();

        // get the runtime image source and set the texture to load
        var runtimeImageSource = objectTracker.RuntimeImageSource;
        runtimeImageSource.SetFile(VuforiaUnity.StorageType.STORAGE_APPRESOURCE, "Vuforia/"+GameStatus.piso+".png", 0.15f, "escenario1");

        // create a new dataset and use the source to create a new trackable
        var dataset = objectTracker.CreateDataSet();
        var trackableBehaviour = dataset.CreateTrackable(runtimeImageSource, "escenario1");

        // add the DefaultTrackableEventHandler to the newly created game object
        trackableBehaviour.gameObject.AddComponent<DefaultTrackableEventHandler>();

        // activate the dataset
        objectTracker.ActivateDataSet(dataset);

        // TODO: add virtual content as child object(s)
        GameObject noreste = Instantiate(Resources.Load(GameStatus.muebles_posicion["Noreste"], typeof(GameObject))) as GameObject;
        noreste.transform.position = new Vector3(2, 0, 2);
        noreste.transform.SetParent(trackableBehaviour.gameObject.transform);


        GameObject noroeste = Instantiate(Resources.Load(GameStatus.muebles_posicion["Noroeste"], typeof(GameObject))) as GameObject;
        noroeste.transform.position = new Vector3(-2, 0, 2);
        noroeste.transform.SetParent(trackableBehaviour.gameObject.transform);


        GameObject suroeste = Instantiate(Resources.Load(GameStatus.muebles_posicion["Suroeste"], typeof(GameObject))) as GameObject;
        suroeste.transform.position = new Vector3(-2, 0, -2);
        suroeste.transform.SetParent(trackableBehaviour.gameObject.transform);

        GameObject centro = Instantiate(Resources.Load(GameStatus.muebles_posicion["Centro"], typeof(GameObject))) as GameObject;
        centro.transform.position = new Vector3(0, 0, (float)-0.25);
        centro.transform.SetParent(trackableBehaviour.gameObject.transform);

        GameObject sureste = Instantiate(Resources.Load(GameStatus.muebles_posicion["Sureste"], typeof(GameObject))) as GameObject;
        sureste.transform.position = new Vector3(2, 0, -2);
        sureste.transform.SetParent(trackableBehaviour.gameObject.transform);

        // GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //cube.transform.SetParent(trackableBehaviour.gameObject.transform);
    }
}