using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentCamera : MonoBehaviour {

    [SerializeField] Shader transparentShader;
    [SerializeField] Camera transparentCamera;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        transparentCamera.RenderWithShader(transparentShader, null);
      //  transparentCamera.SetReplacementShader(transparentShader, "Hologram");

    }
}
