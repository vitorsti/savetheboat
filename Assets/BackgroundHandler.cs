using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundHandler : MonoBehaviour
{
    float lerpSpeed = 0.1f; 

    [Header("Ocean")]
    [SerializeField] Color waveCustomColor;
    public bool changingWaveCustomColor;
    Color waveOriginalColor;

    public GameObject lastWave;
    [SerializeField] Color reflectionOriginalColor;
    [SerializeField] Color underwaterOriginalColor;
    [SerializeField] Color panelOriginalColor;
    public string wavesName;

    [Header("Surface")]
    public GameObject horizonLine;
    [SerializeField] Color horizonLineColor;

    public GameObject oceanSurface;
    [SerializeField] Color oceanSurfaceColor;

    public GameObject boatWaves;
    [SerializeField] Color boatWavesColor;

    public GameObject oceanReflections;
    [SerializeField] Color oceanReflectionsColor;

    [Header("Sky")]
    public GameObject skyBG;
    [SerializeField] Color skyCustomColor;
    Color skyOriginalColor;
    public bool changingSkyCustomColor;

    //public Color color;
    public static BackgroundHandler Singleton;

    private void Awake()
    {
        Singleton = this;

        skyOriginalColor = skyBG.GetComponent<SpriteRenderer>().color;
        horizonLineColor = horizonLine.GetComponent<SpriteRenderer>().color;
        oceanSurfaceColor = oceanSurface.GetComponent<SpriteRenderer>().color;
        boatWavesColor = boatWaves.GetComponent<SpriteRenderer>().color;
        oceanReflectionsColor = oceanReflections.GetComponent<SpriteRenderer>().color;

        SpriteRenderer[] renders = lastWave.gameObject.GetComponentsInChildren<SpriteRenderer>();

        foreach (SpriteRenderer sprite in renders)
        {
            if (sprite.gameObject.name == (wavesName + "Reflection"))
                reflectionOriginalColor = sprite.color;

            else if (sprite.gameObject.name == (wavesName + "UnderWater"))
                underwaterOriginalColor = sprite.color;

            else if (sprite.gameObject.name == (wavesName + "Panel"))
                panelOriginalColor = sprite.color;
        }
    }

    public IEnumerator ChangeWaveColor(Color change, bool customColor)
    {
        //float timer = _timer;
        changingWaveCustomColor = true;

        while (changingWaveCustomColor)
        {
            //timer -= 0.01f;
            //if (timer <= 0 && )
            //    changingWaveCustomColor = false;

            SpriteRenderer[] renders = lastWave.gameObject.GetComponentsInChildren<SpriteRenderer>();

            Debug.Log("change to custom ");

            foreach (SpriteRenderer sprite in renders)
            {
                float a = sprite.color.a;
                change.a = a;
                sprite.color = Color.Lerp(sprite.color, change, lerpSpeed);
            }

            horizonLine.GetComponent<SpriteRenderer>().color = Color.Lerp(horizonLine.GetComponent<SpriteRenderer>().color, change, lerpSpeed);
            oceanSurface.GetComponent<SpriteRenderer>().color = Color.Lerp(oceanSurface.GetComponent<SpriteRenderer>().color, change, lerpSpeed);
            boatWaves.GetComponent<SpriteRenderer>().color = Color.Lerp(boatWaves.GetComponent<SpriteRenderer>().color, change, lerpSpeed);
            oceanReflections.GetComponent<SpriteRenderer>().color = Color.Lerp(oceanReflections.GetComponent<SpriteRenderer>().color, change, lerpSpeed);

            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator ChangeWaveColorOriginal()
    {
        changingWaveCustomColor = true;

        while (changingWaveCustomColor)
        {
            SpriteRenderer[] renders = lastWave.gameObject.GetComponentsInChildren<SpriteRenderer>();

            foreach (SpriteRenderer sprite in renders)
            {
                //float a = sprite.color.a;
                //change.a = a;
                //sprite.color = Color.Lerp(sprite.color, change, lerpSpeed);

                if (sprite.gameObject.name == (wavesName + "Reflection"))
                    sprite.color = Color.Lerp(sprite.color, reflectionOriginalColor, lerpSpeed);

                else if (sprite.gameObject.name == (wavesName + "UnderWater"))
                    sprite.color = Color.Lerp(sprite.color, underwaterOriginalColor, lerpSpeed);

                else if (sprite.gameObject.name == (wavesName + "Panel"))
                    sprite.color = Color.Lerp(sprite.color, panelOriginalColor, lerpSpeed);
            }

            horizonLine.GetComponent<SpriteRenderer>().color = Color.Lerp(horizonLine.GetComponent<SpriteRenderer>().color, horizonLineColor, lerpSpeed);
            oceanSurface.GetComponent<SpriteRenderer>().color = Color.Lerp(oceanSurface.GetComponent<SpriteRenderer>().color, oceanSurfaceColor, lerpSpeed);
            boatWaves.GetComponent<SpriteRenderer>().color = Color.Lerp(boatWaves.GetComponent<SpriteRenderer>().color, boatWavesColor, lerpSpeed);
            oceanReflections.GetComponent<SpriteRenderer>().color = Color.Lerp(oceanReflections.GetComponent<SpriteRenderer>().color, oceanReflectionsColor, lerpSpeed);

            if (oceanSurface.GetComponent<SpriteRenderer>().color == oceanSurfaceColor)
                changingWaveCustomColor = false;

            yield return new WaitForSeconds(0.1f);
        }
    }

    Coroutine lastWaveRoutine;

    public void ToogleWaveCustomColor(bool toogle)
    {
        if(lastWaveRoutine != null)
            StopCoroutine(lastWaveRoutine);

        //if (changingWaveCustomColor)
        //{
        //    Debug.Log("stop all");
        //    //StopAllCoroutines();
        //    StopCoroutine(lastWaveRoutine);
        //    changingWaveCustomColor = false;
        //}


        if (toogle)
        {
            Debug.Log("tog" + toogle);
            lastWaveRoutine = StartCoroutine(ChangeWaveColor(waveCustomColor, true));
        }
        else
        {
            Debug.Log("tog false" + toogle);
            //lastWaveRoutine = StartCoroutine(ChangeWaveColorOriginal());

            Invoke("TestOriginal", 0.3f);
        }
    }

    void TestOriginal()
    {
        lastWaveRoutine = StartCoroutine(ChangeWaveColorOriginal());
    }

    public IEnumerator ChangeSkyColor(Color change, bool customColor)
    {
        while (changingSkyCustomColor)
        {
            yield return new WaitForSeconds(0.05f);

            if (customColor)
            {
                skyBG.GetComponent<SpriteRenderer>().color = Color.Lerp(skyBG.GetComponent<SpriteRenderer>().color, change, lerpSpeed);
            }
            else
            {
                skyBG.GetComponent<SpriteRenderer>().color = Color.Lerp(skyBG.GetComponent<SpriteRenderer>().color, skyOriginalColor, lerpSpeed);
            }
        }
    }

    public void ToogleSkyCustomColor(bool toogle)
    {
        if (changingSkyCustomColor)
        {
            StopAllCoroutines();
            changingSkyCustomColor = false;
        }

        changingSkyCustomColor = true;

        if (toogle)
            StartCoroutine(ChangeSkyColor(skyCustomColor, true));
        
        else
            StartCoroutine(ChangeSkyColor(skyOriginalColor, false));       
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
            changingWaveCustomColor = true;
            //StartCoroutine(ChangeWaveColor());
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            changingWaveCustomColor = false;
            StopAllCoroutines();
        }
    }
}
