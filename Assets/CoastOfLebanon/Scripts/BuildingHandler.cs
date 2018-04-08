using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHandler : MonoBehaviour {
  
    PlaceableBuilding placeableBuilding;
    Vector3 hoveringPosition;

	void Start ()
    {
        hoveringPosition = Vector3.zero;
	}
	
	void Update ()
    {
	    
	}

    void FixedUpdate()
    {
        HoverBuilding();
    }
        
    GameObject buildingTemplate;

    public void HoverBuilding()
    {
        if (!placeableBuilding)
            return;

        int layerMask = 1 << LayerMask.NameToLayer("Ground");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        MoveWithMouse(ray, layerMask);
        //CheckTransparency(ray, layerMask);
    }

    private void MoveWithMouse(Ray ray, int layerMask)
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) //raycast against the ground
        {
            hoveringPosition = hit.point;
            hoveringPosition.y += placeableBuilding.transform.lossyScale.y / 2;
            placeableBuilding.MoveToLocation(hoveringPosition);
        }
    }

    private void CheckTransparency(Ray ray, RaycastHit hit, int layerMask)
    {
        if (Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.collider)
        {
            Debug.Log("HITTING COLLIDER " + hit.collider.name + " == " + placeableBuilding.gameObject.name);
            if (!hit.collider.gameObject.Equals(placeableBuilding.gameObject))
            {
                Debug.Log("PULLING TO BACK");
                placeableBuilding.PullToBack();
            }
            else
            {
                Debug.Log("PLLING TO FRONT");
                placeableBuilding.PullToFront();
            }
        }
    }

    public void CreatePlaceableBuilding(string buildingType)
    {
        buildingTemplate = GameObject.Find(buildingType);
        if (buildingTemplate)
            placeableBuilding = Instantiate(buildingTemplate).GetComponent<PlaceableBuilding>();
    }

    public bool PlaceBuilding()
    {
        if(CanPlaceBuilding())
        {
            CreateBuiltBuilding();            
            StopPlaceBuilding();
            return true;
        }

        return false;
    }

    private void CreateBuiltBuilding()
    {
        GameObject newBuilding = Instantiate(placeableBuilding.gameObject);
        Destroy(newBuilding.GetComponent<PlaceableBuilding>());
        Color newColor = newBuilding.GetComponent<Renderer>().material.color;
        newColor.a = 1f;
        newBuilding.GetComponent<Renderer>().material.color = newColor;
    }

    private bool CanPlaceBuilding()
    {
        return placeableBuilding && placeableBuilding.IsInBuildableLocation();
    }
    
    public void StopPlaceBuilding()
    {
        Destroy(placeableBuilding.gameObject);
        placeableBuilding = null;
    }
}
