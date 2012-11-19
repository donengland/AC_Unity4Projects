using UnityEngine;
using System.Collections;

public static class PBlokConstants {
	
	// Using Aristotle
	// Potency is what the object can become--here used as mod or !mod
	public enum blokPotency {
		modify,
		no_modify
	};
	
	// Act, is what the object currently is--here, one of many types
	public enum blokAct{
		empty, // initial status when pblok is created
		surface_normal, // could split to new enum to avoid 'duplication'
		surface_frozen,
		surface_magnetic,
		block_normal, // act 'duplicated' here for 'normal'
		block_heavy,
		block_frozen,
		block_death
	};
}
