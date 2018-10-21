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
        obstcale3 = 3,
        obstacle4 = 4,
        obstacle5 = 5
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
        moveZ = mouseRadZ;
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
            case 4:
                moveType4(newPos);
                break;
            default:
                break;
        }
    }

    private void moveType1(Vector3 newPos)
    {
        if (mouseDown.x - newPos.x < 0)
        {
            if(transform.position.x > 0)
            {
                transform.position = new Vector3(mouseUP.x + newPos.x, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(newPos.x, transform.position.y, transform.position.z);
            }
        }
    }

    private void moveType2(Vector3 newPos)
    {

        if (mouseDown.x - newPos.x > 0)
        {
            if(transform.position.x < 0)
            {
                transform.position = new Vector3(newPos.x + mouseUP.x, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(newPos.x, transform.position.y, transform.position.z);
            }
            
        }
    }

    float moveZ = 0;
    float mouseRadZ;
    private void moveType4(Vector3 newPos)
    {
        if (transform.rotation.z < 0 || transform.rotation.z > Quaternion.Euler(0, 0, 90).z)
        {
            return;
        }
        else
        {
            if (moveZ > 0)
            {
                mouseRadZ = (mouseDown.y - newPos.y) + moveZ;
                Debug.Log("up       " + mouseRadZ);
                transform.rotation = Quaternion.Euler(0, 0, mouseRadZ * 10);
            }
            else
            {
                mouseRadZ = mouseDown.y - newPos.y;
                Debug.Log("down     "+mouseRadZ);
                transform.rotation = Quaternion.Euler(0, 0, mouseRadZ * 10);
            }
            
        }
        
    }

    private void moveType5(Vector3 newPos)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("game Over");
        }
    }

    public void pubMethod () {
        //Debug.Log("sada");
        gameObject.transform.Translate(Vector3.up * Time.deltaTime * 0.5f,Camera.main.transform);
        //transform.position = Vector3.MoveTowards(transform.position,new Vector3(0,5,0),Time.deltaTime);
    }
    
}
