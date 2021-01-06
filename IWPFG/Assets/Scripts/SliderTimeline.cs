using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTimeline : MonoBehaviour
{
    public Slider slider;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        slider = (Slider)FindObjectOfType(typeof(Slider));
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
        
    }
}
