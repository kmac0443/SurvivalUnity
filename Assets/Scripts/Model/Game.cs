using UnityEngine;
using System.Collections;

/*
 * The singleton object that stores the essential model objects.
 * If we were actually making the game, we would need to handle loading saved Games and such.
 */
public class Game {
	private static Game game = null;

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
}
