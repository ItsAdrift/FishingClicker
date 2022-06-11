using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SetPostProcessing : MonoBehaviour
{

    public void PostProcessing(bool b)
    {
        GetComponent<UniversalAdditionalCameraData>().renderPostProcessing = b;
    }

}
