using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesColor : BgSpawn
{
    //[SerializeField] Color customColor;

    ////public IEnumerator ChangeColor()
    ////{
    ////    while (usingCustomColor)
    ////    {
    ////        yield return new WaitForSeconds(1);

    ////        SpriteRenderer[] renders = lastSpawned.gameObject.GetComponentsInChildren<SpriteRenderer>();

    ////        foreach(SpriteRenderer sprite in renders)
    ////        {
    ////            Color color;
    ////            float a = sprite.color.a;
    ////            color = customColor;
    ////            color.a = a;

    ////            sprite.color = color;
    ////        }
    ////    }
    ////}

    //public void ChangeColor()
    //{
    //    usingCustomColor = true;
    //    SpriteRenderer[] renders = lastSpawned.gameObject.GetComponentsInChildren<SpriteRenderer>();

    //    foreach (SpriteRenderer sprite in renders)
    //    {
    //        Color color;
    //        float a = sprite.color.a;
    //        color = customColor;
    //        color.a = a;

    //        sprite.color = color;
    //    }
    //}

    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    //if (Input.GetKeyDown(KeyCode.T))
    //    //    GameObject.FindObjectOfType<WavesColor>().ChangeColor();
    //}
}
