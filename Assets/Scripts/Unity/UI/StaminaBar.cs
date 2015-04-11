using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StaminaBar : MonoBehaviour {
	public GameObject emptyBar;
	public Sprite filledBarSprite;

	public float minPercent = 0.0f;
	public float maxPercent = 1.0f;

	Image filledBar = null;

	// Use this for initialization
	void Start () {
		GameObject filledObject = Instantiate(emptyBar, emptyBar.transform.position, emptyBar.transform.rotation) as GameObject;
		filledObject.name = "Filled Stamina Bar";
		filledObject.transform.SetParent(this.transform);
		filledBar = filledObject.GetComponent<Image>();

		filledBar.sprite = filledBarSprite;
		filledBar.type = Image.Type.Filled;
		filledBar.fillMethod = Image.FillMethod.Horizontal;
		filledBar.GetComponent<RectTransform>().SetAsLastSibling(); // guarantee it's in front
	}
	
	// Update is called once per frame
	void Update () {
		float percent = (float)(Game.Get.Player.vitals.Percent(MeterType.Stamina) * (maxPercent - minPercent)) + minPercent;

		filledBar.fillAmount = percent;
	}
}
