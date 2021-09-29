using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using System.Linq;

public class Scri_Helicoprion_Behaviour : MonoBehaviour
{

    public GameObject _obj_Helicoprion;
    public GameObject _obj_Sight;
    public AudioSource _musicController;
    public List<AudioClip> _musicas = new List<AudioClip>();

    public float tempoDoAtaque;

    private float timmer1;
    private bool timmerOn;
    private float timmer2;
    private bool chargeTime;

    public int _actualBossHealth;
    public int _maxBossHealth;
    private int _damageOverTime;
    private int _totalDamageOverTime;
    public int _boatDamage;

    private int behaviour;
    private int nextBehaviour;

    private bool _isDead;

    private void Start()
    {
        DefineBossMaxHealth(100, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartBattle();
        }

        TimmersOfCharge();
    }

    void StartBattle()
    {
        _obj_Helicoprion.transform.position = new Vector3(2, -2, -2);
        _obj_Sight.transform.position = new Vector3(0, -3.5f, -4);

        behaviour = nextBehaviour;

        StartCoroutine(StartBattleEnum());
    }

    IEnumerator StartBattleEnum()
    {

        //behaviour = 0;
        yield return new WaitForSeconds(0.5f);

        _obj_Sight.GetComponent<Transform>().DOLocalMove(new Vector3(0, -1, 0), 0.4f, false);

        yield return new WaitForSeconds(0.5f);

        _obj_Sight.GetComponent<Transform>().DOShakePosition(3, 0.25f, 80, 90, false, true);
        _musicController.clip = _musicas[3];
        _musicController.Play();

        yield return new WaitForSeconds(3f);

        _musicController.Stop();
        _obj_Sight.GetComponent<Transform>().DOLocalMove(new Vector3(0, -3.5f, 0), 1, false);

        yield return new WaitForSeconds(1f);

        //_obj_Harpia.GetComponent<Animator>().Play("Idle");
        //_obj_Harpia.GetComponent<Animator>().speed = 1;

        //Toca Intro
        _musicController.clip = _musicas[0];
        _musicController.Play();
        _obj_Helicoprion.GetComponent<Transform>().DOLocalMove(new Vector3(0, -2, -2), 2f, false);

        yield return new WaitForSeconds(3f);
        //Toca Música
        _musicController.clip = _musicas[1];
        _musicController.Play();

        NextBehaviourChoice();
    }

    void GoLeftDown()
    {
        StopAllCoroutines();
        behaviour = nextBehaviour;
        StartCoroutine(GoToLeftDownEnum());
    }

    IEnumerator GoToLeftDownEnum()
    {
        yield return new WaitForSeconds(0.1f);

        //_obj_Helicoprion.GetComponent<Animator>().Play("Idle");
        //_obj_Helicoprion.GetComponent<Animator>().speed = 1;

        _obj_Helicoprion.GetComponent<Transform>().DOLocalRotate(Vector3.zero, 0.1f, RotateMode.Fast);
        _obj_Helicoprion.GetComponent<Transform>().DOLocalMove(new Vector3(-2f, -2f, -2f), 3f, false);

        yield return new WaitForSeconds(3f);
        
        NextBehaviourChoice();
    }

    void GoRightDown()
    {
        StopAllCoroutines();
        behaviour = nextBehaviour;
        StartCoroutine(GoRightDownEnum());
    }

    IEnumerator GoRightDownEnum()
    {
        yield return new WaitForSeconds(0.1f);

        //_obj_Helicoprion.GetComponent<Animator>().Play("Idle");
        //_obj_Helicoprion.GetComponent<Animator>().speed = 1;

        _obj_Helicoprion.GetComponent<Transform>().DOLocalRotate(Vector3.zero, 0.1f, RotateMode.Fast);
        _obj_Helicoprion.GetComponent<Transform>().DOLocalMove(new Vector3(2f, -2f, -2f), 3f, false);

        yield return new WaitForSeconds(3f);
        NextBehaviourChoice();
    }

    void GoLeftMiddle()
    {
        StopAllCoroutines();
        behaviour = nextBehaviour;
        StartCoroutine(GoLeftMiddleEnum());
    }

    IEnumerator GoLeftMiddleEnum()
    {
        yield return new WaitForSeconds(0.1f);

        //_obj_Helicoprion.GetComponent<Animator>().Play("Idle");
        //_obj_Helicoprion.GetComponent<Animator>().speed = 1;

        _obj_Helicoprion.GetComponent<Transform>().DOLocalRotate(Vector3.zero, 0.1f, RotateMode.Fast);
        _obj_Helicoprion.GetComponent<Transform>().DOLocalMove(new Vector3(-2f, -1.25f, -2f), 3f, false);

        yield return new WaitForSeconds(3f);
        NextBehaviourChoice();
    }

    void GoRightMiddle()
    {
        StopAllCoroutines();
        behaviour = nextBehaviour;
        StartCoroutine(GoRightMiddleEnum());
    }

    IEnumerator GoRightMiddleEnum()
    {
        yield return new WaitForSeconds(0.1f);

        //_obj_Helicoprion.GetComponent<Animator>().Play("Idle");
        //_obj_Helicoprion.GetComponent<Animator>().speed = 1;

        _obj_Helicoprion.GetComponent<Transform>().DOLocalRotate(Vector3.zero, 0.1f, RotateMode.Fast);
        _obj_Helicoprion.GetComponent<Transform>().DOLocalMove(new Vector3(2f, -1.25f, -2f), 3f, false);

        yield return new WaitForSeconds(3f);
        NextBehaviourChoice();
    }

    void GoLeftTop()
    {
        StopAllCoroutines();
        behaviour = nextBehaviour;
        StartCoroutine(GoLeftTopEnum());
    }

    IEnumerator GoLeftTopEnum()
    {
        yield return new WaitForSeconds(0.1f);

        //_obj_Helicoprion.GetComponent<Animator>().Play("Idle");
        //_obj_Helicoprion.GetComponent<Animator>().speed = 1;

        _obj_Helicoprion.GetComponent<Transform>().DOLocalRotate(Vector3.zero, 0.1f, RotateMode.Fast);
        _obj_Helicoprion.GetComponent<Transform>().DOLocalMove(new Vector3(-2f, -0.5f, -2f), 3f, false);

        yield return new WaitForSeconds(3f);
        NextBehaviourChoice();
    }

    void GoRightTop()
    {
        StopAllCoroutines();
        behaviour = nextBehaviour;
        StartCoroutine(GoRighTopEnum());
    }

    IEnumerator GoRighTopEnum()
    {
        yield return new WaitForSeconds(0.1f);

        //_obj_Helicoprion.GetComponent<Animator>().Play("Idle");
        //_obj_Helicoprion.GetComponent<Animator>().speed = 1;

        _obj_Helicoprion.GetComponent<Transform>().DOLocalRotate(Vector3.zero, 0.1f, RotateMode.Fast);
        _obj_Helicoprion.GetComponent<Transform>().DOLocalMove(new Vector3(2f, -0.5f, -2f), 3f, false);

        yield return new WaitForSeconds(3f);
        NextBehaviourChoice();
    }

    void PrepareRightCharge()
    {
        StopAllCoroutines();
        behaviour = nextBehaviour;
        StartCoroutine(PrepareRightChargeEnum());
    }

    IEnumerator PrepareRightChargeEnum()
    {
        yield return new WaitForSeconds(0.1f);

        //_obj_Helicoprion.GetComponent<Animator>().Play("Idle");
        //_obj_Helicoprion.GetComponent<Animator>().speed = 2.5f;

        _obj_Helicoprion.GetComponent<Transform>().DOLocalRotate(Vector3.zero, 0.1f, RotateMode.Fast);
        _obj_Helicoprion.GetComponent<Transform>().DOLocalMove(new Vector3(0, -1.25f, -2f), 3f, false);

        yield return new WaitForSeconds(3f);

        NextBehaviourChoice();
    }

    void RepositionRightCharge()
    {
        StopAllCoroutines();
        behaviour = nextBehaviour;
        StartCoroutine(RepositionRightChargeEnum());
    }

    IEnumerator RepositionRightChargeEnum()
    {
        yield return new WaitForSeconds(0.1f);

        //_obj_Helicoprion.GetComponent<Animator>().Play("Idle");
        //_obj_Helicoprion.GetComponent<Animator>().speed = 2.5f;

        _obj_Helicoprion.GetComponent<Transform>().DOLocalRotate(Vector3.zero, 0.1f, RotateMode.Fast);
        _obj_Helicoprion.GetComponent<Transform>().DOLocalMove(new Vector3(2, -1.5f, -2f), 3f, false);

        yield return new WaitForSeconds(3f);
        
        NextBehaviourChoice();
    }

    void ChargeRight()
    {
        StopAllCoroutines();
        behaviour = nextBehaviour;
        StartCoroutine(ChargeRightEnum());
    }

    IEnumerator ChargeRightEnum()
    {
        chargeTime = true;
        behaviour = 9;

        yield return new WaitForSeconds(0.1f);

        _obj_Helicoprion.GetComponent<Transform>().position = new Vector3(0.8f, -3f, -2f);
        _obj_Helicoprion.GetComponent<Transform>().DOLocalRotate(new Vector3(0,0, -70f), 0.1f, RotateMode.Fast);

        //_obj_Helicoprion.GetComponent<Animator>().Play("Atack");
        //_obj_Helicoprion.GetComponent<Animator>().speed = 2.5f;

        _obj_Helicoprion.GetComponent<Transform>().DOLocalMove(new Vector3(0.15f, -0.25f, -2f), tempoDoAtaque, false);

        yield return new WaitForSeconds(tempoDoAtaque);
        
        NextBehaviourChoice();
    }

    void PrepareLeftCharge()
    {
        StopAllCoroutines();
        behaviour = nextBehaviour;
        StartCoroutine(PrepareLeftChargeEnum());
    }

    IEnumerator PrepareLeftChargeEnum()
    {
        yield return new WaitForSeconds(0.1f);

        //_obj_Helicoprion.GetComponent<Animator>().Play("Idle");
        //_obj_Helicoprion.GetComponent<Animator>().speed = 2.5f;

        _obj_Helicoprion.GetComponent<Transform>().DOLocalRotate(Vector3.zero, 0.1f, RotateMode.Fast);
        _obj_Helicoprion.GetComponent<Transform>().DOLocalMove(new Vector3(0, -1.25f, -2f), 3f, false);

        yield return new WaitForSeconds(3f);
        
        NextBehaviourChoice();
    }

    void RepositionLeftCharge()
    {

        StopAllCoroutines();
        behaviour = nextBehaviour;
        StartCoroutine(RepositionLeftChargeEnum());
    }

    IEnumerator RepositionLeftChargeEnum()
    {
        yield return new WaitForSeconds(0.1f);

        //_obj_Helicoprion.GetComponent<Animator>().Play("Idle");
        //_obj_Helicoprion.GetComponent<Animator>().speed = 2.5f;

        _obj_Helicoprion.GetComponent<Transform>().DOLocalRotate(Vector3.zero, 0.1f, RotateMode.Fast);
        _obj_Helicoprion.GetComponent<Transform>().DOLocalMove(new Vector3(-2, -1.5f, -2f), 3f, false);

        yield return new WaitForSeconds(3f);

        NextBehaviourChoice();
    }

    void ChargeLeft()
    {
        StopAllCoroutines();
        behaviour = nextBehaviour;
        StartCoroutine(ChargeLeftEnum());
    }

    IEnumerator ChargeLeftEnum()
    {
        chargeTime = true;
        behaviour = 12;

        yield return new WaitForSeconds(0.1f);

        _obj_Helicoprion.GetComponent<Transform>().position = new Vector3(-0.8f, -3f, -2f);
        _obj_Helicoprion.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 70f), 0.1f, RotateMode.Fast);

        //_obj_Helicoprion.GetComponent<Animator>().Play("Atack");
        //_obj_Helicoprion.GetComponent<Animator>().speed = 2.5f;

        _obj_Helicoprion.GetComponent<Transform>().DOLocalMove(new Vector3(-0.15f, -0.25f, -2f), tempoDoAtaque, false);

        yield return new WaitForSeconds(tempoDoAtaque);

        NextBehaviourChoice();
    }

    void NextBehaviourChoice()
    {
        if (behaviour == 0)
        {
            //Caminhos possiveis 1,3,5
            int[] naoPodeEsses = new int[] { 2,4,6,7,8,9,10,11,12,13,14 };
            nextBehaviour = RandomRangeExcept(naoPodeEsses);

            if (nextBehaviour == 1)
            {
                GoLeftDown();
                return;
            }

            if (nextBehaviour == 3)
            {
                GoLeftMiddle();
                return;
            }

            if (nextBehaviour == 5)
            {
                GoLeftTop();
                return;
            }
        }

        if (behaviour == 1)
        {
            //Caminhos possiveis 2,4,6,7
            int[] naoPodeEsses = new int[] { 1,3,5,8,9,10,11,12,13,14 };
            nextBehaviour = RandomRangeExcept(naoPodeEsses);

            if (nextBehaviour == 2)
            {
                GoRightDown();
                return;
            }

            if (nextBehaviour == 4)
            {
                GoRightMiddle();
                return;
            }

            if (nextBehaviour == 6)
            {
                GoRightTop();
                return;
            }

            if (nextBehaviour == 7)
            {
                PrepareRightCharge();
                return;
            }
        }

        if (behaviour == 2)
        {
            //Caminhos possiveis 1,3,5,10
            int[] naoPodeEsses = new int[] { 2,4,6,7,8,9,11,12,13,14 };
            nextBehaviour = RandomRangeExcept(naoPodeEsses);

            if (nextBehaviour == 1)
            {
                GoLeftDown();
                return;
            }

            if (nextBehaviour == 3)
            {
                GoLeftMiddle();
                return;
            }

            if (nextBehaviour == 5)
            {
                GoLeftTop();
                return;
            }

            if (nextBehaviour == 10)
            {
                PrepareLeftCharge();
                return;
            }
        }

        if (behaviour == 3)
        {
            //Caminhos possiveis 2,4,6,7
            int[] naoPodeEsses = new int[] { 1, 3, 5, 8, 9, 10, 11, 12, 13,14 };
            nextBehaviour = RandomRangeExcept(naoPodeEsses);

            if (nextBehaviour == 2)
            {
                GoRightDown();
                return;
            }

            if (nextBehaviour == 4)
            {
                GoRightMiddle();
                return;
            }

            if (nextBehaviour == 6)
            {
                GoRightTop();
                return;
            }

            if (nextBehaviour == 7)
            {
                PrepareRightCharge();
                return;
            }
        }

        if (behaviour == 4)
        {
            //Caminhos possiveis 1,3,5,10
            int[] naoPodeEsses = new int[] { 2, 4, 6, 7, 8, 9, 11, 12, 13,14 };
            nextBehaviour = RandomRangeExcept(naoPodeEsses);

            if (nextBehaviour == 1)
            {
                GoLeftDown();
                return;
            }

            if (nextBehaviour == 3)
            {
                GoLeftMiddle();
                return;
            }

            if (nextBehaviour == 5)
            {
                GoLeftTop();
                return;
            }

            if (nextBehaviour == 10)
            {
                PrepareLeftCharge();
                return;
            }
        }

        if (behaviour == 5)
        {
            //Caminhos possiveis 2,4,6,7
            int[] naoPodeEsses = new int[] { 1, 3, 5, 8, 9, 10, 11, 12, 13,14 };
            nextBehaviour = RandomRangeExcept(naoPodeEsses);

            if (nextBehaviour == 2)
            {
                GoRightDown();
                return;
            }

            if (nextBehaviour == 4)
            {
                GoRightMiddle();
                return;
            }

            if (nextBehaviour == 6)
            {
                GoRightTop();
                return;
            }

            if (nextBehaviour == 7)
            {
                PrepareRightCharge();
                return;
            }
        }

        if (behaviour == 6)
        {
            //Caminhos possiveis 1,3,5,10
            int[] naoPodeEsses = new int[] { 2, 4, 6, 7, 8, 9, 11, 12, 13,14 };
            nextBehaviour = RandomRangeExcept(naoPodeEsses);

            if (nextBehaviour == 1)
            {
                GoLeftDown();
                return;
            }

            if (nextBehaviour == 3)
            {
                GoLeftMiddle();
                return;
            }

            if (nextBehaviour == 5)
            {
                GoLeftTop();
                return;
            }

            if (nextBehaviour == 10)
            {
                PrepareLeftCharge();
                return;
            }
        }

        if (behaviour == 7)
        {
            //Caminhos possiveis 8
            nextBehaviour = 8;

            if (nextBehaviour == 8)
            {
                RepositionRightCharge();
                return;
            }
        }

        if (behaviour == 8)
        {
            //Caminhos possiveis 9
            nextBehaviour = 9;

            if (nextBehaviour == 9)
            {
                ChargeRight();
                return;
            }
        }
        /*
        if (behaviour == 9)
        {
            //Caminhos possiveis 13
            nextBehaviour = 13;

            if (nextBehaviour == 13)
            {
                ChargeFailRight();
                return;
            }
        }
        */
        if (behaviour == 10)
        {
            //Caminhos possiveis 11
            nextBehaviour = 11;

            if (nextBehaviour == 11)
            {
                RepositionLeftCharge();
                return;
            }
        }

        if (behaviour == 11)
        {
            //Caminhos possiveis 12
            nextBehaviour = 12;

            if (nextBehaviour == 12)
            {
                ChargeLeft();
                return;
            }
        }
        /*
        if (behaviour == 12)
        {
            //Caminhos possiveis 14
            nextBehaviour = 14;

            if (nextBehaviour == 14)
            {
                ChargeFailLeft();
                return;
            }
        }
        */
        if (behaviour == 13)
        {
            //Caminhos possiveis 2
            nextBehaviour = 2;

            if (nextBehaviour == 2)
            {
                GoRightDown();
                return;
            }
        }

        if (behaviour == 14)
        {
            //Caminhos possiveis 1
            nextBehaviour = 1;

            if (nextBehaviour == 1)
            {
                GoLeftDown();
                return;
            }
        }
    }
   
    int RandomRangeExcept(int[] excepts)
    {

        int[] estados = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
        UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
        var final = estados.Except(excepts).ToList();

        int rndNmbr = UnityEngine.Random.Range(0, final.Count);
        int rndOficial = final[rndNmbr];

        return rndOficial;

    }

    private void OnMouseDown()
    {

        ClickOnChargeTime();

    }
    void ClickOnChargeTime()
    {
        if (chargeTime)
        {
            timmerOn = true;
            _damageOverTime += _boatDamage;
            _totalDamageOverTime += _boatDamage;
        }
    }

    void Timmer500msCheck(int damage)
    {
        if (damage >= _maxBossHealth / 100)
        {
            StartCoroutine(ShakeDamage());

            //Aplica dano no boss
            DamageBossHealth(_damageOverTime);

            //Resseta o dano
            _damageOverTime = 0;

            //Resseta o timmer
            timmer1 = 0;
            timmerOn = false;
        }
        else
        {
            //Aplica dano no boss
            DamageBossHealth(_damageOverTime);

            //Resseta o dano
            _damageOverTime = 0;

            //Resseta o timmer
            timmer1 = 0;
            timmerOn = false;
        }
    }

    IEnumerator ShakeDamage()
    {
        _obj_Helicoprion.transform.DOShakePosition(0.1f, 0.05f, 1, 90, false, false);
        yield return new WaitForSeconds(0.15f);
        _obj_Helicoprion.transform.DOKill();
        _obj_Helicoprion.GetComponent<Transform>().DOLocalMove(new Vector3(0.15f, -0.25f, -2f), tempoDoAtaque, false);
    }

    void TimmersOfCharge()
    {
        if (timmerOn)
        {
            timmer1 += Time.deltaTime;

            if (timmer1 >= 0.5f)
            {
                Timmer500msCheck(_damageOverTime);
            }
        }

        if (chargeTime)
        {

            if (_totalDamageOverTime >= (int)(_maxBossHealth * 0.15f) && behaviour == 9)
            {
                ChargeFailRight();
            }
            if (_totalDamageOverTime >= (int)(_maxBossHealth * 0.15f) && behaviour == 12)
            {
                ChargeFailLeft();
            }

            if (timmer2 <= tempoDoAtaque)
            {
                timmer2 += Time.deltaTime;
            }
        }
    }

    void ChargeFailRight()
    {
        timmerOn = false;
        timmer1 = 0;
        timmer2 = 0;
        _totalDamageOverTime = 0;
        chargeTime = false;

        _obj_Helicoprion.transform.DOPause();
        
        StopAllCoroutines();

        nextBehaviour = 1;
        behaviour = nextBehaviour;

        StartCoroutine(FailRightCharge());

    }

    void ChargeFailLeft()
    {
        timmerOn = false;
        timmer1 = 0;
        timmer2 = 0;
        _totalDamageOverTime = 0;
        chargeTime = false;

        _obj_Helicoprion.transform.DOPause();

        StopAllCoroutines();

        nextBehaviour = 2;
        behaviour = nextBehaviour;

        StartCoroutine(FailLeftCharge());

    }

    IEnumerator FailRightCharge()
    {
        yield return new WaitForSeconds(0.1f);

        //_obj_Helicoprion.GetComponent<Animator>().Play("Idle");
        //_obj_Helicoprion.GetComponent<Animator>().speed = 1;

        _obj_Helicoprion.GetComponent<Transform>().DOLocalMove(new Vector3(0.8f, -3f, -2f), 4f, false);

        yield return new WaitForSeconds(4.1f);
        NextBehaviourChoice();
    }

    IEnumerator FailLeftCharge()
    {
        yield return new WaitForSeconds(0.1f);

        //_obj_Helicoprion.GetComponent<Animator>().Play("Idle");
        //_obj_Helicoprion.GetComponent<Animator>().speed = 1;

        _obj_Helicoprion.GetComponent<Transform>().DOLocalMove(new Vector3(-0.8f, -3f, -2f), 4f, false);

        yield return new WaitForSeconds(4.1f);
        NextBehaviourChoice();
    }

    int DefineBossMaxHealth(int baseBossMaxHealth, int dificultModifiy, float bossSequencyModify)
    {
        // 3º Boss da dificuldade 1 -> 250  = 100 * 1 * 2,5
        // 2º Boss da dificuldade 3 -> 525  = 100 * 3 * 1,75
        // 4º Boss da dificuldade 5 -> 1500 = 100 * 5 * 3;
        float healthCalculate = baseBossMaxHealth * dificultModifiy * bossSequencyModify;
        _maxBossHealth = (int)healthCalculate;
        _actualBossHealth = _maxBossHealth;

        return _actualBossHealth;
    }

    int DamageBossHealth(int damage)
    {

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

    int GetBossHealth()
    {
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

    void EndBattle()
    {
        _obj_Helicoprion.GetComponent<Transform>().DOPause();
        _obj_Helicoprion.GetComponent<Transform>().DOKill();

        StopAllCoroutines();

        _actualBossHealth = 0;

        timmerOn = false;
        timmer1 = 0;
        timmer2 = 0;
        _totalDamageOverTime = 0;
        chargeTime = false;

        StartCoroutine(EndBattleEnum());
    }

    IEnumerator EndBattleEnum()
    {
        this.gameObject.GetComponent<Collider2D>().enabled = false;

        //_obj_Helicoprion.GetComponent<Animator>().Play("Idle");
        //_obj_Helicoprion.GetComponent<Animator>().speed = 1f;

        _obj_Helicoprion.GetComponent<Transform>().DOLocalRotate(Vector3.zero, 0.2f, RotateMode.Fast);
        _obj_Helicoprion.GetComponent<Transform>().DOLocalMove(new Vector3(0, -1.25f, 0), 3f, false);
        _musicController.Stop();

        yield return new WaitForSeconds(1f);

        //_obj_Helicoprion.GetComponent<Animator>().Play("Idle");
        //_obj_Helicoprion.GetComponent<Animator>().speed = 1.5f;

        yield return new WaitForSeconds(1f);

        //_obj_Helicoprion.GetComponent<Animator>().Play("Idle");
        //_obj_Helicoprion.GetComponent<Animator>().speed = 2.5f;

        yield return new WaitForSeconds(1f);

        _musicController.clip = _musicas[2];
        _musicController.Play();

        _obj_Helicoprion.GetComponent<Transform>().DOLocalMove(new Vector3(0, 3.5f, 0), 1, false);

        yield return new WaitForSeconds(2f);

        _musicController.Stop();
        _isDead = true;
    }

}
