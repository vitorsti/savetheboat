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
    private float timmer3;

    public int _actualBossHealth;
    public int _maxBossHealth;
    private int _damageOverTime;
    private int _totalDamageOverTime;
    public int _boatDamage;

    private int behaviour;
    private int nextBehaviour;

    private void Start()
    {
        DefineBossMaxHealth(100, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartBattle();

        if (Input.GetKeyDown(KeyCode.Alpha1))
            GoLeftDown();

        if (Input.GetKeyDown(KeyCode.Alpha2))
            GoRightDown();

        if (Input.GetKeyDown(KeyCode.Alpha3))
            GoLeftMiddle();

        if (Input.GetKeyDown(KeyCode.Alpha4))
            GoRightMiddle();

        if (Input.GetKeyDown(KeyCode.Alpha5))
            GoLeftTop();

        if (Input.GetKeyDown(KeyCode.Alpha6))
            GoRighTop();

        if (Input.GetKeyDown(KeyCode.Alpha7))
            PrepareRightCharge();

        if (Input.GetKeyDown(KeyCode.Alpha8))
            RepositionRightCharge();

        if (Input.GetKeyDown(KeyCode.Alpha9))
            ChargeRight();

        if (Input.GetKeyDown(KeyCode.Q))
            PrepareLeftCharge();

        if (Input.GetKeyDown(KeyCode.W))
            RepositionLeftCharge();

        if (Input.GetKeyDown(KeyCode.E))
            ChargeLeft();

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

            if (_totalDamageOverTime >= (int)(_maxBossHealth * 0.15f))
            {
                ChargeFail();
            }

            if (timmer2 <= tempoDoAtaque)
            {
                timmer2 += Time.deltaTime;
            }
        }


    }

    void ChargeFail()
    {

        Debug.LogWarning("Falhou o Ataque!");

        timmerOn = false;
        timmer1 = 0;
        timmer2 = 0;
        _totalDamageOverTime = 0;
        chargeTime = false;

        _obj_Helicoprion.transform.DOPause();   

        //Falhou Direita
        if (behaviour == 9) 
            StartCoroutine(FailRightCharge());

        //Falhou Esquerda
        if (behaviour == 12)
            StartCoroutine(FailLeftCharge());

    }

    IEnumerator FailRightCharge()
    {
        yield return new WaitForSeconds(0.1f);

        //_obj_Helicoprion.GetComponent<Animator>().Play("Idle");
        //_obj_Helicoprion.GetComponent<Animator>().speed = 1;

        _obj_Helicoprion.GetComponent<Transform>().DOLocalMove(new Vector3(0.8f, -3f, -2f), 4f, false);

        yield return new WaitForSeconds(1f);
        //NextBehaviourChoice();
    }

    IEnumerator FailLeftCharge()
    {
        yield return new WaitForSeconds(0.1f);

        //_obj_Helicoprion.GetComponent<Animator>().Play("Idle");
        //_obj_Helicoprion.GetComponent<Animator>().speed = 1;

        _obj_Helicoprion.GetComponent<Transform>().DOLocalMove(new Vector3(-0.8f, -3f, -2f), 4f, false);

        yield return new WaitForSeconds(1f);
        //NextBehaviourChoice();
    }

    void StartBattle()
    {
        _obj_Helicoprion.transform.position = new Vector3(2, -2, -2);
        _obj_Sight.transform.position = new Vector3(0, -3.5f, -4);

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

        //NextBehaviourChoice();
    }

    void GoLeftDown()
    {
        StartCoroutine(GoToLeftDownEnum());
    }

    IEnumerator GoToLeftDownEnum()
    {
        yield return new WaitForSeconds(0.1f);

        //_obj_Helicoprion.GetComponent<Animator>().Play("Idle");
        //_obj_Helicoprion.GetComponent<Animator>().speed = 1;

        _obj_Helicoprion.GetComponent<Transform>().DOLocalMove(new Vector3(-2f, -2f, -2f), 3f, false);

        yield return new WaitForSeconds(1f);
        //NextBehaviourChoice();
    }

    void GoRightDown()
    {
        StartCoroutine(GoRightDownEnum());
    }

    IEnumerator GoRightDownEnum()
    {
        yield return new WaitForSeconds(0.1f);

        //_obj_Helicoprion.GetComponent<Animator>().Play("Idle");
        //_obj_Helicoprion.GetComponent<Animator>().speed = 1;

        _obj_Helicoprion.GetComponent<Transform>().DOLocalMove(new Vector3(2f, -2f, -2f), 3f, false);

        yield return new WaitForSeconds(1f);
        //NextBehaviourChoice();
    }

    void GoLeftMiddle()
    {
        StartCoroutine(GoLeftMiddleEnum());
    }

    IEnumerator GoLeftMiddleEnum()
    {
        yield return new WaitForSeconds(0.1f);

        //_obj_Helicoprion.GetComponent<Animator>().Play("Idle");
        //_obj_Helicoprion.GetComponent<Animator>().speed = 1;

        _obj_Helicoprion.GetComponent<Transform>().DOLocalMove(new Vector3(-2f, -1.25f, -2f), 3f, false);

        yield return new WaitForSeconds(1f);
        //NextBehaviourChoice();
    }

    void GoRightMiddle()
    {
        StartCoroutine(GoRightMiddleEnum());
    }

    IEnumerator GoRightMiddleEnum()
    {
        yield return new WaitForSeconds(0.1f);

        //_obj_Helicoprion.GetComponent<Animator>().Play("Idle");
        //_obj_Helicoprion.GetComponent<Animator>().speed = 1;

        _obj_Helicoprion.GetComponent<Transform>().DOLocalMove(new Vector3(2f, -1.25f, -2f), 3f, false);

        yield return new WaitForSeconds(1f);
        //NextBehaviourChoice();
    }

    void GoLeftTop()
    {
        StartCoroutine(GoLeftTopEnum());
    }

    IEnumerator GoLeftTopEnum()
    {
        yield return new WaitForSeconds(0.1f);

        //_obj_Helicoprion.GetComponent<Animator>().Play("Idle");
        //_obj_Helicoprion.GetComponent<Animator>().speed = 1;

        _obj_Helicoprion.GetComponent<Transform>().DOLocalMove(new Vector3(-2f, -0.5f, -2f), 3f, false);

        yield return new WaitForSeconds(1f);
        //NextBehaviourChoice();
    }

    void GoRighTop()
    {
        StartCoroutine(GoRighTopEnum());
    }

    IEnumerator GoRighTopEnum()
    {
        yield return new WaitForSeconds(0.1f);

        //_obj_Helicoprion.GetComponent<Animator>().Play("Idle");
        //_obj_Helicoprion.GetComponent<Animator>().speed = 1;

        _obj_Helicoprion.GetComponent<Transform>().DOLocalMove(new Vector3(2f, -0.5f, -2f), 3f, false);

        yield return new WaitForSeconds(1f);
        //NextBehaviourChoice();
    }

    void PrepareRightCharge()
    {
        StopAllCoroutines();
        StartCoroutine(PrepareRightChargeEnum());
    }

    IEnumerator PrepareRightChargeEnum()
    {
        yield return new WaitForSeconds(0.1f);

        //_obj_Helicoprion.GetComponent<Animator>().Play("Idle");
        //_obj_Helicoprion.GetComponent<Animator>().speed = 2.5f;

        _obj_Helicoprion.GetComponent<Transform>().DOLocalMove(new Vector3(0, -1.25f, -2f), 3f, false);

        yield return new WaitForSeconds(1f);
        //NextBehaviourChoice();
    }

    void RepositionRightCharge()
    {
        StartCoroutine(RepositionRightChargeEnum());
    }

    IEnumerator RepositionRightChargeEnum()
    {
        yield return new WaitForSeconds(0.1f);

        //_obj_Helicoprion.GetComponent<Animator>().Play("Idle");
        //_obj_Helicoprion.GetComponent<Animator>().speed = 2.5f;

        _obj_Helicoprion.GetComponent<Transform>().DOLocalMove(new Vector3(2, -1.5f, -2f), 3f, false);

        yield return new WaitForSeconds(1f);
        //NextBehaviourChoice();
    }

    void ChargeRight()
    {
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
        //NextBehaviourChoice();
    }

    void PrepareLeftCharge()
    {
        StartCoroutine(PrepareLeftChargeEnum());
    }

    IEnumerator PrepareLeftChargeEnum()
    {
        yield return new WaitForSeconds(0.1f);

        //_obj_Helicoprion.GetComponent<Animator>().Play("Idle");
        //_obj_Helicoprion.GetComponent<Animator>().speed = 2.5f;

        _obj_Helicoprion.GetComponent<Transform>().DOLocalMove(new Vector3(0, -1.25f, -2f), 3f, false);

        yield return new WaitForSeconds(1f);
        //NextBehaviourChoice();
    }

    void RepositionLeftCharge()
    {
        StartCoroutine(RepositionLeftChargeEnum());
    }

    IEnumerator RepositionLeftChargeEnum()
    {
        yield return new WaitForSeconds(0.1f);

        //_obj_Helicoprion.GetComponent<Animator>().Play("Idle");
        //_obj_Helicoprion.GetComponent<Animator>().speed = 2.5f;

        _obj_Helicoprion.GetComponent<Transform>().DOLocalMove(new Vector3(-2, -1.5f, -2f), 3f, false);

        yield return new WaitForSeconds(1f);
        //NextBehaviourChoice();
    }

    void ChargeLeft()
    {
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
        //NextBehaviourChoice();
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
            //Aplica dano no boss
            DamageBossHealth(_damageOverTime);

            StartCoroutine(ShakeDamage());

            //Resseta o dano
            Debug.Log("O dano foi mais de 1%, e foi: " + _damageOverTime);
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
            Debug.Log("O dano foi: " + _damageOverTime);
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
        _obj_Helicoprion.transform.DOPause();
        _obj_Helicoprion.GetComponent<Transform>().DOLocalMove(new Vector3(0.15f, -0.25f, -2f), tempoDoAtaque, false);
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

    void EndBattle()
    {

    }


}
