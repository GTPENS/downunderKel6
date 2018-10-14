using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class GameManager : MonoBehaviour {


    public GameObject obstacle1,obstacle2;
	// Use this for initialization
	void Start () {

        
        InvokeRepeating("initObstacle", 0, 2);
        
    }

    private void initObstacle()
    {
        int id = UnityEngine.Random.Range(1,2);
        if (id==1)
        {
            attachObstacle2(new Vector3(0, -5, 0));
        }
        else if (id==2)
        {
            attachObstacle1(new Vector3(0, -5, 0));
        }
        //switch (id)
        //{
        //    case 1:
        //        attachObstacle1(new Vector3(0, -5, 0));
        //        break;
        //    case 2:
        //        attachObstacle2(new Vector3(0, -5, 0));
        //        break;
        //    default:
        //        break;
        //}
        //attachObstacle2(new Vector3(0, -5, 0));
        //if (getNumberOfObstacle() == 4)
        //{
        //    CancelInvoke("initObstacle");
        //}
    }

    // Update is called once per frame
    void Update () {
        updateObstacles();
        
	}

    private void updateObstacles()
    {
        for (int i = 0; i < getNumberOfObstacle(); i++)
        {
            getObstacle(i).gameObject.GetComponent<obj_1_script>().pubMethod();


            if (getObstacle(i).transform.position.y >= 3)
            {
                removeObstacle(i);
            }
        }
    }

    //list untuk menampung game object obstacle
    private List<GameObject> listOfObstacle = new List<GameObject>();

    //method untuk menambahkan game object obstacle baru
    private void attachObstacle1(Vector3 _position)
    {
        GameObject go = Instantiate(obstacle1);
        go.transform.position = _position;
        listOfObstacle.Add(go);
        getObstacle(getNumberOfObstacle() - 1).init((int)obj_1_script.ObstacleId.obstcale1);
    }

    private void attachObstacle2(Vector3 _position)
    {
        GameObject go = Instantiate(obstacle2);
        go.transform.position = _position;
        listOfObstacle.Add(go);
        getObstacle(getNumberOfObstacle() - 1).init((int)obj_1_script.ObstacleId.obstcale2);
    }

    private obj_1_script getObstacle(int _index)
    {
        return listOfObstacle[_index].gameObject.GetComponent<obj_1_script>();
    }

    private int getNumberOfObstacle()
    {
        return listOfObstacle.Count;
    }

    private void removeObstacle(int _index)
    {
        Destroy(listOfObstacle[_index].gameObject);
        Destroy(listOfObstacle[_index]);
        listOfObstacle.RemoveAt(_index);
    }
}
