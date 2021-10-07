using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Scri_ZigZag_Fog : MonoBehaviour
{

    private void Start()
    {
        gameObject.transform.position = new Vector3(0, 2, 0);
        StartCoroutine(GoDownFog());
    }

    IEnumerator GoDownFog()
    {
        yield return new WaitForSeconds(0.25f);
        gameObject.transform.DOLocalMove(new Vector3(0, 0, 0), 5, false);
        yield return new WaitForSeconds(5f);
        StartCoroutine(ZigZagFog());
    }

    IEnumerator ZigZagFog()
    {
        gameObject.transform.DOLocalMove(new Vector3(0.05f, 0, 0),1,false);
        yield return new WaitForSeconds(1f);
        gameObject.transform.DOLocalMove(new Vector3(-0.05f, -0.075f, 0), 1, false);
        yield return new WaitForSeconds(1f);
        StartCoroutine(ZigZagFog());
    }

}
