using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DisplayInfo : MonoBehaviour
{

	//private bool status = true;

	//public GuiStatus guistatus;

	public Texture2D bgTexture;

	private bool display = false;

	private float timeShow = 7.0f;

	public TextAsset jsonFile; //read the buildings data from JSON file

//remove?
	private void OnMouseDown()
	{
		// foreach (Transform child in this.transform)
		// {
			if (Physics.queriesHitTriggers == true) {
				
				display = true;

			}
		// }
	}

	private void OnMouseOver(){
		//Debug.Log("hover");
		display = true;
	}

	private void OnMouseExit() {
		display = false;
	}

	void OnGUI(){ 

		Buildings buildingsInJson = JsonUtility.FromJson<Buildings>(jsonFile.text);

		//not used?
		GUIStyle style = new GUIStyle (GUI.skin.GetStyle("label"));
		style.fontSize = 12;
        style.normal.background = bgTexture;

		string gui = "";
		gui += " Building data: " + "\n" + "\n";

		//Debug.Log(this.gameObject.name);

		if (display == true) {

			foreach (Building building in buildingsInJson.buildings)
			{
			//if (building.street == "17th Street")
			if (building.name == this.gameObject.name)
				{
					gui += " id: " + building.id + "\n";
					gui += " name: " + building.name + "\n";
					gui += " housenumber: " + building.housenumber + "\n";
					gui += " street: " + building.street + "\n";
					//gui += "area: " + double.Parse(building.area)+ " m2" + "\n";
					gui += " type: " + building.type + "\n" + "\n";
					gui += " Building total intensity: " + Math.Round(double.Parse(building.total_intensity)) + " kWh/m2/yr" + "\n";
					gui += " Building total electricity: " + Math.Round(double.Parse(building.total_elec)) + " kWh/m2/yr" + "\n";
					gui += " Building total natural gas: " + Math.Round(double.Parse(building.total_naturalgas)) + " kWh/m2/yr";
				}
			}
		
			//gui += "\n" + "Press the 'U' key for more info";

			GUI.Box (new Rect (10, 10, 250, 200), gui, style);

			//guiOn = true;
			//guistatus.guistatus = false;
		}

	}

	void Update()
	{
		if (display == true)
		{
			//status = false;
			//display = false;
			timeShow -= Time.deltaTime;
			if (timeShow <= 0)
			{
				display = false;
				//guistatus.guistatus = false;
				timeShow = 7.0f;
			}

		}
	}

}