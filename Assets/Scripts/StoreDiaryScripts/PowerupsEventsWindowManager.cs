using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerupsEventsWindowManager : MonoBehaviour
{
    PowerupValuesContainer powerupValues;
    EventsValuesContainer eventsValues;
    public TMP_FontAsset normalFont, morseFont;
    public TextMeshProUGUI nameTxt;
    public TextMeshProUGUI descriptionTxt;
    public Image itenImage;
    public GameObject mask;
    int type;
    string itemName;

    private void Awake()
    {
        powerupValues = Resources.Load<PowerupValuesContainer>("ScriptableObjects/PowerupsData");
        eventsValues = Resources.Load<EventsValuesContainer>("ScriptableObjects/EventsData");

        //itemName = this.name;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetThings();
    }

    public void SetThings()
    {
        bool found;
        if (type == 2)
        {
            found = powerupValues.GetHasfound(0, itemName);
            Debug.Log(found);
            if (found)
            {
                mask.SetActive(false);
                nameTxt.font = normalFont;
                descriptionTxt.font = normalFont;
                //.font = normalFont;
            }
            else
            {
                mask.SetActive(true);
                nameTxt.font = morseFont;
                descriptionTxt.font = morseFont;
                //.font = morseFont;
            }
            itenImage.sprite = powerupValues.GetImage(0, itemName);
            nameTxt.text = itemName;
            descriptionTxt.text = powerupValues.GetDescription(0, itemName) + "\n Duration: " + powerupValues.GetDuration(0, itemName) + "s";
            //.text = "Reward: 999.999";

        }
        if (type == 3)
        {
            found = eventsValues.GetHasfound(0, itemName);
            Debug.Log(found);
            if (found)
            {
                mask.SetActive(false);
                nameTxt.font = normalFont;
                descriptionTxt.font = normalFont;

            }
            else
            {
                mask.SetActive(true);
                nameTxt.font = morseFont;
                descriptionTxt.font = morseFont;

            }

            itenImage.sprite = eventsValues.GetImage(0, itemName);
            nameTxt.text = itemName;
            descriptionTxt.text = eventsValues.GetDescription(0, itemName) + "\n Duration: " + eventsValues.GetDuration(0, itemName) + "s";

        }
    }

    public void SetType(int _type)
    {
        Debug.Log("passou aqui");
        type = _type;
    }

    public void SetName(string _name)
    {
        itemName = _name;
    }

    public void Close()
    {
        Destroy(this.gameObject);
    }
}
