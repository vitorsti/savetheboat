using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int health, totalHealth;
    public GameObject content, healthTile, healthExample;
    public Image healthBar;
    public Sprite firstFull, firstEmpty, full, empty, lastFull, lastEmpty;
    public List<Image> healthBarSprites = new List<Image>();

    // Start is called before the first frame update
    void Awake()
    {
        if (healthExample.activeInHierarchy == true)
            Destroy(healthExample);
    }
    void Start()
    {
        //healthBar = GetComponent<Image>();
        //health = healthBarSprites.Length - 1;
        content = this.gameObject;
        health = totalHealth;
        //SetHealth();
        InstantiateHearts();
        SetHealth(true);
        //healthBarSprites = content.GetComponentsInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.KeypadMinus) /*|| Input.GetKey(KeyCode.KeypadMinus)*/)
            RemoveHealth();

        if (Input.GetKeyDown(KeyCode.KeypadPlus) /*|| Input.GetKey(KeyCode.KeypadPlus)*/)
            AddHealth();

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
            AddHeart();
#endif
    }

    public void SetHealth(bool increaseOrDecrease)
    {
        /*if (health <= 0)
            health = 0;

        if (health >= healthBarSprites.Length - 1)
            health = healthBarSprites.Length - 1;

        healthBar.sprite = healthBarSprites[health];*/

        if (increaseOrDecrease)
        {
            //se for true, vai aumentar a vida

            foreach (Image i in healthBarSprites.GetRange(0, health))
            {
                i.sprite = full;
            }

        }
        if (!increaseOrDecrease)
        {

            //se for false, vai diminuir a vida
            int range = healthBarSprites.Count - health;
            foreach (Image i in healthBarSprites.GetRange(health, range))
            {
                i.sprite = empty;
            }

        }

        if (health == totalHealth)
        {
            healthBarSprites[healthBarSprites.Count - 1].sprite = lastFull;

        }
        else
            healthBarSprites[healthBarSprites.Count - 1].sprite = lastEmpty;

        if (health == 0)
        {
            healthBarSprites[0].sprite = firstEmpty;
        }
        else
            healthBarSprites[0].sprite = firstFull;


    }

    public void InstantiateHearts()
    {
        int temp = totalHealth;
        do
        {
            GameObject go = Instantiate(healthTile, content.transform.position, content.transform.rotation, content.transform);
            healthBarSprites.Add(go.GetComponent<Image>());
            temp--;

        } while (temp > 0);

        if (healthBarSprites.Count > totalHealth)
            totalHealth = healthBarSprites.Count;
    }

    public void AddHeart()
    {
        GameObject go = Instantiate(healthTile, content.transform.position, content.transform.rotation, content.transform);
        healthBarSprites.Add(go.GetComponent<Image>());
        if (healthBarSprites.Count > totalHealth)
            totalHealth = healthBarSprites.Count;
        SetHealth(true);
        SetHealth(false);
    }

    public static void AddHealth()
    {
        HealthManager healthManager = FindObjectOfType<HealthManager>();
        healthManager.health++;
        if (healthManager.health > healthManager.totalHealth) { healthManager.health = healthManager.totalHealth; return; }
        healthManager.SetHealth(true);

    }

    public static void RemoveHealth()
    {

        HealthManager healthManager = FindObjectOfType<HealthManager>();
        healthManager.health--;
        if (healthManager.health < 0) { healthManager.health = 0; return; }
        healthManager.SetHealth(false);

    }
}
