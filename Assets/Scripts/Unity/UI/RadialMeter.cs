using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RadialMeter : MonoBehaviour {
	public Image healthImage;
	public Image ashImage;

	public float maxFill = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ashImage.fillAmount = (float)Game.Get.Player.vitals.Percent(MeterType.Ash) * maxFill;
		healthImage.fillAmount = (float)Game.Get.Player.vitals.Percent(MeterType.Health) * maxFill;
	}
}

