using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Scri_Parachute_Behaviour : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(ZigZagParachute());
    }

    IEnumerator ZigZagParachute()
    {
        gameObject.transform.DORotate(new Vector3(0, 0, 12), 0.75f, RotateMode.Fast);
        yield return new WaitForSeconds(0.75f);
        gameObject.transform.DORotate(new Vector3(0, 0, -12), 1.5f, RotateMode.Fast);
        yield return new WaitForSeconds(1.25f);
        gameObject.transform.DORotate(new Vector3(0, 0, 0), 0.75f, RotateMode.Fast);
        yield return new WaitForSeconds(0.6f);

        StartCoroutine(ZigZagParachute());
    }

}
