using UnityEngine;
using System.Collections;

public class MoveSample : MonoBehaviour
{	
	void Start(){
		/*iTween.MoveBy(gameObject, iTween.Hash("x", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));*/
		iTween.MoveTo(gameObject, iTween.Hash("x", 10, "easeInOutExpo", "loopType", "delay", .1));

	}
}

