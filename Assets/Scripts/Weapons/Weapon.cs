using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base class for weapon behavior
//Any new weapons must extend this class
//There's not much here, but what's here HAS to be here for everything else to work
public abstract class Weapon : MonoBehaviour
{
    public enum Stance
    {
        STANCE1, STANCE2, STANCE3
    }
    private SpriteRenderer spriteRenderer;

    public abstract void Attack1();

    public abstract void Attack2();
}
