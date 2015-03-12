using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;
using System.IO;

/*
 * Pass in an enum, get the sprite for it.
 */
public class SpriteTable {
	private static Dictionary<string, SpriteTable> instances = new Dictionary<string, SpriteTable>();

	public static readonly string ASSET_PREFIX = "Assets/Sprites/";

	private UnityEngine.Object[] sprites;

	private SpriteTable(string spritesheet) {
		sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath(spritesheet);

		if (AssetDatabase.LoadAllAssetRepresentationsAtPath(spritesheet) == null) {
			throw new FileNotFoundException("Failed to load sprite sheet \"" + spritesheet + "\"");
		}
	}

	private Sprite getSprite(int i) {
		return (Sprite)sprites[i];
	}

	/*
	 * Load a spritesheet relative to Assets/Sprites.
	 */
	private static SpriteTable getSpriteTable(string asset) {
		try {
			if (!instances.ContainsKey(asset)) {
				Debug.Log("Loading assets at " + asset);
				instances.Add(asset, new SpriteTable(ASSET_PREFIX + asset));
			}
			
			return instances[asset];
		}
		catch (Exception e) {
			Debug.LogError(e.Message);
			return null;
		}
	}

	/*
	 * The "Items" spritesheet is at Items/Items.png
	 * Can add additional overloads for other enums as/if needed.
	 */
	public static Sprite Get(Item.Type item) {
		return getSpriteTable("Items/Items.png").getSprite((int)item);
	}
}
