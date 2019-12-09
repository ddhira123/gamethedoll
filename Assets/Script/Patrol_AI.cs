using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_AI : MonoBehaviour {

	public float speed;
	public bool movingRight;

	void Update(){
		if(GameControl.instance.gameOver==false){
			if(movingRight == true){
				transform.Translate(2 * Time.deltaTime * speed, 0,0);
				transform.localScale = new Vector2(0.6483271f, 0.6483271f);
			}
			else{
				transform.Translate(-2 * Time.deltaTime * speed, 0,0);
				transform.localScale = new Vector2(-0.6483271f, 0.6483271f);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D trig){
		if(trig.gameObject.CompareTag("turn")){
			if(movingRight == true){
				movingRight = false;
			}
			else{
				movingRight = true;
			}
		}
	}
}
