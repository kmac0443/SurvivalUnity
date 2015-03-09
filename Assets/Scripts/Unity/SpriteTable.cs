using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;
using System.IO;

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

	public Sprite getSprite(Item.Type i) {
		return (Sprite)sprites[(int)i];
	}

	/*
	 * Load the spritesheet relative to Assets/Sprites.
	 * For example, the "Items" spritesheet is at Items/Items.png
	 */
	public static SpriteTable Get(string asset) {
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
}
