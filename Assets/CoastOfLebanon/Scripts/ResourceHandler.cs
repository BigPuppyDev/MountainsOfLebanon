using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceHandler : MonoBehaviour
{    
    [SerializeField] int wood = 0;
    [SerializeField] int stone = 0;
    string woodString = "Wood: ";
    string stoneString = "Stone: ";
    [SerializeField] Text woodText;
    [SerializeField] Text stoneText;

    void Start ()
    {
	}
	
	void Update ()
    {
        woodText.text = woodString + wood;
        stoneText.text = stoneString + stone;
	}

    public void AddWood(int amount)
    {
        wood += amount;
    }

    public void AddStone(int amount)
    {
        wood += amount;
    }

    public bool RemoveWood(int amount)
    {
        if(wood>=amount)
        {
            wood -= amount;
            return true;
        }
        return false;
    }

    public bool RemoveStone(int amount)
    {
        if (stone >= amount)
        {
            stone -= amount;
            return true;
        }
        return false;
    }
}
