using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class GameManager : MonoBehaviour {


    public GameObject obstacle1,obstacle2;
	// Use this for initialization
	void Start () {
        Instantiate(obstacle1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
