using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour {

	public WeaponController weaponController;
	public ShipHealth shipHealth;

	public static int damage = 25;
	public static int health = 150;
	public static float ROF = 0.15f;

	public static int kills = 0;
	public static int waves = 0;

	void Start () {
		weaponController.ROF = PlayerUpgrades.ROF;
		weaponController.damage = PlayerUpgrades.damage;
		shipHealth.maxHealth = PlayerUpgrades.health;
		shipHealth.health = PlayerUpgrades.health;
	}
}
