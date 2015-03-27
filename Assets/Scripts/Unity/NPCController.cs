using UnityEngine;
using System.Collections;

public class NPCController : Interactable {

	bool facingRight = true;
	Animator animator;
	public Vector3 offset;	
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> () as Animator;
		StartCoroutine ("RandomMovement");
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
		UI.Get.makeSpeechBubble(this.gameObject, text).fadeOutAndDestroy(3);
	}

	void flipSprite() 
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public override void interact(GameObject actor)	{
		int talk = Random.Range (0,2);
		switch(talk)
		{
		case 0:
			onTalk ("I used to be a blacksmith like you. Then I took a hammer to the knee...");
			break;
		case 1:
			onTalk ("Flies are delicious. Don't you think?");
			break;
		}
	}
}
