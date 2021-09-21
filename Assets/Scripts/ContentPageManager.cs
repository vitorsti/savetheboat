using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ContentPageManager : MonoBehaviour
{
    [Header(" --- the array below is an representation of the scriptableObject holding the boats --- ")]
    public List<GameObject> boats; public bool getAllBoats, resetBoats, sort;
    [Header("-------------------------------------------------------------------------------")]
    public List<GameObject> prefabs;
    public GameObject prefab;
    public Text pageInfoTxt;
    public float itensPerPage;
    public float totalPages;
    public int page;
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
        if (boats.Count % itensPerPage == 0)
        {
            Debug.Log("integer");
            float div = boats.Count / itensPerPage;
            totalPages = div;
        }
        else
        {
            Debug.Log("not integer");
            float div = boats.Count / itensPerPage;
            totalPages = (int)div + 1;
        }

        page = 1;
        PageTxt();
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

            for (int i = 0; i < boats.Count; i++)
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
                go.GetComponentInChildren<Text>().text = boats[i].name;
            }
        }
        else
        {
            for (int i = index + 1; i < boats.Count; i++)
            {
                GameObject go = Instantiate(prefab, this.gameObject.transform.position, this.gameObject.transform.rotation, this.gameObject.transform);
                prefabs.Add(go);
                go.GetComponentInChildren<Text>().text = boats[i].name;
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
