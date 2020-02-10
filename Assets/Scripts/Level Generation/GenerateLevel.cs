using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public string path = "";
    public int numRooms;

    public Object[] rooms;

    public GameObject grid;

    void Start()
    {
        grid = GameObject.Find("Grid");

        rooms = Resources.LoadAll(path, typeof(GameObject));
        List<Room> level = new List<Room>();

        Room room1 = ((GameObject)Instantiate(rooms[1])).GetComponent<Room>();
        level.Add(room1);

        bool generating = true;

        while (generating)
        {
            List<Room> newRooms = new List<Room>();
            foreach (Room room in level)
            {
                foreach (Opening opening in System.Enum.GetValues(typeof(Opening)))
                {
                    if (room.HasOpening(opening))
                    {
                        Room newRoom = PlaceRoom(rooms, room, opening);
                        newRooms.Add(newRoom);
                        room.SetOpening(opening, false);
                        newRoom.SetOpening(OppositeOpening(opening), false);
                    }
                }
            }
            foreach (Room room in newRooms)
            {
                level.Add(room);
            }
            if (level.Count >= 20)
            {
                generating = false;
            }
        }
    }

    private Room PlaceRoom(Object[] rooms, Room parentRoom, Opening opening)
    {
        List<Room> candidates = new List<Room>();
        foreach (Object room in rooms)
        {
            Room candidate = ((GameObject)room).GetComponent<Room>();
            //TODO: More advanced selection logic
            if (candidate.HasOpening(OppositeOpening(opening)))
            {
                candidates.Add(candidate);
            }
        }

        Room finalRoom = candidates[(int)Random.Range(0f, candidates.Count)];
        finalRoom = Instantiate(finalRoom);

        Vector3 roomOffset = finalRoom.transform.position - finalRoom.GetPos(OppositeOpening(opening));
        finalRoom.transform.position = parentRoom.GetPos(opening) + roomOffset;

        return finalRoom;
    }

    private Opening OppositeOpening(Opening opening)
    {
        switch (opening)
        {
            case Opening.TOP:
                return Opening.BOTTOM;
            case Opening.BOTTOM:
                return Opening.TOP;
            case Opening.LEFT:
                return Opening.RIGHT;
            case Opening.RIGHT:
                return Opening.LEFT;
            default:
                return Opening.BOTTOM;
        }
    }
}
