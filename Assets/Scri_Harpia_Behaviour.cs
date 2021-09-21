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
        if (Input.GetKeyDown(KeyCode.Q))
            GoToLeftCharge();
        if (Input.GetKeyDown(KeyCode.E))
            GoToRightCharge();

        if (Input.GetKeyDown(KeyCode.Alpha2))
            GoDive();
        if (Input.GetKeyDown(KeyCode.Alpha1))
            GoLeftDive();
        if (Input.GetKeyDown(KeyCode.Alpha3))
            GoRightDive();
    }

    void GoToLeft()
    {
        _obj_Harpia.GetComponent<Animator>().Play("Idle");
        _obj_Harpia.GetComponent<Animator>().speed = 1;
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 12), 0.35f, RotateMode.Fast);
        StartCoroutine(SmoothToCenter());
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(-0.65f, 0.85f, 0), 1.5f, false);
    }

    void GoToRight()
    {
        _obj_Harpia.GetComponent<Animator>().Play("Idle");
        _obj_Harpia.GetComponent<Animator>().speed = 1;
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, -12), 0.35f, RotateMode.Fast);
        StartCoroutine(SmoothToCenter());
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(0.65f, 0.85f, 0), 1.5f, false);
    }

    void GoToCenter()
    {
        _obj_Harpia.GetComponent<Animator>().Play("Idle");
        _obj_Harpia.GetComponent<Animator>().speed = 1;
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(0, 0, 0), 2f, false);
    }

    void GoToCharge()
    {
        _obj_Harpia.GetComponent<Animator>().Play("Idle");
        _obj_Harpia.GetComponent<Animator>().speed = 2.5f;
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(0, 0.85f, 0), 3f, false);
    }


    void GoToLeftCharge()
    {
        _obj_Harpia.GetComponent<Animator>().Play("Idle");
        _obj_Harpia.GetComponent<Animator>().speed = 2.5f;
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(-1.65f, 0.85f, 0), 3f, false);
    }

    void GoToRightCharge()
    {
        _obj_Harpia.GetComponent<Animator>().Play("Idle");
        _obj_Harpia.GetComponent<Animator>().speed = 2.5f;
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(1.65f, 0.7f, 0), 3f, false);
    }

    void GoDive()
    {
        _obj_Harpia.GetComponent<Animator>().Play("Atack_Center");
        _obj_Harpia.GetComponent<Animator>().speed = 1;
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(0, -0.75f, 0), 1, false);
        StartCoroutine(SmoothToUp());
    }

    void GoLeftDive()
    {
        _obj_Harpia.GetComponent<Animator>().Play("Atack_Left");
        _obj_Harpia.GetComponent<Animator>().speed = 1;
        StartCoroutine(SmoothUpRight());
    }

    void GoRightDive()
    {
        _obj_Harpia.GetComponent<Animator>().Play("Atack_Right");
        _obj_Harpia.GetComponent<Animator>().speed = 1;
        StartCoroutine(SmoothUpLeft());
    }



    IEnumerator SmoothToCenter()
    {
        yield return new WaitForSeconds(1f);
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.55f, RotateMode.Fast);
    }

    IEnumerator SmoothToUp()
    {
        yield return new WaitForSeconds(1f);
        _obj_Harpia.GetComponent<Animator>().Play("Idle");
        _obj_Harpia.GetComponent<Animator>().speed = 1;
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(0, 0, 0), 2f, false);
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.1f, RotateMode.Fast);
    }


    IEnumerator SmoothUpLeft()
    {
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(0.2f, -0.85f, 0), 1, false);
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, -45), 1f, RotateMode.Fast);
        yield return new WaitForSeconds(0.5f);
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(-0.4f, -0.85f, 0), 0.8f, false);
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, -60), 0.8f, RotateMode.Fast);
        yield return new WaitForSeconds(0.175f);
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(-1.65f, 0.85f, 0), 0.85f, false);
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, -90), 0.3f, RotateMode.Fast);
        yield return new WaitForSeconds(1f);
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.1f, RotateMode.Fast);
        GoToRight();
    }


    IEnumerator SmoothUpRight()
    {
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(-0.2f, -0.85f, 0), 1, false);
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 45), 1f, RotateMode.Fast);
        yield return new WaitForSeconds(0.5f);
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(0.4f, -0.85f, 0), 0.8f, false);
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 60), 0.8f, RotateMode.Fast);
        yield return new WaitForSeconds(0.175f);
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(1.65f, 0.85f, 0), 0.85f, false);
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 90), 0.3f, RotateMode.Fast);
        yield return new WaitForSeconds(1f);
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0,0), 0.1f, RotateMode.Fast);
        GoToLeft();
    }

}
