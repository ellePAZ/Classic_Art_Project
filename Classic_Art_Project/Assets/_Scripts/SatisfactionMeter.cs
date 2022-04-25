using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SatisfactionMeter : MonoBehaviour
{
    [SerializeField] int minSatisfactionValue = 40;
    [SerializeField] int maxSatisfactionValue = 70;
    [SerializeField] float decreaseRate = 2;
    [SerializeField] float increaseRate = 2;
    [SerializeField] Slider slider;

    float currentSatisfactionValue = 0;
    bool maxValue = false;

    // Start is called before the first frame update
    void Start()
    {
        currentSatisfactionValue = Random.Range(minSatisfactionValue, maxSatisfactionValue);
        UpdateSlider();
    }

    // Update is called once per frame
    void Update()
    {
        if(!maxValue)
        {
            DecreaseValue();
		}
    }

    void DecreaseValue(){
        currentSatisfactionValue -= Time.deltaTime * decreaseRate;
        if(currentSatisfactionValue < 0)
        {
            currentSatisfactionValue = 0;
		}

        UpdateSlider();
	}

    public void IncreaseValue()
    {
        if(maxValue){ return; }

        currentSatisfactionValue += Time.deltaTime * (increaseRate + decreaseRate);
        if(currentSatisfactionValue >= 100)
        {
            maxValue = true;
		}

        UpdateSlider();
	}

    void UpdateSlider()
    {
        slider.value = currentSatisfactionValue;
	}

	private void OnMouseOver()
	{
        IncreaseValue();
	}
}
