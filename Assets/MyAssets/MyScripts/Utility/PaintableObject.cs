﻿using UnityEngine;
using System.Collections;

public class PaintableObject : MonoBehaviour {

	public Renderer myRenderer;
	private ComputeBitmap computeBitmap = new ComputeBitmap ();
	public Shader shader;
	// Use this for initialization
	void Start () {
		
		Init ();
	}

	void Init(){
		Texture2D myTexture = new Texture2D (500, 500);
		myTexture.wrapMode = TextureWrapMode.Clamp;
		Color[] textureColors = new Color[500 * 500];
		Color blankColor = Color.black;
		blankColor.a = 0;
		for (int i = 0; i < textureColors.Length; i++) {
			textureColors [i] = blankColor;
		}
		myTexture.SetPixels (textureColors);
		myTexture.Apply ();
		myRenderer.material = new Material (shader);
		myRenderer.material.mainTexture = myTexture;
	}

	// For Debugging
	void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			Init ();
		}
	}
	public void RegisterRay(Vector2 uvCords,Texture2D brush ,float intencity,Color addColor){
		myRenderer.material.mainTexture = computeBitmap.ComputeBitMap (myRenderer.material.mainTexture as Texture2D, brush , uvCords, intencity,addColor);
	}

}
