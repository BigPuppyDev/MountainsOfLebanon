using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour
{
    GameObject destination;
    BuildingHandler buildingHandler;
    enum InputStates { Default, Building, BuildingsSelected, UnitsSelected }
    InputStates currentState;

	void Start ()
    {
        destination = new GameObject();
        destination.name = "AI Target";
        buildingHandler = GetComponent<BuildingHandler>();
        currentState = InputStates.UnitsSelected;
	}
	
	void Update ()
    {
        if (IsOverUI())
        {
            HandleUIInput();
        }
        else
        {
            HandleMouseInput();
        }
	}

    private void HandleMouseInput()
    {
        switch (currentState) {
            case InputStates.Building:
                HandleBuildingState();
                break;
            case InputStates.UnitsSelected:
                HandleUnitsSelectedState();
                break;
            case InputStates.Default:
                HandleDefaultState();
                break;
        }
    }
    
    private void HandleUnitsSelectedState()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            AIDestinationSetter[] ais = GameObject.FindObjectsOfType<AIDestinationSetter>();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100000))
            {
                destination.transform.position = hit.point;
                for (int i = 0; i < ais.Length; i++)
                {
                    ais[i].target = destination.transform;
                }
            }
        }
    }

    private void HandleBuildingState()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Mouse1))
        {
            buildingHandler.StopPlaceBuilding();
            currentState = InputStates.Default;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && buildingHandler.PlaceBuilding())
        {
            currentState = InputStates.Default;
        }
    }

    private void HandleDefaultState()
    {
        HandleUIInput();
    }

    private void HandleUIInput()
    {
        currentState = (currentState != InputStates.Building && Input.GetKeyUp(KeyCode.Mouse0)) ? InputStates.Building : currentState;
    }

    private bool IsOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();        
    }
   
}
