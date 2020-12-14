using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARFoundation;

public class ARPlacer : MonoBehaviour
{
   ARRaycastManager m_ARRaycastManager;
   
   List<ARRaycastHit> raycast_hits = new List<ARRaycastHit>();


   public GameObject LocationBasedARPrefab;

   private void Awake()
   {
     m_ARRaycastManager = GetComponent<ARRaycastManager>();
   }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) 
	{
	   Touch touch = Input.GetTouch(0);
	   if (m_ARRaycastManager.Raycast(touch.position, raycast_hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
     {
      Pose pose = raycast_hits[0].pose;     
      LocationBasedARPrefab.transform.position = pose.position;

	   }
   }
 }
}