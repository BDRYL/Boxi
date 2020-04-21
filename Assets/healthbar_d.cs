using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healthbar_d : MonoBehaviour {
	public Slider slider_d;
	// Use this for initialization

	public void SetMaxHealth (int health_d){
		slider_d.maxValue = health_d;
		slider_d.value = health_d;
	}
	public void SetHealth(int health_d){
		slider_d.value = health_d;
	}
}
