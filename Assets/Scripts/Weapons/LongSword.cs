using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongSword : Weapon
{
    public Stance currentStance = Stance.STANCE1;
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = Color.red;
    }

    public override void Attack1()
    {
        switch (currentStance)
        {
            case Stance.STANCE1:
                StartCoroutine(Stance1Attack1());
                break;
            case Stance.STANCE2:
                StartCoroutine(Stance2Attack1());
                break;
            case Stance.STANCE3:
                StartCoroutine(Stance3Attack1());
                break;
            default:
                Debug.Log("Invalid Stance");
                break;
        }
    }

    public override void Attack2()
    {
        switch (currentStance)
        {
            case Stance.STANCE1:
                StartCoroutine(Stance1Attack2());
                break;
            case Stance.STANCE2:
                StartCoroutine(Stance2Attack2());
                break;
            case Stance.STANCE3:
                StartCoroutine(Stance3Attack2());
                break;
            default:
                Debug.Log("Invalid Stance");
                break;
        }
    }

    //Stance 1 = Red, Stance 2 = Green, Stance 3 = Blue
    //Attack 1 moves forward, attack 2 moves backwards
    IEnumerator Stance1Attack1()
    {
        currentStance = Stance.STANCE2;
        SetColor();
        yield return null;
    }

    IEnumerator Stance1Attack2()
    {
        currentStance = Stance.STANCE3;
        SetColor();
        yield return null;
    }

    IEnumerator Stance2Attack1()
    {
        currentStance = Stance.STANCE3;
        SetColor();
        yield return null;
    }

    IEnumerator Stance2Attack2()
    {
        currentStance = Stance.STANCE1;
        SetColor();
        yield return null;
    }

    IEnumerator Stance3Attack1()
    {
        currentStance = Stance.STANCE1;
        SetColor();
        yield return null;
    }

    IEnumerator Stance3Attack2()
    {
        currentStance = Stance.STANCE2;
        SetColor();
        yield return null;
    }

    private void SetColor()
    {
        switch (currentStance)
        {
            case Stance.STANCE1:
                sr.color = Color.red;
                break;
            case Stance.STANCE2:
                sr.color = Color.green;
                break;
            case Stance.STANCE3:
                sr.color = Color.blue;
                break;
            default:
                Debug.Log("Invalid Stance");
                break;
        }
    }
}
