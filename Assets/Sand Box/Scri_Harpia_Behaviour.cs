using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using System.Linq;

public class Scri_Harpia_Behaviour : MonoBehaviour
{
    public GameObject _obj_Harpia;
    public AudioSource _musicController;
    public List<AudioClip> _musicas = new List<AudioClip>();

    private int behaviour;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(DelayIntro());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int[] naoPodeEsses = new int[] { 1, 3, 5, 7, 9, 11 };
            Debug.LogError(RandomRangeExcept(1, 11, naoPodeEsses));
        }
    }

    void GoToLeft()
    {
        StopAllCoroutines();
        StartCoroutine(GoToLeftEnum());
    }

    IEnumerator GoToLeftEnum()
    {
        _obj_Harpia.GetComponent<Animator>().Play("Idle");
        _obj_Harpia.GetComponent<Animator>().speed = 1;
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 12), 0.35f, RotateMode.Fast);
        StartCoroutine(SmoothToCenter()); 
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(-0.65f, 0.85f, 0), 1.5f, false);

        yield return new WaitForSeconds(1f);

        NextBehaviourChoice();
    }

    void GoToRight()
    {
        StopAllCoroutines();
        StartCoroutine(GoToRightEnum());
    }

    IEnumerator GoToRightEnum()
    {
        _obj_Harpia.GetComponent<Animator>().Play("Idle");
        _obj_Harpia.GetComponent<Animator>().speed = 1;
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, -12), 0.35f, RotateMode.Fast);
        StartCoroutine(SmoothToCenter());
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(0.65f, 0.85f, 0), 1.5f, false);

        yield return new WaitForSeconds(1f);

        NextBehaviourChoice();
    }

    void GoToCenter()
    {
        StopAllCoroutines();
        StartCoroutine(GoToCenterEnum());
    }

    IEnumerator GoToCenterEnum()
    {
        _obj_Harpia.GetComponent<Animator>().Play("Idle");
        _obj_Harpia.GetComponent<Animator>().speed = 1;
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(0, 0, 0), 2f, false);
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.35f, RotateMode.Fast);

        yield return new WaitForSeconds(1.5f);

        NextBehaviourChoice();
    }

    void GoToCharge()
    {
        StopAllCoroutines();
        StartCoroutine(GoToChargeEnum());
    }

    IEnumerator GoToChargeEnum()
    {
        _obj_Harpia.GetComponent<Animator>().Play("Idle");
        _obj_Harpia.GetComponent<Animator>().speed = 2.5f;
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(0, 0.85f, 0), 3f, false);
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.35f, RotateMode.Fast);

        yield return new WaitForSeconds(3.5f);

        NextBehaviourChoice();
    }

    void GoToLeftCharge()
    {
        StopAllCoroutines();
        StartCoroutine(GoToLeftChargeEnum());
    }

    IEnumerator GoToLeftChargeEnum()
    {
        _obj_Harpia.GetComponent<Animator>().Play("Idle");
        _obj_Harpia.GetComponent<Animator>().speed = 2.5f;
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(-1.65f, 0.85f, 0), 3f, false);
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.35f, RotateMode.Fast);

        yield return new WaitForSeconds(3.5f);

        NextBehaviourChoice();
    }

    void GoToRightCharge()
    {
        StopAllCoroutines();
        StartCoroutine(GoToRightChargeEnum());
    }

    IEnumerator GoToRightChargeEnum()
    {
        _obj_Harpia.GetComponent<Animator>().Play("Idle");
        _obj_Harpia.GetComponent<Animator>().speed = 2.5f;
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(1.65f, 0.7f, 0), 3f, false);
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.35f, RotateMode.Fast);

        yield return new WaitForSeconds(3.5f);

        NextBehaviourChoice();
    }

    void GoDive()
    {
        StopAllCoroutines();
        StartCoroutine(GoDiveEnum());
    }

    IEnumerator GoDiveEnum()
    {
        _obj_Harpia.GetComponent<Animator>().Play("Atack_Center");
        _obj_Harpia.GetComponent<Animator>().speed = 1;
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(0, -0.75f, 0), 1, false);
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.35f, RotateMode.Fast);
        StartCoroutine(SmoothToUp()); //1s

        yield return new WaitForSeconds(3.5f);

        NextBehaviourChoice();
    }

    void GoLeftDive()
    {
        StopAllCoroutines();
        StartCoroutine(GoLeftDiveEnum());
    }

    IEnumerator GoLeftDiveEnum()
    {
        _obj_Harpia.GetComponent<Animator>().Play("Atack_Left");
        _obj_Harpia.GetComponent<Animator>().speed = 1;
        StartCoroutine(SmoothUpRight());

        yield return new WaitForSeconds(2.3f);

        NextBehaviourChoice();
    }

    void GoToRightAfterDive()
    {
        StopAllCoroutines();
        StartCoroutine(GoToRightAfterDiveEnum());
    }

    IEnumerator GoToRightAfterDiveEnum()
    {
        _obj_Harpia.GetComponent<Animator>().Play("Idle");
        _obj_Harpia.GetComponent<Animator>().speed = 1;
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 12), 0.35f, RotateMode.Fast);
        StartCoroutine(SmoothToCenter());
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(0.65f, 0.85f, 0), 1.5f, false);

        yield return new WaitForSeconds(2.3f);

        NextBehaviourChoice();
    }

    void GoRightDive()
    {
        StopAllCoroutines();
        StartCoroutine(GoRightDiveEnum());
    }

    IEnumerator GoRightDiveEnum()
    {
        _obj_Harpia.GetComponent<Animator>().Play("Atack_Right");
        _obj_Harpia.GetComponent<Animator>().speed = 1;
        StartCoroutine(SmoothUpLeft());

        yield return new WaitForSeconds(2.3f);

        NextBehaviourChoice();
    }

    void GoToLeftAfterDive()
    {
        StopAllCoroutines();
        StartCoroutine(GoToLeftAfterDiveEnum());
    }
    IEnumerator GoToLeftAfterDiveEnum()
    {
        _obj_Harpia.GetComponent<Animator>().Play("Idle");
        _obj_Harpia.GetComponent<Animator>().speed = 1;
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, -12), 0.35f, RotateMode.Fast);
        StartCoroutine(SmoothToCenter());
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(-0.65f, 0.85f, 0), 1.5f, false);

        yield return new WaitForSeconds(2f);

        NextBehaviourChoice();
    }

    void NextBehaviourChoice()
    {
        if (behaviour == 0)
        {
            //1,2,3
            var exclude = new HashSet<int>() { 4,5,6,7,8,9,10,11 };
            var range = Enumerable.Range(1, 11).Where(i => !exclude.Contains(i));

            var rand = new System.Random();
            int index = rand.Next(0, 11 - exclude.Count);
            int nextbehaviour = range.ElementAt(index);

            Debug.Log(behaviour + ' ' + nextbehaviour);

            if (nextbehaviour == 1)
            {
                GoToLeft();
                behaviour = nextbehaviour;

                return;
            }

            if (nextbehaviour == 2)
            {
                GoToCenter();
                behaviour = nextbehaviour;

                return;
            }

            if (nextbehaviour == 3)
            {
                GoToRight();
                behaviour = nextbehaviour;

                return;
            }

        }
        
        if (behaviour == 1)
        {
            //1,2,3,4,6,9
            var exclude = new HashSet<int>() { 1,5,7,8,10,11 };
            var range = Enumerable.Range(1, 11).Where(i => !exclude.Contains(i));

            var rand = new System.Random();
            int index = rand.Next(0, 11 - exclude.Count);
            int nextbehaviour = range.ElementAt(index);

            Debug.Log(behaviour + ' ' + nextbehaviour);

            if (nextbehaviour == 2)
            {
                GoToCenter();
                behaviour = nextbehaviour;

                return;
            }

            if (nextbehaviour == 3)
            {
                GoToRight();
                behaviour = nextbehaviour;

                return;
            }

            if (nextbehaviour == 4)
            {
                GoToCharge();
                behaviour = nextbehaviour;

                return;
            }

            if (nextbehaviour == 6)
            {
                GoToLeftCharge();
                behaviour = nextbehaviour;

                return;
            }

            if (nextbehaviour == 9)
            {
                GoToRightCharge();
                behaviour = nextbehaviour;

                return;
            }

        }

        if (behaviour == 2)
        {
            //1,2,3,4,6,9
            var exclude = new HashSet<int>() { 2, 5, 7, 8, 10, 11 };
            var range = Enumerable.Range(1, 11).Where(i => !exclude.Contains(i));

            var rand = new System.Random();
            int index = rand.Next(0, 11 - exclude.Count);
            int nextbehaviour = range.ElementAt(index);

            Debug.Log(behaviour + ' ' + nextbehaviour);

            if (nextbehaviour == 1)
            {
                GoToLeft();
                behaviour = nextbehaviour;

                return;
            }

            if (nextbehaviour == 3)
            {
                GoToRight();
                behaviour = nextbehaviour;

                return;
            }

            if (nextbehaviour == 4)
            {
                GoToCharge();
                behaviour = nextbehaviour;

                return;
            }

            if (nextbehaviour == 6)
            {
                GoToLeftCharge();
                behaviour = nextbehaviour;

                return;
            }

            if (nextbehaviour == 9)
            {
                GoToRightCharge();
                behaviour = nextbehaviour;

                return;
            }

        }

        if (behaviour == 3)
        {
            //1,2,3,4,6,9
            var exclude = new HashSet<int>() { 3, 5, 7, 8, 10, 11 };
            var range = Enumerable.Range(1, 11).Where(i => !exclude.Contains(i));

            var rand = new System.Random();
            int index = rand.Next(0, 11 - exclude.Count);
            int nextbehaviour = range.ElementAt(index);

            Debug.Log(behaviour + ' ' + nextbehaviour);

            if (nextbehaviour == 1)
            {
                GoToLeft();
                behaviour = nextbehaviour;

                return;
            }

            if (nextbehaviour == 2)
            {
                GoToCenter();
                behaviour = nextbehaviour;

                return;
            }

            if (nextbehaviour == 4)
            {
                GoToCharge();
                behaviour = nextbehaviour;

                return;
            }

            if (nextbehaviour == 6)
            {
                GoToLeftCharge();
                behaviour = nextbehaviour;

                return;
            }

            if (nextbehaviour == 9)
            {
                GoToRightCharge();
                behaviour = nextbehaviour;

                return;
            }

        }

        if (behaviour == 4)
        {
            //5
            int nextbehaviour = 5;

            Debug.Log(behaviour + ' ' + nextbehaviour);

            if (nextbehaviour == 5)
            {
                GoDive();
                behaviour = nextbehaviour;

                return;
            }

        }

        if (behaviour == 5)
        {
            //2
            int nextbehaviour = 2;

            Debug.Log(behaviour + ' ' + nextbehaviour);

            if (nextbehaviour == 2)
            {
                GoToCenter();
                behaviour = nextbehaviour;

                return;
            }

        }

        if (behaviour == 6)
        {
            //7
            int nextbehaviour = 7;

            Debug.Log(behaviour + ' ' + nextbehaviour);

            if (nextbehaviour == 7)
            {
                GoLeftDive();
                behaviour = nextbehaviour;

                return;
            }

        }

        if (behaviour == 7)
        {
            //8
            int nextbehaviour = 8;

            Debug.Log(behaviour + ' ' + nextbehaviour);

            if (nextbehaviour == 8)
            {
                GoToRightAfterDive();
                behaviour = nextbehaviour;

                return;
            }

        }

        if (behaviour == 8)
        {

            //1,2
            var exclude = new HashSet<int>() { 3,4,5,6,7,8,9,10,11 };
            var range = Enumerable.Range(1, 11).Where(i => !exclude.Contains(i));

            var rand = new System.Random();
            int index = rand.Next(0, 11 - exclude.Count);
            int nextbehaviour = range.ElementAt(index);

            Debug.Log(behaviour + ' ' + nextbehaviour);

            if (nextbehaviour == 1)
            {
                GoToLeft();
                behaviour = nextbehaviour;

                return;
            }

            if (nextbehaviour == 2)
            {
                GoToCenter();
                behaviour = nextbehaviour;

                return;
            }

        }

        if (behaviour == 9)
        {
            //10
            int nextbehaviour = 10;

            Debug.Log(behaviour + ' ' + nextbehaviour);

            if (nextbehaviour == 10)
            {
                GoRightDive();
                behaviour = nextbehaviour;

                return;
            }
        }

        if (behaviour == 10)
        {
            //11
            int nextbehaviour = 11;

            Debug.Log(behaviour + ' ' + nextbehaviour);

            if (nextbehaviour == 11)
            {
                GoToRightAfterDive();
                behaviour = nextbehaviour;

                return;
            }

        }

        if (behaviour == 11)
        {
            //2,3
            var exclude = new HashSet<int>() { 1,4, 5, 6, 7, 8, 9, 10, 11 };
            var range = Enumerable.Range(1, 11).Where(i => !exclude.Contains(i));

            var rand = new System.Random();
            int index = rand.Next(0, 11 - exclude.Count);
            int nextbehaviour = range.ElementAt(index);

            Debug.Log(behaviour + ' ' + nextbehaviour);

            if (nextbehaviour == 2)
            {
                GoToCenter();
                behaviour = nextbehaviour;

                return;
            }

            if (nextbehaviour == 3)
            {
                GoToRight();
                behaviour = nextbehaviour;

                return;
            }
        }
    }

    IEnumerator SmoothToCenter()
    {
        yield return new WaitForSeconds(1f);
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.5f, RotateMode.Fast);
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
        GoToLeftAfterDive();
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
        //GoToRightAfterDive();
    }

    IEnumerator DelayIntro()
    {

        behaviour = 0;

        yield return new WaitForSeconds(5f);

        _obj_Harpia.GetComponent<Animator>().Play("Idle");
        _obj_Harpia.GetComponent<Animator>().speed = 1;
        //Toca Intro
        _musicController.clip = _musicas[0];
        _musicController.Play();
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(0, 0.85f, 0), 3f, false);

        yield return new WaitForSeconds(3f);
        _musicController.clip = _musicas[1];
        _musicController.Play();
        //Toca música
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.55f, RotateMode.Fast);

        NextBehaviourChoice();
    }


    int RandomRangeExcept(int min, int max, int[] excepts) {

        UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
        int rndNmbr = UnityEngine.Random.Range(1 , max + 1);

        for (int i = 1; i < excepts.Length;  i++)
        {
            if (rndNmbr == excepts[i])
            {
                rndNmbr = UnityEngine.Random.Range(1, max + 1);
                i = 1;
            }
        }

        return rndNmbr;

    }
}
