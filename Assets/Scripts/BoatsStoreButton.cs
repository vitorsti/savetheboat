using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatsStoreButton : MonoBehaviour
{
    public BoatsValuesContainer data;
    public Image image;
    private void Awake()
    {
        data = Resources.Load<BoatsValuesContainer>("ScriptableObjects/BoatsData");

    }

    private void Start()
    {
        image.sprite = data.GetImage(0, this.gameObject.name);
    }
}
