using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Vector3 offset;
    public bool mouseInput;
    public float maxOffsetX;
    public float maxOffsetY;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (mouseInput)
        {
            float camOffsetX = Mathf.Lerp(-maxOffsetX, maxOffsetX, Input.mousePosition.x / Screen.width);
            float camOffsetY = Mathf.Lerp(-maxOffsetY, maxOffsetY, Input.mousePosition.y / Screen.height);
            offset.x = camOffsetX;
            offset.y = camOffsetY;
        }
        transform.position = player.transform.position + offset;
    }
}
