using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * The singleton object that stores the essential model objects.
 * If we were actually making the game, we would need to handle loading saved Games and such.
 */
public class Game {
	private static Game game = null;

	private Dictionary<string, Vector3> playerPosition = new Dictionary<string, Vector3>();
	public Player Player { get; private set; }
	public PlayerController PlayerController { get; set; } // the Unity script that controls the player

	private Game() {
		Player = new Player();
	}

	public static Game Get {
		get {
			if (game == null) {
				game = new Game();
			}

			return game;
		}
	}

	public void changeScene(string scene) {
		playerPosition[Application.loadedLevelName] = PlayerController.transform.position;
		Application.LoadLevel(scene);
	}

	public bool playerHasStartingPosition() {
		return playerPosition.ContainsKey(Application.loadedLevelName);
	}

	public Vector3 playerStartingPosition() {
		if (playerHasStartingPosition()) {
			return playerPosition[Application.loadedLevelName];
		}
		else {
			return Vector3.zero;
		}
	}
}
