using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class PostProcessing : MonoBehaviour
{
    public Volume myvolume;
    private ColorAdjustments colorAdjustments;
    private VolumeParameter<float> HueShift = new VolumeParameter<float>();

    void Start()
    {

        myvolume.profile.TryGet<ColorAdjustments>(out colorAdjustments);
        HueShift.value = Random.Range(-180f, 180f);
        colorAdjustments.hueShift.SetValue(HueShift);
    }


}
