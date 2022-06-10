using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public static Player instance;

    public UnityEvent<PlayerAttribute> OnAttributeUpdated;

    private void Awake()
    {
        instance = this;
    }

    public List<PlayerAttribute> attributes = new List<PlayerAttribute>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            OnAttributeUpdated.Invoke(attributes[0]);
        }
    }

    public PlayerAttribute GetAttribute(string s)
    {
        for (int i = 0; i < attributes.Count; i++)
        {

            if (attributes[i].attribute.id == s)
                return attributes[i];
        }

        Debug.LogWarning("Unable to find Attribute: " + s);
        return new PlayerAttribute(null, 0f);
    }
}

