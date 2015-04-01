using UnityEngine;
using System.Collections;

public class NPCController : Interactable {

	bool facingRight = true;
	Animator animator;
	string[] dialogLines;
	public TextAsset textFile;

	Tooltip speechBubble = null;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> () as Animator;
		StartCoroutine ("RandomMovement");
		if (textFile != null) {
			dialogLines = (textFile.text.Split('\n'));
		}
		else {
			dialogLines = new string[]{"Hello!", "How's it going?", "I can't talk right now. I've got some... something to do instead of talk to you."};
		}

		speechBubble = UI.Get.makeSpeechBubble();
	}

	private IEnumerator RandomMovement()
	{
		while (true) {
			yield return new WaitForSeconds((float)(Random.Range(2, 5)));
			int move = Random.Range (0, 4);
			switch(move)
			{
				case 0:
					animator.SetTrigger("Move_Forward");
					break;
				case 1:
					if(!facingRight) {
						flipSprite();
					}
					animator.SetTrigger("Move_Left");
					break;
				case 2:
					if(facingRight){
						flipSprite();
					}
					animator.SetTrigger("Move_Right");
					break;
					
				case 3:
					animator.SetTrigger("Move_Back");
					break;
				default:
					Debug.Log ("Whoops. We got a number of: " + move);
					break;
			}
		}
	}

	void onTalk(string text)
	{
		speechBubble.displayBubble(this.gameObject, text);
		speechBubble.fadeOutAndClose(3);
	}

	void flipSprite() 
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public override bool interact(GameObject actor)	{
		int talk = Random.Range(0,dialogLines.Length);
		onTalk(dialogLines[talk]);

		return true; // NPC is still there
	}

	void OnDestroy() {
		Destroy(speechBubble);
	}
}
