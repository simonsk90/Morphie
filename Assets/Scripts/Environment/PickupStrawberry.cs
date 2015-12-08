using UnityEngine;
using System.Collections;

public class PickupStrawberry : PickupSuperClass {

	public override void Effect()
	{
		player.stamina -= 30;
		if (player.stamina < 0)
			player.stamina = 0;
	}
	
}
