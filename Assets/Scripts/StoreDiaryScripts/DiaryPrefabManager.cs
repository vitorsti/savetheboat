using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiaryPrefabManager : MonoBehaviour
{
    BossValuesContainer bossValues;
    EnemiesValuesContainer enemiesValues;
    PowerupValuesContainer powerupValues;
    EventsValuesContainer eventsValues;
    public GameObject mask;
    public Image itenImage;
    public TextMeshProUGUI buttonTxt;
    public TMP_FontAsset normalFont, morseFont;
    public int type;

    public string itemName;

    private void Awake()
    {
        bossValues = Resources.Load<BossValuesContainer>("ScriptableObjects/BossData");
        enemiesValues = Resources.Load<EnemiesValuesContainer>("ScriptableObjects/EnemiesData");
        powerupValues = Resources.Load<PowerupValuesContainer>("ScriptableObjects/PowerupsData");
        eventsValues = Resources.Load<EventsValuesContainer>("ScriptableObjects/EventsData");
    }

    // Start is called before the first frame update
    void Start()
    {

        itemName = this.name;
        //this.gameObject.GetComponentInChildren<Button>().onClick.AddListener(delegate { SetThings(type); });
        SetThings(type);
    }

    // Update is called once per frame
    public void SetThings(int value)
    {
        switch (value)
        {
            case 0:
                {
                    //enemies
                    if (enemiesValues.GetHasfound(0, itemName))
                    {
                        mask.SetActive(false);
                        buttonTxt.font = normalFont;
                    }
                    else
                    {
                        mask.SetActive(true);
                        buttonTxt.font = morseFont;
                    }

                    itenImage.sprite = enemiesValues.GetImage(0, itemName);
                    buttonTxt.text = itemName /*+ "\n" + enemiesValues.GetDescription(0, itemName)*/;

                    break;
                }
            case 1:
                {
                    //boss
                    if (bossValues.GetHasfound(0, itemName))
                    {
                        mask.SetActive(false);
                        buttonTxt.font = normalFont;
                    }
                    else
                    {
                        mask.SetActive(true);
                        buttonTxt.font = morseFont;
                    }

                    itenImage.sprite = bossValues.GetImage(0, itemName);
                    buttonTxt.text = itemName /*+ "\n" + bossValues.GetDescription(0, itemName)*/;
                    break;
                }
            case 2:
                {
                    //powerups
                    if (powerupValues.GetHasfound(0, itemName))
                    {
                        mask.SetActive(false);
                        buttonTxt.font = normalFont;
                    }
                    else
                    {
                        mask.SetActive(true);
                        buttonTxt.font = morseFont;
                    }

                    itenImage.sprite = powerupValues.GetImage(0, itemName);
                    buttonTxt.text = itemName/* + "\n" + powerupValues.GetDescription(0, itemName)*/;
                    break;
                }
            case 3:
                {
                    //events
                     if (eventsValues.GetHasfound(0, itemName))
                    {
                        mask.SetActive(false);
                        buttonTxt.font = normalFont;
                    }
                    else
                    {
                        mask.SetActive(true);
                        buttonTxt.font = morseFont;
                    }

                    itenImage.sprite = eventsValues.GetImage(0, itemName);
                    buttonTxt.text = itemName/* + "\n" + eventsValues.GetDescription(0, itemName)*/;
                    break;
                }
        }
    }

    public void SetType(int value)
    {
        type = value;
    }
}
