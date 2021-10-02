using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StoreWindowController : MonoBehaviour
{
    public GameObject boatsButton, boatsTabs, bossDealsButton, bossDealsTab, offersTab;
    public RectTransform myRt;
    bool bt = false;
    bool bst = false;

    void Awake()
    {

        myRt = GetComponent<RectTransform>();
    }

    public void BoatsButton()
    {
        if (!bt)
        {
            StartCoroutine(SetBoatsTab());
        }
        else
            StartCoroutine(BackBoatsTab());
    }

    public void BossDealsButton()
    {
        if (!bst)
            StartCoroutine(SetBossTab());
        else
            StartCoroutine(BackBossTab());
    }

    IEnumerator SetBoatsTab()
    {
        if (bossDealsTab.activeInHierarchy)
        {
            myRt.offsetMin = new Vector2(0, 0);
            yield return new WaitForSeconds(0.1f);
            bossDealsButton.transform.DOLocalMoveY(-600, 0.5f, false);
            offersTab.transform.DOLocalMoveY(-2100, 0.5f, false);
            yield return new WaitForSeconds(0.1f);
            boatsTabs.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            myRt.offsetMin = new Vector2(0, -1600);


        }
        else
        {


            bossDealsButton.transform.DOLocalMoveY(-600, 0.5f, false);
            offersTab.transform.DOLocalMoveY(-1200, 0.5f, false);
            yield return new WaitForSeconds(0.1f);
            boatsTabs.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            myRt.offsetMin = new Vector2(0, -700);


        }
        bt = true;

    }

    IEnumerator BackBoatsTab()
    {
        if (bossDealsTab.activeInHierarchy)
        {
            myRt.offsetMin = new Vector2(0, 0);
            yield return new WaitForSeconds(0.1f);
            bossDealsButton.transform.DOLocalMoveY(320, 0.5f, false);
            offersTab.transform.DOLocalMoveY(-1200, 0.5f, false);
            yield return new WaitForSeconds(0.1f);
            boatsTabs.SetActive(false);
            yield return new WaitForSeconds(0.4f);
            myRt.offsetMin = new Vector2(0, -700);

        }
        else
        {
            myRt.offsetMin = new Vector2(0, 0);
            yield return new WaitForSeconds(0.1f);
            bossDealsButton.transform.DOLocalMoveY(320, 0.5f, false);
            offersTab.transform.DOLocalMoveY(-336, 0.5f, false);
            yield return new WaitForSeconds(0.1f);
            boatsTabs.SetActive(false);
        }
        bt = false;
    }

    IEnumerator SetBossTab()
    {
        if (boatsTabs.activeInHierarchy)
        {
            myRt.offsetMin = new Vector2(0, 0);
            yield return new WaitForSeconds(0.1f);
            offersTab.transform.DOLocalMoveY(-2100, 0.5f, false);
            yield return new WaitForSeconds(0.1f);
            bossDealsTab.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            myRt.offsetMin = new Vector2(0, -1600);
        }
        else
        {
            offersTab.transform.DOLocalMoveY(-1200, 0.5f, false);
            yield return new WaitForSeconds(0.1f);
            bossDealsTab.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            myRt.offsetMin = new Vector2(0, -700);
        }
        yield return null;
        bst = true;
    }

    IEnumerator BackBossTab()
    {
        if (boatsTabs.activeInHierarchy)
        {
            myRt.offsetMin = new Vector2(0, 0);
            yield return new WaitForSeconds(0.1f);
            offersTab.transform.DOLocalMoveY(-1200, 0.5f, false);
            yield return new WaitForSeconds(0.1f);
            bossDealsTab.SetActive(false);
            yield return new WaitForSeconds(0.4f);
            myRt.offsetMin = new Vector2(0, -700);
        }
        else
        {
            myRt.offsetMin = new Vector2(0, 0);
            yield return new WaitForSeconds(0.1f);
            offersTab.transform.DOLocalMoveY(-336, 0.5f, false);
            yield return new WaitForSeconds(0.1f);
            bossDealsTab.SetActive(false);
        }
        yield return null;
        bst = false;
    }
}
