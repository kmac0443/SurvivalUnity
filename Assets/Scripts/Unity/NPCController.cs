using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {

	bool facingRight = true;
	Animator animator;
	Color color;
	private string npcDialogue = "";
	private Rect dialogueRect;
	private Transform player;
	public Vector3 offset;	

	public GUIStyle dialogueStyle;


	// Use this for initialization
	void Start () {
		color = Color.white;
		color.a = 0f;
		dialogueRect = new Rect (10, 10, 400, 50);
		player = this.gameObject.transform;
		animator = GetComponent<Animator> () as Animator;
		StartCoroutine ("RandomMovement");
	}

	void Update()
	{
		dialogueRect.x = player.position.x * 64 + offset.x;
		dialogueRect.y = player.position.y * 64 * -1 + offset.y;
	}

	void OnGUI (){
		GUI.color = color;
		GUI.Label (dialogueRect, npcDialogue, dialogueStyle);
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
						Flip ();
					}
					animator.SetTrigger("Move_Left");
					break;
				case 2:
					if(facingRight){
						Flip ();
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
			int talk = Random.Range (0,10);
			switch(talk)
			{
				case 1:
					onTalk ("I used to be a blacksmith like you. Then I took a hammer to the knee...");
					Debug.Log ("Talk one");
					break;
				case 2:
					onTalk ("Flies are delicious. Don't you think?");
					Debug.Log ("Talk two");
					break;
			}
		}
	}

	private IEnumerator Fade()
	{
		yield return new WaitForSeconds(3);
		while(color.a > 0)
		{
			color.a -= Time.deltaTime;
			yield return new WaitForSeconds(0.001f);
		}
	}

	void onTalk(string text)
	{
		Debug.Log ("Changing");
		StopCoroutine ("Fade");
		color.a = 1f;
		npcDialogue = text;
		StartCoroutine ("Fade");
	}

	void Flip() 
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
