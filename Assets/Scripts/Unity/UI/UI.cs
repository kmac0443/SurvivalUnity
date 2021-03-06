﻿using UnityEngine;
using System.Collections;

/*
 * Keep the window objects for the UI here.
 */
public class UI {
	private static UI instance = null;

	private UI(StorageWindow inventory, StorageWindow container) {
		inventoryWindow = inventory;
		storageWindow = container;

		// this canvas renders on top of any other canvases
		foregroundCanvas = new GameObject("Foreground Canvas", new System.Type[]{typeof(Canvas)});
		foregroundCanvas.GetComponent<Canvas>().sortingOrder = 32767;
		foregroundCanvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
		Object.DontDestroyOnLoad(foregroundCanvas);

		// add a tooltip object to the foreground canvas
		GameObject tooltipObject = new GameObject("Tooltip");
		tooltip = tooltipObject.AddComponent<Tooltip>();
		Object.DontDestroyOnLoad(tooltipObject);

		tooltipObject.transform.SetParent(foregroundCanvas.transform);

		// set up the default font
		//DefaultFont = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		DefaultFont = Resources.Load<Font>("Garamond");
	}
	
	private StorageWindow inventoryWindow;
	private StorageWindow storageWindow;
	private Tooltip tooltip;

	private StorageItem currentItem = null;
	private GameObject foregroundCanvas;

	public Font DefaultFont { get; private set; }

	public static void initialize(StorageWindow inventory, StorageWindow container) {
		// never reinitialize
		if (instance == null) {
			instance = new UI(inventory, container);
		}
	}

	public static UI Get {
		get { 
			if (instance == null) throw new System.Exception("You failed to initialize the UIManager!");

			return instance;
		}
	}

	/*
	 * Display a tooltip unless an item is being held.
	 */
	public void displayTooltip(GameObject obj) {
		if (!holdingItem()) {
			tooltip.displayTooltip(obj);
		}
	}
	int i = 0;
	public Tooltip makeSpeechBubble() {
		GameObject bubbleObject = new GameObject("Speech Bubble");
		bubbleObject.transform.SetParent(foregroundCanvas.transform);

		Tooltip tooltip = bubbleObject.AddComponent<Tooltip>();
		tooltip.offset = new Vector3(-48, 48);

		return tooltip;
	}

	public void closeTooltip() {
		tooltip.close();
	}

	public void closeAll() {
		inventoryWindow.close();
		storageWindow.close();
		closeTooltip();
	}

	public void refreshAll() {
		inventoryWindow.refresh();
		storageWindow.refresh();
	}

	public StorageWindow Inventory {
		get { return inventoryWindow; }
	}

	public StorageWindow Storage {
		get { return storageWindow; }
	}

	public void holdItem(StorageItem item) {
		currentItem = item;
		item.transform.SetParent(foregroundCanvas.transform);
	}

	public void releaseItem() {
		if (currentItem == null) Debug.LogError("Tried to release a held item, but none was being held!");

		currentItem = null;
	}

	public bool holdingItem() {
		return currentItem != null;
	}

	public StorageItem HeldItem {
		get { return currentItem; }
	}

	public bool modalShowing() {
		return inventoryWindow.isShowing() || storageWindow.isShowing();
	}
}
