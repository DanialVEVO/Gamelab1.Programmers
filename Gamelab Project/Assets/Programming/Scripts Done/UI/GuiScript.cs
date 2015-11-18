﻿/* 7S_GUI_001
 * GUI Script
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;

public class GuiScript : MonoBehaviour {

	public enum MenuPanels {
		MainMenu,       // 0
		GameMenu,       // 1
		Pause,          // 2
		Options,        // 3
		GameOptions,    // 4
		Credits,        // 5
		HelpScreen,     // 6
		GamePlay        // 7
	}

	public MenuPanels menuPanels;
	public GameObject[] menuObjArray;
	public bool inPause;

	void Update() {
		PanelSwitchActive();
		SwitchPauseMode();
	}

	public void PanelSwitch(int newMenuPanel) {
		menuPanels = (MenuPanels)newMenuPanel;
		PanelSwitchActive();
	}

	void PanelSwitchActive() {
		MenuOff();
		switch (menuPanels) {
			case (MenuPanels)0:
				menuObjArray[0].SetActive(true);
				break;
			case (MenuPanels)1:
				menuObjArray[1].SetActive(true);
				break;
			case (MenuPanels)2:
				menuObjArray[2].SetActive(true);
				break;
			case (MenuPanels)3:
				menuObjArray[3].SetActive(true);
				break;
			case (MenuPanels)4:
				menuObjArray[4].SetActive(true);
				break;
			case (MenuPanels)5:
				menuObjArray[5].SetActive(true);
				break;
			case (MenuPanels)6:
				menuObjArray[6].SetActive(true);
				break;
		}
	}

	void MenuOff() {
		for (int i = 0; i < menuObjArray.Length; i++) {
			menuObjArray[i].SetActive(false);
		}
	}

	public void ExitGame() {
		Application.Quit();
	}

	public void StartNewGame() {
		Application.LoadLevel(1);
	}

	public void StartSavedGame() {
		//??
	}

	public void SwitchPauseMode() {
		if (Input.GetButtonDown("Pause")) {
			if (inPause == false && menuPanels == (MenuPanels)7) {
				menuPanels = (MenuPanels)2;
				Time.timeScale = 0;
				inPause = true;
			} else {
				menuPanels = (MenuPanels)7;
				Time.timeScale = 1;
				inPause = false;
			}
		}
	}

}