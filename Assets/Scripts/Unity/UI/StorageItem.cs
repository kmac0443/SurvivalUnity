using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StorageItem : MonoBehaviour {
	private Item item = null;
	private Image image;

	void Awake() {
		image = gameObject.GetComponent<Image>();
	}

	public void setItem(Item it) {
		item = it;
		image.sprite = SpriteTable.Get("Items/Items.png").getSprite(item.ItemType);
	}

	public void Drag() {
		image.rectTransform.position = Input.mousePosition;
	}
}
