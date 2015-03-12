using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

/**
 * An item that is dragged and dropped between the player's inventory and a container.
 */
public class StorageItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	private Item item = null;
	private Image image;
	private StorageWindow container = null;

	void Awake() {
		image = gameObject.GetComponent<Image>();
	}

	public void setItem(StorageWindow parent, Item it) {
		container = parent;
		item = it;
		image.sprite = SpriteTable.Get(item.ItemType);
	}

	public void OnBeginDrag(PointerEventData eventData) {
		UI.Get.HeldItem = this;
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData) {
		image.rectTransform.position = eventData.position;
	}

	public void OnEndDrag(PointerEventData eventData) {
		UI.Get.HeldItem = null;
		GetComponent<CanvasGroup>().blocksRaycasts = true;
		UI.Get.refreshAll();
	}

	public StorageWindow Parent {
		get { return container; }
		set { container = value; }
	}

	public Item Item {
		get { return item; }
	}
}
