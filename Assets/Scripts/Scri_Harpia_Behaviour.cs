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
    public GameObject _obj_Sight;

    private int behaviour;
    private int nextBehaviour;
    private float stuckTime;

    public int _actualBossHealth;
    public int _maxBossHealth;
    private bool _isDead;
    private int _stageRage;

    private int _boatDamage;

    void Start()
    {
        //Boat Status
        //_boatDamage = 2;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartBattle();
        }

    }

    private void Update()
    {
        if(_stageRage >= 2)
        ForceUnStuckState();
    }

    void GoToLeft()
    {
        StopAllCoroutines(); 
        stuckTime = 0;
        behaviour = nextBehaviour;
        StartCoroutine(GoToLeftEnum());
    }

    IEnumerator GoToLeftEnum()
    {
        yield return new WaitForSeconds(0.1f);

        _obj_Harpia.GetComponent<Animator>().Play("Idle");
        _obj_Harpia.GetComponent<Animator>().speed = 1;
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 12), 0.35f, RotateMode.Fast);
        StartCoroutine(SmoothToCenter()); 
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(-0.65f, 1.85f, 0), 1.5f, false);

        yield return new WaitForSeconds(1f);

        NextBehaviourChoice();
    }

    void GoToRight()
    {
        StopAllCoroutines();
        stuckTime = 0;
        behaviour = nextBehaviour;
        StartCoroutine(GoToRightEnum());
    }

    IEnumerator GoToRightEnum()
    {
        yield return new WaitForSeconds(0.1f);

        _obj_Harpia.GetComponent<Animator>().Play("Idle");
        _obj_Harpia.GetComponent<Animator>().speed = 1;
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, -12), 0.35f, RotateMode.Fast);
        StartCoroutine(SmoothToCenter());
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(0.65f, 1.85f, 0), 1.5f, false);

        yield return new WaitForSeconds(1f);

        NextBehaviourChoice();
    }

    void GoToCenter()
    {
        StopAllCoroutines();
        stuckTime = 0;
        behaviour = nextBehaviour;
        StartCoroutine(GoToCenterEnum());
    }

    IEnumerator GoToCenterEnum()
    {
        yield return new WaitForSeconds(0.1f);

        _obj_Harpia.GetComponent<Animator>().Play("Idle");
        _obj_Harpia.GetComponent<Animator>().speed = 1;
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(0, 1, 0), 2f, false);
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.35f, RotateMode.Fast);

        yield return new WaitForSeconds(1.5f);

        NextBehaviourChoice();
    }

    void GoToCharge()
    {
        StopAllCoroutines();
        stuckTime = 0;
        behaviour = nextBehaviour;
        StartCoroutine(GoToChargeEnum());
    }

    IEnumerator GoToChargeEnum()
    {
        yield return new WaitForSeconds(0.1f);

        _obj_Harpia.GetComponent<Animator>().Play("Idle");
        _obj_Harpia.GetComponent<Animator>().speed = 2.5f;
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(0, 1.85f, 0), 3f, false);
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.35f, RotateMode.Fast);

        yield return new WaitForSeconds(3.5f);

        NextBehaviourChoice();
    }

    void GoToLeftCharge()
    {
        StopAllCoroutines();
        stuckTime = 0;
        behaviour = nextBehaviour;
        StartCoroutine(GoToLeftChargeEnum());
    }

    IEnumerator GoToLeftChargeEnum()
    {
        yield return new WaitForSeconds(0.1f);

        _obj_Harpia.GetComponent<Animator>().Play("Idle");
        _obj_Harpia.GetComponent<Animator>().speed = 2.5f;
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(-1.65f, 1.85f, 0), 3f, false);
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.35f, RotateMode.Fast);

        yield return new WaitForSeconds(3.5f);

        NextBehaviourChoice();
    }

    void GoToRightCharge()
    {
        StopAllCoroutines();
        stuckTime = 0;
        behaviour = nextBehaviour;
        StartCoroutine(GoToRightChargeEnum());
    }

    IEnumerator GoToRightChargeEnum()
    {
        yield return new WaitForSeconds(0.1f);

        _obj_Harpia.GetComponent<Animator>().Play("Idle");
        _obj_Harpia.GetComponent<Animator>().speed = 2.5f;
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(1.65f, 1.7f, 0), 3f, false);
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.35f, RotateMode.Fast);

        yield return new WaitForSeconds(3.5f);

        NextBehaviourChoice();
    }

    void GoDive()
    {
        StopAllCoroutines();
        stuckTime = 0;
        behaviour = nextBehaviour;
        StartCoroutine(GoDiveEnum());
    }

    IEnumerator GoDiveEnum()
    {
        yield return new WaitForSeconds(0.1f);

        _obj_Harpia.GetComponent<Animator>().Play("Atack_Center");
        _obj_Harpia.GetComponent<Animator>().speed = 1;
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(0, 0.5f, 0), 1, false);
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.35f, RotateMode.Fast);
        StartCoroutine(SmoothToUp()); //1s

        yield return new WaitForSeconds(3.5f);

        NextBehaviourChoice();
    }

    void GoLeftDive()
    {
        StopAllCoroutines();
        stuckTime = 0;
        behaviour = nextBehaviour;
        StartCoroutine(GoLeftDiveEnum());
    }

    IEnumerator GoLeftDiveEnum()
    {
        yield return new WaitForSeconds(0.1f);

        _obj_Harpia.GetComponent<Animator>().Play("Atack_Left");
        _obj_Harpia.GetComponent<Animator>().speed = 1;
        StartCoroutine(SmoothUpRight());

        yield return new WaitForSeconds(2.3f);

        NextBehaviourChoice();
    }

    void GoToRightAfterDive()
    {
        StopAllCoroutines();
        stuckTime = 0;
        behaviour = nextBehaviour;
        StartCoroutine(GoToRightAfterDiveEnum());
    }

    IEnumerator GoToRightAfterDiveEnum()
    {
        yield return new WaitForSeconds(0.1f);

        _obj_Harpia.GetComponent<Animator>().Play("Idle");
        _obj_Harpia.GetComponent<Animator>().speed = 1;
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 12), 0.35f, RotateMode.Fast);
        StartCoroutine(SmoothToCenter());
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(0.65f, 1.85f, 0), 1.5f, false);

        yield return new WaitForSeconds(2.3f);

        NextBehaviourChoice();
    }

    void GoRightDive()
    {
        StopAllCoroutines();
        stuckTime = 0;
        behaviour = nextBehaviour;
        StartCoroutine(GoRightDiveEnum());
    }

    IEnumerator GoRightDiveEnum()
    {
        yield return new WaitForSeconds(0.1f);

        _obj_Harpia.GetComponent<Animator>().Play("Atack_Right");
        _obj_Harpia.GetComponent<Animator>().speed = 1;
        StartCoroutine(SmoothUpLeft());

        yield return new WaitForSeconds(2.3f);

        NextBehaviourChoice();
    }

    void GoToLeftAfterDive()
    {
        StopAllCoroutines();
        stuckTime = 0;
        behaviour = nextBehaviour;
        StartCoroutine(GoToLeftAfterDiveEnum());
    }
    IEnumerator GoToLeftAfterDiveEnum()
    {
        yield return new WaitForSeconds(0.1f);

        _obj_Harpia.GetComponent<Animator>().Play("Idle");
        _obj_Harpia.GetComponent<Animator>().speed = 1;
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, -12), 0.35f, RotateMode.Fast);
        StartCoroutine(SmoothToCenter());
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(-0.65f, 1.85f, 0), 1.5f, false);

        yield return new WaitForSeconds(2f);

        NextBehaviourChoice();
    }

    void NextBehaviourChoice()
    {
        if (behaviour == 0)
        {
            //Caminhos possiveis 1,2,3
            int[] naoPodeEsses = new int[] { 4,5,6,7,8,9,10,11 };
            nextBehaviour = RandomRangeExcept(naoPodeEsses);

            if (nextBehaviour == 1)
            {

                GoToLeft();
                return;
            }

            if (nextBehaviour == 2)
            {

                GoToCenter();
                return;
            }

            if (nextBehaviour == 3)
            {

                GoToRight();
                return;
            }
        }

        if (behaviour == 1)
        {
            //Caminhos possiveis 2,3,4,6,9
            int[] naoPodeEsses = new int[] { 1, 5, 7, 8, 10, 11 };
            nextBehaviour = RandomRangeExcept(naoPodeEsses);

            if (nextBehaviour == 2)
            {
                GoToCenter();

                return;
            }

            if (nextBehaviour == 3)
            {
                GoToRight();
                return;
            }

            if (nextBehaviour == 4)
            {
                GoToCharge();
                return;
            }

            if (nextBehaviour == 6)
            {
                GoToLeftCharge();
                return;
            }

            if (nextBehaviour == 9)
            {
                GoToRightCharge();
                return;
            }

        }

        if (behaviour == 2)
        {            
            //Caminhos possiveis 1,3,4,6,9
            int[] naoPodeEsses = new int[] {2,5,7,8,10,11};
            nextBehaviour = RandomRangeExcept(naoPodeEsses);

            if (nextBehaviour == 1)
            {
                GoToLeft();
                return;
            }

            if (nextBehaviour == 3)
            {
                GoToRight();
                return; ;
            }

            if (nextBehaviour == 4)
            {
                GoToCharge();
                return;
            }

            if (nextBehaviour == 6)
            {
                GoToLeftCharge();
                return;
            }

            if (nextBehaviour == 9)
            {
                GoToRightCharge();
                return;
            }

        }

        if (behaviour == 3)
        {
            //Caminhos possiveis 1,2,4,6,9
            int[] naoPodeEsses = new int[] { 3,5,7,8,10,11};
            nextBehaviour = RandomRangeExcept(naoPodeEsses);

            if (nextBehaviour == 1)
            {
                GoToLeft();
                return;
            }

            if (nextBehaviour == 2)
            {
                GoToCenter();
                return;
            }

            if (nextBehaviour == 4)
            {
                GoToCharge();
                return;
            }

            if (nextBehaviour == 6)
            {
                GoToLeftCharge();
                return;
            }

            if (nextBehaviour == 9)
            {
                GoToRightCharge();
                return;
            }

        }

        if (behaviour == 4)
        {
            //5
            nextBehaviour = 5;

            if (nextBehaviour == 5)
            {
                GoDive();
                return;
            }

        }

        if (behaviour == 5)
        {
            //Caminhos possiveis 1,2,3
            int[] naoPodeEsses = new int[] { 4,5,6,7,8,9,10,11 };
            nextBehaviour = RandomRangeExcept(naoPodeEsses);

            if (nextBehaviour == 1)
            {
                GoToLeft();
                return;
            }

            if (nextBehaviour == 2)
            {
                GoToCenter();
                return;
            }

            if (nextBehaviour == 3)
            {
                GoToRight();
                return;
            }

        }

        if (behaviour == 6)
        {
            //7
            nextBehaviour = 7;

            if (nextBehaviour == 7)
            {
                GoLeftDive();
                return;
            }

        }

        if (behaviour == 7)
        {
            //8
            nextBehaviour = 8;

            if (nextBehaviour == 8)
            {
                GoToRightAfterDive();
                return;
            }

        }

        if (behaviour == 8)
        {
            //Caminhos possiveis 1,2
            int[] naoPodeEsses = new int[] { 3,4,5,6,7,8,9,10,11};
            nextBehaviour = RandomRangeExcept(naoPodeEsses);

            if (nextBehaviour == 1)
            {
                GoToLeft();
                return;
            }

            if (nextBehaviour == 2)
            {
                GoToCenter();
                return;
            }

        }

        if (behaviour == 9)
        {
            //10
            nextBehaviour = 10;

            if (nextBehaviour == 10)
            {
                GoRightDive();
                return;
            }
        }

        if (behaviour == 10)
        {
            //11
            nextBehaviour = 11;

            if (nextBehaviour == 11)
            {
                GoToLeftAfterDive();
                return;
            }

        }

        if (behaviour == 11)
        {
            //Caminhos possiveis 2,3
            int[] naoPodeEsses = new int[] {1,4,5,6,7,8,9,10,11};
            nextBehaviour = RandomRangeExcept(naoPodeEsses);

            if (nextBehaviour == 2)
            {
                GoToCenter();
                stuckTime = 0;
                behaviour = nextBehaviour;
                return;
            }

            if (nextBehaviour == 3)
            {
                GoToRight();
                stuckTime = 0;
                behaviour = nextBehaviour;
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
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(0, 1, 0), 2f, false);
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.1f, RotateMode.Fast);
    }

    IEnumerator SmoothUpLeft()
    {
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(0.2f, 0.5f, 0), 1, false);
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, -45), 1f, RotateMode.Fast);
        yield return new WaitForSeconds(0.5f);
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(-0.4f, 0.5f, 0), 0.8f, false);
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, -60), 0.8f, RotateMode.Fast);
        yield return new WaitForSeconds(0.175f);
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(-1.65f, 1.85f, 0), 0.85f, false);
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, -90), 0.3f, RotateMode.Fast);
        yield return new WaitForSeconds(1f);
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.1f, RotateMode.Fast);
        GoToLeftAfterDive();
    }

    IEnumerator SmoothUpRight()
    {
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(-0.2f, 0.5f, 0), 1, false);
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 45), 1f, RotateMode.Fast);
        yield return new WaitForSeconds(0.5f);
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(0.4f, 0.5f, 0), 0.8f, false);
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 60), 0.8f, RotateMode.Fast);
        yield return new WaitForSeconds(0.175f);
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(1.65f, 1.85f, 0), 0.85f, false);
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 90), 0.3f, RotateMode.Fast);
        yield return new WaitForSeconds(1f);
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0,0), 0.1f, RotateMode.Fast);
        //GoToRightAfterDive();
    }

    void StartBattle()
    {
        _isDead = false;
        _stageRage = 1;
        DefineBossMaxHealth(100, 1, 1);

        //stuckTime = -5;
        StartCoroutine(StartBattleEnum());
    }

    IEnumerator StartBattleEnum()
    {

        behaviour = 0;
        yield return new WaitForSeconds(0.5f);

        _obj_Sight.GetComponent<Transform>().DOLocalMove(new Vector3(0, 1, 0), 0.4f, false);

        yield return new WaitForSeconds(0.5f);

        _obj_Sight.GetComponent<Transform>().DOShakePosition(3, 0.25f, 80,90,false,true);
        _musicController.clip = _musicas[3];
        _musicController.Play();

        yield return new WaitForSeconds(3f);

        _musicController.Stop();
        _obj_Sight.GetComponent<Transform>().DOLocalMove(new Vector3(0, 3.5f, 0), 1, false);

        yield return new WaitForSeconds(1f);

        _obj_Harpia.GetComponent<Animator>().Play("Idle");
        _obj_Harpia.GetComponent<Animator>().speed = 1;
        //Toca Intro
        _musicController.clip = _musicas[0];
        _musicController.Play();
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(0, 1.85f, 0), 3f, false);

        yield return new WaitForSeconds(3f);
        _musicController.clip = _musicas[1];
        _musicController.Play();
        //Toca m?sica
        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.55f, RotateMode.Fast);

        NextBehaviourChoice();
    }

    void EndBattle()
    {
        StopAllCoroutines();
        StartCoroutine(EndBattleEnum());
    }

    IEnumerator EndBattleEnum()
    {
        _actualBossHealth = 0;
        _stageRage = 0;
        this.gameObject.GetComponent<Collider2D>().enabled = false;

        _obj_Harpia.GetComponent<Animator>().Play("Idle");
        _obj_Harpia.GetComponent<Animator>().speed = 1f;

        _obj_Harpia.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.25f, RotateMode.Fast);
        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(0, 1, 0), 3f, false);
        _musicController.Stop();

        yield return new WaitForSeconds(1f);

        _obj_Harpia.GetComponent<Animator>().Play("Idle");
        _obj_Harpia.GetComponent<Animator>().speed = 1.5f;

        yield return new WaitForSeconds(1f);

        _obj_Harpia.GetComponent<Animator>().Play("Idle");
        _obj_Harpia.GetComponent<Animator>().speed = 2.5f;

        yield return new WaitForSeconds(1f);

        _musicController.clip = _musicas[2];
        _musicController.Play();

        _obj_Harpia.GetComponent<Transform>().DOLocalMove(new Vector3(0, 3.5f, 0), 1, false);

        yield return new WaitForSeconds(2f);

        _musicController.Stop();
        _isDead = true;
    }

    int RandomRangeExcept(int[] excepts) {

        int[] estados = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
        UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
        var final = estados.Except(excepts).ToList();

        int rndNmbr = UnityEngine.Random.Range(0,final.Count);
        int rndOficial = final[rndNmbr];

        return rndOficial;

    }

    void ForceUnStuckState()
    {
        if (stuckTime > 5f)
        {
            NextBehaviourChoice();
            stuckTime = 0;
        }
        else
        {
            stuckTime += Time.deltaTime;
        }
    }

    int GetBossHealth()
    {
        return _actualBossHealth;
    }

    int DefineBossMaxHealth(int baseBossMaxHealth, int dificultModifiy, float bossSequencyModify )
    {
        // 3? Boss da dificuldade 1 -> 250  = 100 * 1 * 2,5
        // 2? Boss da dificuldade 3 -> 525  = 100 * 3 * 1,75
        // 4? Boss da dificuldade 5 -> 1500 = 100 * 5 * 3;
        float healthCalculate = baseBossMaxHealth * dificultModifiy * bossSequencyModify;
        _maxBossHealth = (int) healthCalculate;
        _actualBossHealth = _maxBossHealth;

        return _actualBossHealth;
    }

    int DamageBossHealth(int damage)
    {
        if ((_actualBossHealth <= (int) _maxBossHealth * 0.75f) && _stageRage == 1)
        {
            stuckTime = -5;
            NextBehaviourChoice();
            _stageRage += 1;
            Debug.Log("Rage " + _stageRage);
        }

        if (_actualBossHealth - damage <= 0)
        {
            EndBattle();
        }
        else
        {
            _actualBossHealth -= damage;
        }

        return _actualBossHealth;
    }

    int HealBossHealth(int heal)
    {
        if (_actualBossHealth + heal >= _maxBossHealth)
        {
            _actualBossHealth = _maxBossHealth;
        }
        else
        {
            _actualBossHealth += heal;
        }

        return _actualBossHealth;
    }

    private void OnMouseDown()
    {
        DamageBossHealth(_boatDamage);
    }
}
