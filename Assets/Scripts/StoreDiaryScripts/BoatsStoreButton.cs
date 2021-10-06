using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoatsStoreButton : MonoBehaviour
{
    public Button button;
    BoatsValuesContainer data;
    public Image image;
    public GameObject boatInfoWindow;
    public TextMeshProUGUI boatName;
    public Color bougthColor, selectedColor, notBougth;
    private void Awake()
    {
        data = Resources.Load<BoatsValuesContainer>("ScriptableObjects/BoatsData");
        button = GetComponent<Button>();

    }

    private void Start()
    {

        image.sprite = data.GetImage(0, this.gameObject.name);
        button.onClick.AddListener(SpawnBoatInfoWindow);
        boatName.text = this.gameObject.name;
        if (data.GetSelected(0, this.gameObject.name) && data.GetBougth(0, this.gameObject.name))
        {
            ColorBlock colors = button.colors;
            colors.normalColor = selectedColor;
            button.colors = colors;
        }

        if (!data.GetSelected(0, this.gameObject.name) && data.GetBougth(0, this.gameObject.name))
        {
            ColorBlock colors = button.colors;
            colors.normalColor = bougthColor;
            button.colors = colors;
        }

        if (!data.GetSelected(0, this.gameObject.name) && !data.GetBougth(0, this.gameObject.name))
        {
            ColorBlock colors = button.colors;
            colors.normalColor = notBougth;
            button.colors = colors;
        }

    }

    public void SpawnBoatInfoWindow()
    {
        GameObject parent = GameObject.FindWithTag("Store"); 
        Debug.Log("Hello World!! " + this.gameObject.name);
        GameObject go = Instantiate(boatInfoWindow, parent.transform.position, Quaternion.identity, parent.transform);
        go.GetComponent<BoatInfoWindowManager>().boatName = this.gameObject.name;
    }
}
