using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Scri_Harpia_Behaviour : MonoBehaviour
{

    public GameObject _obj_Harpia;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            GoToLeft();
        if (Input.GetKeyDown(KeyCode.D))
            GoToRight();
        if (Input.GetKeyDown(KeyCode.S))
            GoToCenter();
        if (Input.GetKeyDown(KeyCode.W))
            GoToCharge();
        if (Input.GetKeyDown(KeyCode.E))
            GoDive();
    }

    void GoToLeft()
    {
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 12), 0.35f, RotateMode.Fast);
        StartCoroutine(SmoothToCenter());
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(-0.65f, 0.85f, 0), 1.5f, false);
    }

    void GoToRight()
    {
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, -12), 0.35f, RotateMode.Fast);
        StartCoroutine(SmoothToCenter());
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(0.65f, 0.85f, 0), 1.5f, false);
    }

    void GoToCenter()
    {
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(0, 0, 0), 0.75f, false);
    }

    void GoToCharge()
    {
        _obj_Harpia.GetComponent<Animator>().speed = 2.5f;
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(0, 0.85f, 0), 3f, false);
    }

    void GoDive()
    {
        _obj_Harpia.GetComponent<Animator>().speed = 1;
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(0, -0.5f, 0), 1, false);
    }

    IEnumerator SmoothToCenter()
    {
        yield return new WaitForSeconds(0.5f);
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.55f, RotateMode.Fast);
    }

}
