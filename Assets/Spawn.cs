using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.XR.ARFoundation;

public class Spawn : MonoBehaviour
{
    [SerializeField] ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    [SerializeField] GameObject prefab;
    [SerializeField] ARPlaneManager planeManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0) return;

        if (raycastManager.Raycast(Input.GetTouch(0).position, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            Pose pose = hits[0].pose;

            GameObject obj = Instantiate(prefab, pose.position, Quaternion.identity);

            foreach(ARPlane plane in planeManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }

            planeManager.enabled = false;
        }
    }
}
