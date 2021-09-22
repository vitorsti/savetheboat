using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ContentPageManager : MonoBehaviour
{
    [Header(" --- the array below is an representation of the scriptableObject holding the boats --- ")]
    public List<GameObject> boats;
    public bool getAllBoats, resetBoats, sort;
    public BoatsValuesContainer boatsData;
    [Header("-------------------------------------------------------------------------------")]
    public List<GameObject> prefabs;
    public GameObject prefab;
    public Text pageInfoTxt;

    [SerializeField]
    private float itensPerPage;
    [SerializeField]
    private float totalPages;
    [SerializeField]
    private int page;
    int index;

    // Start is called before the first frame update
    private void OnValidate()
    {
        if (getAllBoats)
        {
            boats = Resources.LoadAll<GameObject>("boats").ToList();
            getAllBoats = false;

        }

        if (resetBoats)
        {
            boats.Clear();
            resetBoats = false;
        }
    }

    private void Awake()
    {
        boatsData = Resources.Load<BoatsValuesContainer>("ScriptableObjects/BoatsData");
    }

    private void Start()
    {
        CalculatePages();
        PageTxt();


    }

    public void CalculatePages()
    {
        if (boatsData.boatsDatas.Length % itensPerPage == 0)
        {
            Debug.Log("integer");
            float div = boatsData.boatsDatas.Length / itensPerPage;
            totalPages = div;
        }
        else
        {
            Debug.Log("not integer");
            float div = boatsData.boatsDatas.Length / itensPerPage;
            totalPages = (int)div + 1;
        }

        page = 1;
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

            for (int i = 0; i < boatsData.boatsDatas.Length /*boats.Count*/; i++)
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

            for (int i = (index + 1) - ((int)itensPerPage); i < index + 1; i++)
            {
                GameObject go = Instantiate(prefab, this.gameObject.transform.position, this.gameObject.transform.rotation, this.gameObject.transform);
                prefabs.Add(go);
                go.name = boatsData.GetName(i, null);
                go.GetComponentInChildren<Text>().text = boatsData.GetName(i, null);
            }
        }
        else
        {
            for (int i = index + 1; i < boatsData.boatsDatas.Length; i++)
            {
                GameObject go = Instantiate(prefab, this.gameObject.transform.position, this.gameObject.transform.rotation, this.gameObject.transform);
                prefabs.Add(go);
                go.name = boatsData.GetName(i, null);
                go.GetComponentInChildren<Text>().text = boatsData.GetName(i, null);
            }
        }


        /*int temp = (int)itensPerPage;
        do
        {
            GameObject go = Instantiate(prefab, this.gameObject.transform.position, this.gameObject.transform.rotation, this.gameObject.transform);
            go.GetComponentInChildren<Text>().text = boats[temp].name;
            prefabs.Add(go);
            temp--;

        } while (temp > 0);*/
    }

    public void PreviousPage()
    {
        if (page != 1)
        {
            page--;

        }
        Spawn(page);

        Debug.Log("page: " + page);
        PageTxt();
    }

    public void NextPage()
    {
        if (page != totalPages)
        {
            page++;

        }

        Spawn(page);

        Debug.Log("page: " + page);
        PageTxt();
    }

    void PageTxt()
    {
        pageInfoTxt.text = page + " / " + totalPages;
    }
}
