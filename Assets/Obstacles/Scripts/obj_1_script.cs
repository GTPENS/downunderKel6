using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class obj_1_script : MonoBehaviour {


    // Use this for initialization
   
    
    void Start () {
        
        
        
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.up*Time.deltaTime);
	}
}
