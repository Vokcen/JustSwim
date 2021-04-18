﻿using UnityEngine;
using UnityEngine.UI;

public class SceneControlButton : MonoBehaviour
{
	
	enum TargetScene
	{
		Next,
		Previous,
		MainMenu,
		Fun

	}

	[SerializeField] TargetScene targetScene;
	Button button;

	void Start ()
	{
		button = GetComponent<Button> ();

		button.onClick.RemoveAllListeners ();
		switch (targetScene) {
			case TargetScene.MainMenu:
				button.onClick.AddListener (() => SceneController.LoadScene(1));
				break;

			case TargetScene.Next:
				button.onClick.AddListener (() => SceneController.LoadNextScene ());
				break;

			case TargetScene.Previous:
				button.onClick.AddListener (() => SceneController.LoadPreviousScene ());
				break;
			case TargetScene.Fun:
				button.onClick.AddListener(() => SceneController.LoadFunScene());
				break;
		}

	}
}
