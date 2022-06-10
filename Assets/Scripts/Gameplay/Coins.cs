using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    void Update()
    {
        text.text = "$" + GameManager.instance.coins;
    }
}
