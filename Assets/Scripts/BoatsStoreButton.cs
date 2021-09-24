using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatsStoreButton : MonoBehaviour
{
    Button button;
    BoatsValuesContainer data;
    public Image image;
    public GameObject boatInfoWindow;
    public Text boatName;
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
        Debug.Log("Hello World!! " + this.gameObject.name);
        GameObject go = Instantiate(boatInfoWindow, this.gameObject.transform.parent.position, Quaternion.identity, this.gameObject.transform.parent.parent.transform);
        go.GetComponent<BoatInfoWindowManager>().boatName = this.gameObject.name;
    }
}
