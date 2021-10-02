using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class BoatsContentPageManager : MonoBehaviour
{
    public enum StoreType { normalDeals, bossDeals };
    public StoreType storeType;
    public BoatsValuesContainer boatsData;
    public List<int> sortedBoats = new List<int>();
    public List<GameObject> prefabs;
    public GameObject prefab;
    public TextMeshProUGUI pageInfoTxt;
    public GameObject pageIndicatorHolder;
    public GameObject pageIndicatorPrefab;
    public List<GameObject> pageIndicatorPrefabs;

    [SerializeField]
    private float itensPerPage;
    [SerializeField]
    private float totalPages;
    [SerializeField]
    public int page;
    int index;

    // Start is called before the first frame update
    private void OnValidate()
    {

    }

    private void Awake()
    {
        boatsData = Resources.Load<BoatsValuesContainer>("ScriptableObjects/BoatsData");
        /*for (int i = 0; i < boatsData.boatsStoreDatas.Length; i++)
        {
            boatsData.boatsStoreDatas[i].ins = false;
        }*/
    }

    private void Start()
    {
        SortedBoats();
        CalculatePages();
        Spawn(1);
        PageInfo();

    }

    public void SortedBoats()
    {
        if (storeType == StoreType.normalDeals)
        {
            for (int n = 0; n < boatsData.boatsStoreDatas.Length; n++)
            {
                //instancia o barco selecionado
                if (boatsData.boatsStoreDatas[n].hasBougth && boatsData.boatsStoreDatas[n].boatSelected && !boatsData.boatsStoreDatas[n].bossDeal)
                {
                    //sortedBoats.Add(boatsData.boatsStoreDatas[n].id);
                    sortedBoats.Add(boatsData.boatsStoreDatas[n].id);
                }
            }

            for (int n = 0; n < boatsData.boatsStoreDatas.Length; n++)
            {
                if (boatsData.boatsStoreDatas[n].hasBougth && !boatsData.boatsStoreDatas[n].boatSelected && !boatsData.boatsStoreDatas[n].bossDeal)
                {
                    sortedBoats.Add(boatsData.boatsStoreDatas[n].id);
                }
            }
            for (int n = 0; n < boatsData.boatsStoreDatas.Length; n++)
            {
                if (!boatsData.boatsStoreDatas[n].hasBougth && !boatsData.boatsStoreDatas[n].boatSelected && !boatsData.boatsStoreDatas[n].bossDeal)
                {
                    sortedBoats.Add(boatsData.boatsStoreDatas[n].id);
                }
            }
        }
        if(storeType == StoreType.bossDeals)
        {

            for (int n = 0; n < boatsData.boatsStoreDatas.Length; n++)
            {
                //instancia o barco selecionado
                if (boatsData.boatsStoreDatas[n].hasBougth && boatsData.boatsStoreDatas[n].boatSelected && boatsData.boatsStoreDatas[n].bossDeal)
                {
                    //sortedBoats.Add(boatsData.boatsStoreDatas[n].id);
                    sortedBoats.Add(boatsData.boatsStoreDatas[n].id);
                }
            }

            for (int n = 0; n < boatsData.boatsStoreDatas.Length; n++)
            {
                if (boatsData.boatsStoreDatas[n].hasBougth && !boatsData.boatsStoreDatas[n].boatSelected && boatsData.boatsStoreDatas[n].bossDeal)
                {
                    sortedBoats.Add(boatsData.boatsStoreDatas[n].id);
                }
            }
            for (int n = 0; n < boatsData.boatsStoreDatas.Length; n++)
            {
                if (!boatsData.boatsStoreDatas[n].hasBougth && !boatsData.boatsStoreDatas[n].boatSelected && boatsData.boatsStoreDatas[n].bossDeal)
                {
                    sortedBoats.Add(boatsData.boatsStoreDatas[n].id);
                }
            }

        }


        for (int i = 0; i < sortedBoats.Count; i++)
        {

            Debug.Log(i + " " + sortedBoats[i]);
        }
    }

    public void CalculatePages()
    {
        if (/*boatsData.boatsDatas.Length*/ sortedBoats.Count % itensPerPage == 0)
        {
            Debug.Log("integer");
            float div = /*boatsData.boatsDatas.Length*/ sortedBoats.Count / itensPerPage;
            totalPages = div;
        }
        else
        {
            Debug.Log("not integer");
            float div = /*boatsData.boatsDatas.Length*/ sortedBoats.Count / itensPerPage;
            totalPages = (int)div + 1;
        }

        page = 1;
        int temp = (int)totalPages;
        do
        {
            GameObject go = Instantiate(pageIndicatorPrefab, pageIndicatorHolder.transform.position, pageIndicatorHolder.transform.rotation, pageIndicatorHolder.transform);
            pageIndicatorPrefabs.Add(go);
            temp--;
        } while (temp > 0);
    }



    public void Spawn(int _page)
    {

        if (prefabs.Count > 0)
        {
            foreach (GameObject i in prefabs)
            {
                Destroy(i);
            }
            prefabs.Clear();
        }



        if (_page != totalPages)
        {

            int c = (int)itensPerPage * _page;

            for (int i = 0; i < sortedBoats.Count /*boats.Count*/; i++)
            {
                Debug.Log(i);
                if (i == c - 1)
                {
                    /*pageCounter += 1;
                    Debug.Log("page counter:" + pageCounter);
                    if (pageCounter == _page)
                    {*/
                    Debug.Log("index: " + i);
                    index = i;
                    break;
                    //}
                }

            }
            //spawn from page 1 to last but one
            for (int i = (index + 1) - ((int)itensPerPage); i < index + 1; i++)
            {
                GameObject go = Instantiate(prefab, this.gameObject.transform.position, this.gameObject.transform.rotation, this.gameObject.transform);
                prefabs.Add(go);
                go.name = boatsData.GetName(sortedBoats[i], null);

            }
        }
        else
        {
            if (page > 1)
            {
                //spawn last page
                for (int i = index + 1; i < sortedBoats.Count; i++)
                {

                    GameObject go = Instantiate(prefab, this.gameObject.transform.position, this.gameObject.transform.rotation, this.gameObject.transform);
                    prefabs.Add(go);
                    go.name = boatsData.GetName(sortedBoats[i], null);



                }
            }

            if (page == 1)
            {
                for (int i = index; i < sortedBoats.Count; i++)
                {

                    GameObject go = Instantiate(prefab, this.gameObject.transform.position, this.gameObject.transform.rotation, this.gameObject.transform);
                    prefabs.Add(go);
                    go.name = boatsData.GetName(sortedBoats[i], null);

                }
            }
        }

        //IEnumerator Sort(_page);


        /*int temp = (int)itensPerPage;
        do
        {
            GameObject go = Instantiate(prefab, this.gameObject.transform.position, this.gameObject.transform.rotation, this.gameObject.transform);
            go.GetComponentInChildren<Text>().text = boats[temp].name;
            prefabs.Add(go);
            temp--;

        } while (temp > 0);*/

        PageInfo();
    }

    IEnumerator SpawnEffect()
    {
        yield return new WaitForSeconds(1f);
    }

    public void PreviousPage()
    {

        if (page != 1)
            page--;
        else
            return;

        Spawn(page);

        Debug.Log("page: " + page);
        PageInfo();
    }

    public void NextPage()
    {
        if (page != totalPages)
            page++;
        else
            return;

        Spawn(page);

        Debug.Log("page: " + page);
        PageInfo();
    }

    void PageInfo()
    {
        pageInfoTxt.text = "page " + page + " of " + totalPages;

        foreach (GameObject i in pageIndicatorPrefabs)
        {
            i.GetComponent<Image>().color = Color.white;
        }

        pageIndicatorPrefabs[page - 1].GetComponent<Image>().color = Color.blue;
    }

    public void Refresh()
    {
        SortedBoats();
        CalculatePages();
        PageInfo();
        Spawn(1);

    }
}
