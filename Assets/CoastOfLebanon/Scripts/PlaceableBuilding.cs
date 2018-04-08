using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableBuilding : MonoBehaviour
{
    Renderer rend;
    Rigidbody rigid;

    [SerializeField] int woodNeeded;
    [SerializeField] int stoneNeeded;
    [SerializeField] float buildingTransparency = 0.5f;
    float originalTransparency;
    Color originalColor;
    Color currentColor;
    bool inFront = true;
    bool inBuildableLocation = true;
    bool isBuilt = false;
    
    void Start ()
    {
        rend = GetComponent<Renderer>();
        rigid = GetComponent<Rigidbody>();
        
        originalColor = rend.material.color;
        originalColor.a = buildingTransparency * 1.5f;
        rend.material.color = originalColor;
    }
	
	void Update ()
    {
        UpdateColor();
    }
    
    public void MoveToLocation(Vector3 location)
    {
        transform.position = location;     
    }

    private void UpdateColor()
    {
        currentColor = originalColor;

        if (inBuildableLocation)
            currentColor = originalColor; 
        else
            currentColor = Color.red;

        if (inFront)
            currentColor.a = originalColor.a; 
        else
            currentColor.a = buildingTransparency;
        
        rend.material.color = currentColor;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ground")
            return;

        inBuildableLocation = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
            return;

        inBuildableLocation = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Ground")
            return;

        inBuildableLocation = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Ground")
            return;

        inBuildableLocation = true;
    }
    
    public void PullToBack()
    {
        inFront = false;
    }

    public void PullToFront()
    {
        inFront = true;
    }

    public int GetWoodNeeded()
    {
        return woodNeeded;
    }

    public int GetStoneNeeded()
    {
        return stoneNeeded;
    }
    
    public bool IsInBuildableLocation()
    {
        return inBuildableLocation;
    }
}
