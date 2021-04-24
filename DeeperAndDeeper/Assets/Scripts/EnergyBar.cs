using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider slider;
    private float energyValue;
    public float waitTime = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value -= (1.0f / 40f) * Time.deltaTime;
        setEnergyLevels();
        if (slider.value<=0){
            Debug.Log("gameover");
        }
    }
    void setEnergyLevels (){
        // slider.value = energyValue;
    }
}
