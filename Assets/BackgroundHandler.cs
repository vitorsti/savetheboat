using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundHandler : MonoBehaviour
{
    public GameObject lastWave;
    [SerializeField] Color waveCustomColor;
    public bool usingWaveCustomColor;

    public GameObject skyBG;
    [SerializeField] Color skyCustomColor;
    Color skyOriginalColor;
    public bool usingSkyCustomColor;

    //public Color color;
    public static BackgroundHandler Singleton;

    private void Awake()
    {
        Singleton = this;
        skyOriginalColor = skyBG.GetComponent<SpriteRenderer>().color;
    }

    public IEnumerator ChangeWaveColor()
    {
        while (usingWaveCustomColor)
        {
            yield return new WaitForSeconds(1.5f);
            SpriteRenderer[] renders = lastWave.gameObject.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer sprite in renders)
            {
                Color color;
                float a = sprite.color.a;
                color = waveCustomColor;
                color.a = a;
                sprite.color = color;
            }
        }
    }

    public IEnumerator ChangeSkyColor()
    {
        while (usingSkyCustomColor)
        {
            yield return new WaitForSeconds(1.5f);         

        }
    }

    public void ToogleWaveCustomColor(bool toogle)
    {
        usingWaveCustomColor = toogle;

        if (usingWaveCustomColor)
            StartCoroutine(ChangeWaveColor());
        else
            StopAllCoroutines();
    }

    public void ToogleSkyCustomColor(bool toogle)
    {
        usingSkyCustomColor = toogle;

        if (usingSkyCustomColor)
        {
            Color color;
            float a = skyBG.GetComponent<SpriteRenderer>().color.a;
            color = skyCustomColor;
            color.a = a;
            skyBG.GetComponent<SpriteRenderer>().color = color;
        }
        else
        {
            skyBG.GetComponent<SpriteRenderer>().color = skyOriginalColor;
        }
    }

    public void ChangeWaveCustomColor(Color newColor)
    {
        waveCustomColor = newColor;
    }

    public void ChangeSkyCustomColor(Color newColor)
    {
        skyCustomColor = newColor;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            usingWaveCustomColor = true;
            StartCoroutine(ChangeWaveColor());
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            usingWaveCustomColor = false;
            StopAllCoroutines();
        }
    }
}
