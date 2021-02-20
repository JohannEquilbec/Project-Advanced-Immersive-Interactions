using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Buttun_Color : MonoBehaviour
{
	public Button yourButton;
	public Material lineMaterial;
	public Material newMat;

	void Start()
	{
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
	}

	void OnClick()
	{	
	lineMaterial = newMat;
	}
}