using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oclusion : MonoBehaviour
{
   [SerializeField] GameObject player;
   [SerializeField] GameObject[] objetosScene;
   [SerializeField] List<GameObject> staticObjects;

    public float minDist;
    [SerializeField] int objetosOcultos;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        objetosScene = GameObject.FindObjectsOfType<GameObject>();
        staticObjects = new List<GameObject>();
        StaticFilter();
    }

    private void Update()
    {
        ObjectDistToPlayer();
    }

    void StaticFilter()
    {
        

        foreach (GameObject obj in objetosScene)
        {
            if (obj.isStatic)
            {
                if(obj.name != "Terrain") staticObjects.Add(obj);
            }
        }
        objetosOcultos = staticObjects.Count;
        objetosScene = null;
    }

    void ObjectDistToPlayer()
    {
        int ocultos = 0;
        foreach (GameObject staticobj in staticObjects)
        {
            if(Vector3.Distance(staticobj.transform.position, player.transform.position) <= minDist)
            {
                staticobj.SetActive(true);              
            }
            else
            {
                staticobj.SetActive(false);
                ocultos++;
            }
        }
        objetosOcultos = ocultos;
    }
}
