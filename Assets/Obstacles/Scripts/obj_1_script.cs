using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class obj_1_script : MonoBehaviour {


    // Use this for initialization
    private int id;
    public static int ID_OBS_1 = 1;

    public enum ObstacleId
    {
        obstcale1 = 1,
        obstcale2 = 2,
        obstcale3 = 3
    }

    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public void init(int _id)
    {
        Id = _id;
    }



    // Update is called once per frame
    Vector3 mouseDown = new Vector3();
    Vector3 mouseUP = new Vector3();
    private void OnMouseDown()
    {
        mouseDown = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (id==3)
        {
            this.transform.position = new Vector3(10,transform.position.y,transform.position.z);
        }
    }

    private void OnMouseUp()
    {
        mouseUP = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        move(newPos);
    }

    private void move(Vector3 newPos)
    {
        switch (Id)
        {
            case 1:
                moveType1(newPos);
                break;
            case 2:
                moveType2(newPos);
                break;
            default:
                break;
        }
    }

    private void moveType1(Vector3 newPos)
    {

        if (mouseDown.x - newPos.x < 0)
        {
            transform.position = new Vector3(newPos.x, transform.position.y, transform.position.z);
        }
    }

    private void moveType2(Vector3 newPos)
    {

        if (mouseDown.x - newPos.x > 0)
        {
            transform.position = new Vector3(newPos.x, transform.position.y, transform.position.z);
        }
    }



    public void pubMethod () {
        //Debug.Log("sada");
        gameObject.transform.Translate(Vector3.up * Time.deltaTime);
	}
    
}
