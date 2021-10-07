using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BossEnemiesInfoWindowManager : MonoBehaviour
{
    BossValuesContainer bossValues;
    EnemiesValuesContainer enemiesValues;
    public TMP_FontAsset normalFont, morseFont;
    public TextMeshProUGUI nameTxt;
    public TextMeshProUGUI descriptionTxt;
    public TextMeshProUGUI rewardTxt;
    public Image itenImage;
    public GameObject mask;
    int type;
    string itemName;

    private void Awake()
    {
        bossValues = Resources.Load<BossValuesContainer>("ScriptableObjects/BossData");
        enemiesValues = Resources.Load<EnemiesValuesContainer>("ScriptableObjects/EnemiesData");

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
        if (type == 0)
        {
            found = enemiesValues.GetHasfound(0, itemName);
            Debug.Log(found);
            if (found)
            {
                mask.SetActive(false);
                nameTxt.font = normalFont;
                descriptionTxt.font = normalFont;
                rewardTxt.font = normalFont;
            }
            else
            {
                mask.SetActive(true);
                nameTxt.font = morseFont;
                descriptionTxt.font = morseFont;
                rewardTxt.font = morseFont;
            }
            itenImage.sprite = enemiesValues.GetImage(0, itemName);
            nameTxt.text = itemName;
            descriptionTxt.text = enemiesValues.GetDescription(0, itemName);
            rewardTxt.text = "Reward: 999.999";

        }
        if (type == 1)
        {
            found = bossValues.GetHasfound(0, itemName);
            Debug.Log(found);
            if (found)
            {
                mask.SetActive(false);
                nameTxt.font = normalFont;
                descriptionTxt.font = normalFont;
                rewardTxt.font = normalFont;
            }
            else
            {
                mask.SetActive(true);
                nameTxt.font = morseFont;
                descriptionTxt.font = morseFont;
                rewardTxt.font = morseFont;
            }
            itenImage.sprite = bossValues.GetImage(0, itemName);
            nameTxt.text = itemName;
            descriptionTxt.text = bossValues.GetDescription(0, itemName);
            rewardTxt.text = "Reward: 999.999";
        }
    }

    public void SetType(int _type)
    {
        Debug.Log("passou aqui");
        type = _type;
    }

    public void SetName(string _name){
        itemName = _name;
    }

    public void Close()
    {
        Destroy(this.gameObject);
    }
}
