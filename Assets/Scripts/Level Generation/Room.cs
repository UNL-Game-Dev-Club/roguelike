using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public bool hasTop = false;
    public bool hasBottom = false;
    public bool hasLeft = false;
    public bool hasRight = false;

    public bool HasOpening(Opening opening)
    {
        switch (opening)
        {
            case Opening.TOP:
                return hasTop;
            case Opening.BOTTOM:
                return hasBottom;
            case Opening.LEFT:
                return hasLeft;
            case Opening.RIGHT:
                return hasRight;
            default:
                return false;
        }
    }
    public Vector3 GetPos(Opening opening)
    {
        switch (opening)
        {
            case Opening.TOP:
                return topPos;
            case Opening.BOTTOM:
                return bottomPos;
            case Opening.LEFT:
                return leftPos;
            case Opening.RIGHT:
                return rightPos;
            default:
                return Vector3.zero;
        }
    }

    public void SetOpening(Opening opening, bool value)
    {
        Debug.Log(opening);
        switch (opening)
        {
            case Opening.TOP:
                hasTop = value;
                break;
            case Opening.BOTTOM:
                hasBottom = value;
                break;
            case Opening.LEFT:
                hasLeft = value;
                break;
            case Opening.RIGHT:
                hasRight = value;
                break;
            default:
                break;
        }
    }

    public Vector3 rightPos
    {
        get { return transform.Find("Right").gameObject.transform.position; }
    }
    public Vector3 leftPos
    {
        get { return transform.Find("Left").gameObject.transform.position; }
    }
    public Vector3 topPos
    {
        get { return transform.Find("Top").gameObject.transform.position; }
    }
    public Vector3 bottomPos
    {
        get { return transform.Find("Bottom").gameObject.transform.position; }
    }

    public int depth = 0;
}

public enum Opening
{
    TOP, LEFT, RIGHT, BOTTOM
}