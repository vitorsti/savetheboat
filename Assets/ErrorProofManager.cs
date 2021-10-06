using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ErrorProofManager : MonoBehaviour
{
    public TextMeshProUGUI txt;
    public Button yes, no;
    private void Awake()
    {
        no.onClick.AddListener(No);
        yes.onClick.AddListener(Yes);
    }

    public void No()
    {
        Destroy(this.gameObject);
    }

    public void Yes()
    {
        Destroy(this.gameObject, 0.1f);
    }
}
