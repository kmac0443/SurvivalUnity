using UnityEngine;
using System.Collections;

/*
 * Define a reference point on a sprite to use for rendering order.
 * 
 * Each sprite can optionally define a SpriteOrderer.Anchor that determines its Y-axis reference point.
 */
public class SpriteOrderer : MonoBehaviour {
	/* The ordering Anchor to use for a paricular sprite, based off the collider */
	public enum Anchor {
		BOTTOM, // reference point is the bottom of the collider
		CENTER, // reference point is the center of the collider -- assumes center pivot
	};
	
	/* How far from the anchor to the edge the y-axis bound is
	 * 0.0f is right on the anchor, 1.0f is on the edge
	 * For center anchors, -1.0f is the top edge radially.
	 */
	public float ratio = 0.0f;
	
	/* Which point to use for comparisons */
	public Anchor anchor = Anchor.BOTTOM;

	/* Compute the y value based on the ratio */
	private float ComputeRatio(float start, float end) {
		return Mathf.Abs(start - end) * ratio + start;
	}

	/* Compute the y value based on the ratio using the larger of the two end values */
	private float ComputeRatio(float start, float end1, float end2) {
		float end;
		if (Mathf.Abs(end1 - start) > Mathf.Abs(end2 - start)) end = end1;
		else end = end2;

		return Mathf.Abs(start - end) * ratio + start;
	}

/// Static methods ///

	/*
	 * Get the y-axis reference point for a sprite.
	 * 
	 * Checks if the sprite has an orderer defined and uses it if it does.
	 * Must be static since not all sprites have SpriteOrderers.
	 * 
	 * Assumes center pivot for sprites.
	 */
	private static float GetYBound(GameObject sprite) {
		SpriteOrderer orderer = sprite.GetComponent<SpriteOrderer>();

		if (orderer == null) {
			return sprite.collider2D.bounds.min.y;
		}
		else switch (orderer.anchor) {
		case Anchor.BOTTOM:
			return orderer.ComputeRatio(sprite.collider2D.bounds.min.y, sprite.collider2D.bounds.max.y);
		case Anchor.CENTER:
			return orderer.ComputeRatio(sprite.collider2D.transform.position.y, sprite.collider2D.bounds.min.y);
		default:
			throw new System.ArgumentOutOfRangeException("Unknown sprite ordering Anchor.");
		}
	}

	/*
	 * Compares two objects to see which is in front.
	 * 
	 * Each sprite has a Y-axis reference point. These are compared to determine which is in front.
	 */
	public static bool InFrontOf(GameObject sprite1, GameObject sprite2) {
		return GetYBound(sprite1) < GetYBound(sprite2);
	}
}