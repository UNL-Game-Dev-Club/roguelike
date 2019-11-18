using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public string path = "";

    public Object[] rooms;

    public GameObject grid;

    void Start()
    {
        grid = GameObject.Find("Grid");

        rooms = Resources.LoadAll(path, typeof(GameObject));
        List<GameObject> level = new List<GameObject>();
        
        foreach (Object room in rooms)
        {
            Debug.Log(room.name);
        }

        GameObject room1 = Instantiate(rooms[0]) as GameObject;
        level.Add(room1);
        room1.transform.parent = grid.transform;

        for (int i = 0; i < 3; i++)
        {
            Vector2 pos = level[i].transform.Find("Right").transform.position;
            GameObject room = Instantiate(rooms[0]) as GameObject;
            room.transform.parent = grid.transform;
            Vector3 offset = room.transform.position - room.transform.Find("Left").transform.position;
            room.transform.position += offset;
            level.Add(room);
        }
    }
}
