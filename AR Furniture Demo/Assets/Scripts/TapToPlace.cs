using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;


public class TapToPlace : MonoBehaviour
{

    [SerializeField] private ARRaycastManager arRaycastManager;
    [SerializeField] private GraphicRaycaster m_Raycaster;
    [SerializeField] private ARReferencePointManager arReferencePointManager;
    PointerEventData m_PointerEventData;
    [SerializeField] private EventSystem m_EventSystem;
    [SerializeField] private GameObject placementIndicator;
    [SerializeField] private GameObject objectToPreview;
    [SerializeField] private GameObject objectToPlace;
    private bool placementIsPoseValid;
    private Pose placementPose;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public GameObject placedObject;


    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    void Start()
    {
        placementIndicator.SetActive(false);
    }

    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();

        //if (Input.GetKeyDown(KeyCode.Mouse0) && CheckForUIElements())
        //{
        //    Debug.Log("Cliked to place");
        //    PlaceItem();
        //}

        if (placementIsPoseValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && CheckForUIElements())
        {
            PlaceItem();
        }

    }


    public bool CheckForUIElements()
    {

        m_PointerEventData = new PointerEventData(m_EventSystem);
        //m_PointerEventData.position = Input.mousePosition;
        m_PointerEventData.position = Input.GetTouch(0).position;
        List<RaycastResult> results = new List<RaycastResult>();
        m_Raycaster.Raycast(m_PointerEventData, results);

        if (results.Count > 0)
        {
            return false;
        }
        else
        {
            return true;
        }

    }


    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));

        if (arRaycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon))
        {
            placementIsPoseValid = true;
            placementPose = hits[0].pose;
        }
        else
        {
            placementIsPoseValid = false;
        }
    }

    private void UpdatePlacementIndicator()
    {
        if (placementIsPoseValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    public void ChangeItem()
    {
        if(objectToPreview != null)
        {
            Destroy(objectToPreview);
        }
        objectToPreview = Instantiate(FurnitureInventory.SharedInstance.objectToPlace, placementPose.position, placementPose.rotation, placementIndicator.gameObject.transform);
    }

    private void PlaceItem()
    {

        if (objectToPreview != null)
        {
            ARReferencePoint ahchorPoint = arReferencePointManager.AddReferencePoint(placementPose);
            if (ahchorPoint == null)
            {
                string errorEntry = "There was an error creating a reference point\n";
                Debug.Log(errorEntry);
            }
            else
            {
                objectToPlace = objectToPreview;
                objectToPreview = null;

                objectToPlace.transform.SetParent(ahchorPoint.gameObject.transform);
                objectToPlace.transform.localPosition = new Vector3(0, 0, 0);
            }
 
        }

    }

}
