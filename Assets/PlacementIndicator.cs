using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{
   private ARRaycastManager rayManager;
   private GameObject visual;

   void Start()
   {
       // Retrieves the components
       rayManager = FindObjectOfType<ARRaycastManager>();
       visual = transform.GetChild(0).gameObject;

       //Hiding the Visual Placement
       visual.SetActive(false);
   }

   void Update()
   {
       // Shoots a raycast from the screen's center

       List<ARRaycastHit> hits = new List <ARRaycastHit>();
       rayManager.Raycast(new Vector2(Screen.width/2, Screen.height/2), hits, TrackableType.Planes);

       //if we hit an AR Plane, update the position and rotation
       if(hits.Count > 0)
       {
           transform.position = hits[0].pose.position;
           transform.rotation = hits[0].pose.rotation;

           if(!visual.activeInHierarchy)
           {
              visual.SetActive(true); 
           }

       }

   }

}
