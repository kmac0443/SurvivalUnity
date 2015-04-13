using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {
	public Vector3 offset = new Vector3(-32, 32);

	public int fontSize = 14;
	public Color fontColor = Color.black;
	public Color backgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.7f);

	private GameObject text = null;
	private GameObject background = null;
	private Coroutine fadeRoutine = null;

	private GameObject followObject = null;


	void Start() {
		gameObject.AddComponent<CanvasRenderer>();
		gameObject.AddComponent<RectTransform>();
		gameObject.AddComponent<ContentSizeFitter>();
	}

	/** Get the anchor position of the tooltip. */
	private Vector3 position() {
		if (followObject == null) {
			return Input.mousePosition;
		}
		else {
			return Camera.main.WorldToScreenPoint(followObject.transform.position);
		}
	}

	/** Check if the object has a TooltipMessage component. */
	private string getMessage(GameObject obj) {
		if (obj.GetComponent<TooltipMessage>() != null) {
			return obj.GetComponent<TooltipMessage>().message();
		}
		else {
			return obj.ToString();
		}
	}

	/** Find where the tooltip goes on the screen. */
	private void placeTooltip() {
		Rect screen = new Rect(0, 0, Screen.width, Screen.height);
		
		Vector3 refPoint = text.GetComponent<RectTransform>().sizeDelta;

		Vector2 newPosition;

		if (screen.Contains(position() + offset + new Vector3(-refPoint.x, refPoint.y))) {
			newPosition = position() + offset;
		}
		else {
			newPosition = position() - offset;
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
	
	public void displayBubble(GameObject obj) {
		followObject = obj;
		display(getMessage(obj));
	}

	public void displayBubble(GameObject obj, string msg) {
		followObject = obj;
		display(msg);
	}
	
	public void displayTooltip(GameObject obj) {
		followObject = null;
		display(getMessage(obj));
	}

	public void displayTooltip(string msg) {
		followObject = null;
		display(msg);
	}
		
	private void display(string msg) {
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

	/* Fade out the tooltip then close it (object is not destroyed) */
	public void fadeOutAndClose(int seconds = 0) {
		fadeRoutine = StartCoroutine(fadeAndClose(false, seconds));
	}

	/* Fade out the tooltip then destroy it */
	public void fadeOutAndDestroy(int seconds = 0) {
		fadeRoutine = StartCoroutine(fadeAndClose(true, seconds));
	}

	/* Fade out a list of objects, return false when all are faded. */
	static private bool fadeObjects(float amount, params GameObject[] objs) {
		bool stillShowing = false;

		foreach (GameObject obj in objs) {
			Color objColor = obj.GetComponent<MaskableGraphic>().color;

			if (Time.deltaTime < objColor.a) {
				objColor.a -= Time.deltaTime;
				stillShowing = true;
			}
			else {
				objColor.a = 0.0f;
			}

			obj.GetComponent<MaskableGraphic>().color = objColor;
		}

		return stillShowing;
	}

	private IEnumerator fadeAndClose(bool destroyWhenDone, int secondsToWait = 0) {
		if (secondsToWait > 0) yield return new WaitForSeconds(secondsToWait);

		while(fadeObjects(0.1f, text, background)) {
			yield return new WaitForSeconds(0.001f);
		}

		if (destroyWhenDone) Destroy(this.gameObject);
		else close();
	}

	public void close() {
		if (fadeRoutine != null) {
			StopCoroutine(fadeRoutine);
			fadeRoutine = null;
		}

		Destroy(text);
		text = null;

		Destroy(background);
		background = null;

		// do not clear the followObject in here!
	}

	void OnDestroy() {
		close();
	}
}
