using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject prefab;
    public GameObject prefab2;
    public GameObject toPreview;
    public GameObject toPreview2;
    public GameObject toPlace;
    void Start()
    {
        toPreview = Instantiate(prefab, new Vector3(1,1,1), Quaternion.identity);
        toPlace = toPreview;
        toPlace.transform.position = new Vector3(1, 3, 1);
        toPlace = null;

        //toPreview = Instantiate(prefab2, new Vector3(1, 1, 1), Quaternion.identity);
        //toPlace = toPreview;
        //toPlace.transform.position = new Vector3(1, 4, 1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
