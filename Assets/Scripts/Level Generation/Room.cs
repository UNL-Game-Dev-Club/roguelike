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
                if (hasTop)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case Opening.BOTTOM:
                if (hasBottom)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case Opening.LEFT:
                if (hasLeft)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case Opening.RIGHT:
                if (hasRight)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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