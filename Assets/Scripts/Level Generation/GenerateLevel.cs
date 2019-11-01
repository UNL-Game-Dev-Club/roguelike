using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public string path = "";

    public Object[] rooms;
    // Start is called before the first frame update
    void Start()
    {
        rooms = Resources.LoadAll(path, typeof(GameObject));
        
        foreach (Object room in rooms)
        {
            Debug.Log(room.name);
        }
    }
}
