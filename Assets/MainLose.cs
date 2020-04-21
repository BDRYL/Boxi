using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLose: MonoBehaviour {

	public void TryAgain(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex - 2);
	}
	public void Quit(){
		Application.Quit ();
		Debug.Log ("qq");
	
	}


}
