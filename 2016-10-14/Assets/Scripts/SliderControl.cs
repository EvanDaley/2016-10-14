using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour {

	public SliderType sliderType;
	public Slider slider;
	public PlayerHealth playerHealth;

	void Update () 
	{
		if (sliderType == SliderType.health)
		{
			slider.value = playerHealth.HealthNormalized;
		}
	}
}

public enum SliderType
{
	health,
	shields,
	mana
}