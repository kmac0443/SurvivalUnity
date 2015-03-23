using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {
	public Vector3 offset = new Vector3(-32, 48);

	public int fontSize = 14;
	public Color fontColor = Color.black;
	public Color backgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.7f);

	private GameObject text = null;
	private GameObject background = null;

	void Start() {
		gameObject.AddComponent<CanvasRenderer>();
		gameObject.AddComponent<RectTransform>();
		gameObject.AddComponent<ContentSizeFitter>();
	}

	private void placeTooltip() {
		Rect screen = new Rect(0, 0, Screen.width, Screen.height);
		
		Vector3 refPoint = text.GetComponent<RectTransform>().sizeDelta;

		Vector2 newPosition;

		if (screen.Contains(Input.mousePosition + offset + new Vector3(-refPoint.x, refPoint.y))) {
			newPosition = Input.mousePosition + offset;
		}
		else {
			newPosition = Input.mousePosition - offset;
		}

		text.transform.position = newPosition;
		background.transform.position = newPosition;
	}

	void LateUpdate() {
		if (showing()) {
			placeTooltip();
		}
	}

	public bool showing() {
		return text != null || background != null;
	}

	public void display(string msg) {
		if (text != null || background != null) close();

		// set up background
		background = new GameObject("Tooltip background", new System.Type[] {typeof(Image)});
		background.transform.SetParent(this.transform);

		background.GetComponent<Image>().color = backgroundColor;

		// set up text
		text = new GameObject("Toolip text", new System.Type[] {typeof(Text)});
		text.transform.SetParent(this.transform);

		text.GetComponent<Text>().text = msg;
		text.GetComponent<Text>().font = UI.Get.DefaultFont;
		text.GetComponent<Text>().fontSize = fontSize;
		text.GetComponent<Text>().color = fontColor;
		text.GetComponent<Text>().verticalOverflow = VerticalWrapMode.Overflow;
		text.GetComponent<Text>().horizontalOverflow = HorizontalWrapMode.Wrap;
		text.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
		text.GetComponent<Text>().supportRichText = true;

		text.GetComponent<Text>().rectTransform.sizeDelta = new Vector2(100.0f, 1.0f);

		text.transform.SetAsLastSibling();

		// fit the background to the text
		background.GetComponent<RectTransform>().sizeDelta = new Vector2(
			text.GetComponent<RectTransform>().sizeDelta.x,
			text.GetComponent<Text>().preferredHeight
		);

		placeTooltip();
	}

	public void close() {
		Destroy(text);
		text = null;

		Destroy(background);
		background = null;
	}

	void OnDestroy() {
		close();
	}
}
