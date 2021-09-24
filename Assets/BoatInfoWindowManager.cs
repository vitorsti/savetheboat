using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatInfoWindowManager : MonoBehaviour
{
    BoatsValuesContainer data;
    public Button closeBttun;
    public Button buySelectBttun;
    public string boatName;

    private void Awake()
    {
        closeBttun.onClick.AddListener(Close);
        Debug.Log(boatName);
    }

    public void SetThings(){
        
    }

    public void Buy()
    {
        Debug.Log("boat selected");
    }

    public void Select()
    {
        Debug.Log("boat selected");
    }

    public void Close()
    {

        Destroy(this.gameObject);
    }
}
