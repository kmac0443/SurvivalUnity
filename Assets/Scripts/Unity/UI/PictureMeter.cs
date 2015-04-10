using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class PictureMeter : MonoBehaviour {
	public int numberOfImages;
	public Sprite image;
	public MeterType meter;

	Image[] images = null;

	// Recolor the images every frame, just because we can
	void Update () {
		double percent = Game.Get.Player.vitals.Percent(meter);

		double filledImages = percent * numberOfImages;
		int fullImages = (int)filledImages;

		float percentLast = (float)filledImages - fullImages;

		// fill the filled images
		for (int i = 0; i < fullImages; ++i) {
			images[i].color = Color.white;
		}

		// partially gray the partially filled
		if (fullImages < numberOfImages) {
			images[fullImages].color = new Color(percentLast, percentLast, percentLast);

			for (int i = fullImages+1; i < numberOfImages; ++i) {
				images[i].color = Color.black;
			}
		}
	}

	Image makeImage(int i) {
		GameObject obj = new GameObject(gameObject.name + " " + i, new System.Type[]{typeof(Image)});
		obj.transform.SetParent(this.transform);
		obj.GetComponent<Image>().sprite = image;

		return obj.GetComponent<Image>();
	}

	void Start () {
		images = new Image[numberOfImages];

		for (int i = 0; i < numberOfImages; ++i) {
			images[i] = makeImage(i);
		}
	}
}
