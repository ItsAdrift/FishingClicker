using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    [HideInInspector] public float capacity = 100f;

    public void Start()
    {
        PlayerAttribute att = Player.instance.GetAttribute("bucketCapacity");
        
        capacity = att.value;

        Player.instance.OnAttributeUpdated.AddListener(OnAttributeUpdate);
    }

    public void OnAttributeUpdate(PlayerAttribute attribute)
    {
        if (attribute.attribute.id == "bucketCapacity")
        {
            capacity = attribute.value;
        }
    }

    public void Update()
    {
        text.text = "" + GameManager.instance.fish + "/" + capacity;
    }

}
