using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DisplayInfo : MonoBehaviour
{

	public Texture2D bgTexture;

	private bool display = false;

	public TextAsset jsonFile; //read the buildings data from JSON file

	private void OnMouseOver(){
		display = true;
	}

	private void OnMouseExit() {
		display = false;
	}

	void OnGUI(){ 

		Buildings buildingsInJson = JsonUtility.FromJson<Buildings>(jsonFile.text);

		GUIStyle style = new GUIStyle (GUI.skin.GetStyle("label"));
		style.fontSize = 12;
        style.normal.background = bgTexture;

		string gui = "";
		gui += " Building data: " + "\n" + "\n";

		if (display == true) {

			foreach (Building building in buildingsInJson.buildings)
			{
				if (building.name == this.gameObject.name)
					{
						gui += " id: " + building.id + "\n";
						gui += " name: " + building.name + "\n";
						gui += " housenumber: " + building.housenumber + "\n";
						gui += " street: " + building.street + "\n";
						gui += " type: " + building.type + "\n" + "\n";
						gui += " Building total intensity: " + Math.Round(double.Parse(building.total_intensity)) + " kWh/m2/yr" + "\n";
						gui += " Building total electricity: " + Math.Round(double.Parse(building.total_elec)) + " kWh/m2/yr" + "\n";
						gui += " Building total natural gas: " + Math.Round(double.Parse(building.total_naturalgas)) + " kWh/m2/yr";
					}
			}

			GUI.Box (new Rect (10, 10, 250, 200), gui, style);

		}

	}

}