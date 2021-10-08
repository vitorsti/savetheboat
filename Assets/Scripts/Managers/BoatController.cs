using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public int strenght;
    public int currentLife;
    public int totalLife;

    public bool invencible;

    public float boatSpeed;

    [Header("Double Tap")]
    public float doubleTapGap;
    public bool checkingDoubleTap;
    public bool isDoubleTap;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!checkingDoubleTap)
            {
                isDoubleTap = false;
                StartCoroutine(DoubleTapCheck());
            }
            else
            {
                isDoubleTap = true;
            }

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.transform.gameObject.tag == "Mobs")
            {
                hit.transform.gameObject.GetComponent<Monster>().RemoveHealth(strenght);
            }

            if (hit.collider != null && hit.transform.gameObject.tag == "PowerUp")
            {
                hit.transform.gameObject.GetComponent<PowerUpBase>().ActivatePowerUp();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Mobs")
        {
            RemoveHealth(gameObject.GetComponent<Monster>().strength);
        }
    }

    public void RemoveHealth(int value)
    {
        if (!invencible)
        {
            currentLife -= value;
            if (currentLife <= 0)
                GameOver();
        }
    }

    public void HealHealth(int value)
    {
        if (currentLife < totalLife)
        {
            if ((currentLife + value) > totalLife)
                currentLife = totalLife;
            else
                currentLife += value;
        }
    }

    public void TurnInvencible(bool turn)
    {
        invencible = turn;
    }

    IEnumerator DoubleTapCheck()
    {
        checkingDoubleTap = true;
        yield return new WaitForSeconds(doubleTapGap);
        checkingDoubleTap = false;
    }

    private void GameOver()
    {
        Debug.Log("Cabo");
    }
}
