using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerdoor : MonoBehaviour
{
    [SerializeField] private Animator doorPos = null;
	[SerializeField] private Animator doorMinus = null;

	
	[SerializeField] private bool openTrigger = false;
	[SerializeField] private bool closeTrigger = false;
	[SerializeField] private bool isspawned = false;
	
	private void respawn() {
		
		gameObject.SetActive(true);
		
	}
	
	private void OnTriggerEnter(Collider other) {
		
		if (other.CompareTag("Player")) {
			
			if (openTrigger) {
				
				doorPos.Play("doorcloselocal", 0, 0.0f);
				doorMinus.Play("dooropenlocal", 0, 0.0f);
				//gameObject.SetActive(false);
				
				
				
			} else if (closeTrigger) {
				
				doorMinus.Play("dooropenlocal", 0, 0.0f);
				doorPos.Play("doorcloselocal", 0, 0.0f);
				//gameObject.SetActive(false);
				
				
			}	
		}
	}
	
	private void OnTriggerExit(Collider other) {
		
		if (other.CompareTag("Player")) {
			Debug.Log("door should close");
			doorMinus.Play("doorcloselocal", 0, 0.0f);
			doorPos.Play("dooropenlocal", 0, 0.0f);
		}
		
		
	}
	
}
