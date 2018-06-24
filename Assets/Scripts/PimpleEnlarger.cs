using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PimpleEnlarger : MonoBehaviour {
	private GameObject pimple;
	private Transform pimpleTransform;

	private Animator animator;

	private SpriteRenderer renderer;

	private bool fade;

	// Use this for initialization
	void Start () {
		pimple = gameObject;
		pimpleTransform = pimple.GetComponent<Transform>();
		animator = pimple.GetComponent<Animator>();
		renderer = pimple.GetComponent<SpriteRenderer>();
		fade = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(pimpleTransform.localScale.x >= 5){
			ExplodePimple();
		}

		if(fade){
			Color color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, renderer.color.a-0.02f);
			renderer.color = color;
		}
	}

	/// <summary>
	/// OnMouseDown is called when the user has pressed the mouse button while
	/// over the GUIElement or Collider.
	/// </summary>
	void OnMouseDown()
	{
		if(pimpleTransform.localScale.x < 5){
			EnlargePimple();
		}
	}

	private void EnlargePimple(){
		pimpleTransform.localScale += new Vector3(0.5f, 0.5f, 0);
	}

	private void ExplodePimple(){
		animator.SetBool("maxSize", true);
	}

	private void FadeExplosion(){
		fade = true;
	}
}
