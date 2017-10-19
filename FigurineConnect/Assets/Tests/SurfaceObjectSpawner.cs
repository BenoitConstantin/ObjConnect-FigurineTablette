using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceObjectSpawner : MonoBehaviour {

    [System.Serializable]
	public class ID_GameObject
    {
        public string surfaceObjectID;
        public GameObject gameObject;
    }

    public List<ID_GameObject> idToGameObjects = new List<ID_GameObject>();

    public Dictionary<SurfaceObject, GameObject> surfaceObjectToGameObjects = new Dictionary<SurfaceObject, GameObject>();


    void Start()
    {
        foreach(ID_GameObject idToObj in idToGameObjects)
        {
           SurfaceObject so = SurfaceObjectDetector.Instance.GetSurfaceObject(idToObj.surfaceObjectID);
           surfaceObjectToGameObjects.Add(so, idToObj.gameObject);
        }
    }

    void Update()
    {
        foreach(SurfaceObject so in surfaceObjectToGameObjects.Keys)
        {
            if (so.isDetected)
                surfaceObjectToGameObjects[so].SetActive(true);
        }
    }

    void OnDisable()
    {
        foreach (GameObject obj in surfaceObjectToGameObjects.Values)
        {
            if(obj)
                obj.SetActive(false);
        }
    }

}
