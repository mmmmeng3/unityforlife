using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
	
	

	public Text countText;
	
	public float speed;

	public	Text win; 
	
	private Rigidbody rb;

	private int count;


	void Start(){
		rb =GetComponent<Rigidbody>();
		count =0;
		countText.text ="Point: "+ count.ToString();
		win.text = "";
	}

	void FixedUpdate(){
		float moveH = Input.GetAxis("Horizontal");
		float moveV = Input.GetAxis("Vertical");

		Vector3 movement =new Vector3(moveH,0.0f,moveV);

		rb.AddForce(movement* speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Pick Up")){
			other.gameObject.SetActive(false);
			count = count + 1;
			countText.text ="Point: "+ count.ToString();
			if(count >=4){
				win.text ="You win!";
			}
		}
	}
}