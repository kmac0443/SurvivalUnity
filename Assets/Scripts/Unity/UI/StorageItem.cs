using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

/**
 * An item that is dragged and dropped between the player's inventory and a container.
 * This is used for both the item itself and for its girth placeholders.
 * The "who" variable is always set to the main object.
 */
public class StorageItem : MonoBehaviour, TooltipMessage, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler, IDropHandler {
	public Color32 placeholderColor = new Color32(100, 100, 100, 255);

	private StorageItem who;

	private Item item = null;
	private Image image;
	private StorageWindow container = null;
	private Text label;

	private List<StorageItem> girth;
	
	void Awake() {
		image = gameObject.GetComponent<Image>();
		girth = new List<StorageItem>();
	}

	private void convertToPlaceholder(StorageItem actual) {
		who = actual;
		image.color = placeholderColor;

		item = actual.item;
		if (item == null) Debug.LogError("ACTUAL ITEM NOT SET!");
		container = actual.container;
		label = null; //Can't do a regular assignment here b/c it's a component
		girth = actual.girth;
	}

	private void createGirthPlaceholders(StorageWindow parent) {
		for (int i = 0; i < item.Girth-1; ++i) {
			StorageItem girthPlaceholder = Instantiate(this);
			girthPlaceholder.convertToPlaceholder(this);
			girthPlaceholder.transform.SetParent(parent.transform);
			girth.Add(girthPlaceholder);
		}
	}

	/*
	 *	Hide the girth placeholder icons.
	 */
	private void hideGirth() {
		foreach (StorageItem item in girth) {
			item.image.color = Color.clear;
		}
	}
	/*
	 *	Show the girth placeholder icons.
	 */
	private void showGirth() {
		foreach (StorageItem item in girth) {
			item.image.color = placeholderColor;
		}
	}

	/*
	 * Initialize this StorageItem. This must be called before the StorageItem is used.
	 * This function will automatically spawn girth placeholders.
	 */
	public void setItem(StorageWindow parent, Item it) {
		container = parent;
		item = it;
		image.sprite = SpriteTable.Get(item.ItemType);

		createGirthPlaceholders(parent);

		who = this;

		GameObject labelObject = new GameObject();
		labelObject.transform.SetParent(who.transform);
		labelObject.transform.position += new Vector3(0, -16);

		label = labelObject.AddComponent<Text>();
		label.text = "";
		label.font = UI.Get.DefaultFont;
		label.horizontalOverflow = HorizontalWrapMode.Overflow;

		labelObject.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, 0);
	}

	public void OnBeginDrag(PointerEventData eventData) {
		UI.Get.closeTooltip();
		UI.Get.holdItem(who);
		who.GetComponent<CanvasGroup>().blocksRaycasts = false;
		hideGirth();

		if (item.Girth > 1) {
			who.label.text = item.Girth.ToString();
		}
	}

	public void OnDrag(PointerEventData eventData) {
		who.image.rectTransform.position = eventData.position;
	}

	/*
	 * When one something is dropped on a storage item, do nothing.
	 * This prevents an item from being dropped on the ground when dropped on another item.
	 */
	public void OnDrop(PointerEventData eventData) {
		UI.Get.refreshAll();
	}

	public void OnEndDrag(PointerEventData eventData) {
		UI.Get.releaseItem();

		container.StorageContainer.RemoveItem(item);

		// drop the item around the player:
		Vector3 offset = Random.onUnitSphere;
		offset.z = 0;
		GroundItem.create(item, Game.Get.PlayerController.transform.position + offset);

		// Or, drop the item where the mouse is:
		//Vector3 position = Camera.main.ScreenToWorldPoint(who.transform.position);
		//position.z = 0;
		//GroundItem.create(item, position);

		Destroy (this);

		UI.Get.refreshAll();
	}

	public void OnPointerClick(PointerEventData eventData) {
		if (eventData.button == PointerEventData.InputButton.Right) {
			if(Game.Get.Player.Inventory.Contains(item.ID)) {
				Game.Get.Player.Inventory.EquipItem(item);
				Debug.Log("Equipped Item");
			}
		}
	}

	public StorageWindow Parent {
		get { return container; }
		set { container = value; }
	}

	public Item Item {
		get { return item; }
	}

	public List<StorageItem> Girth {
		get { return girth; }
	}

	public void displayTooltip() {
		UI.Get.displayTooltip(this.gameObject);
	}

	public void closeTooltip() {
		UI.Get.closeTooltip();
	}

	public string message() {
		return item.Label + "\nGirth: " + item.Girth;
	}
}
