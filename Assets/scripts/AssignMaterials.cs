using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignMaterials : MonoBehaviour
{
    public Texture2D bgTexture;

    public TextAsset jsonFile; //read the buildings data from JSON file

    void Start()
    {
        AssignMaterial();
    }

    void OnGUI() {

        GUIStyle style = new GUIStyle (GUI.skin.GetStyle("label"));
		style.fontSize = 12;
        style.normal.background = bgTexture;

        string gui = "";

		gui += "Neighbourhood energy use" + "\n" + "\n";
        gui += "Mouse pointer over buildings to display building energy consumption data" + "\n" + "\n";
        gui += "\t" + "Left mouse button: " +  "look" + "\n";
        gui += "\t" + "Right mouse button: " +  "pan" + "\n";
        gui += "\t" + "Scroll wheel: " +  "zoom" + "\n" + "\n";
        gui += "Building energy data obtained from NREL ComStock & ResStock datasets" + "\n";

        GUI.Box (new Rect (Screen.width/2 - 200, 10, 400, 175), gui, style);
    }

    void AssignMaterial()
    {
        Buildings buildingsInJson = JsonUtility.FromJson<Buildings>(jsonFile.text);

        foreach (Transform child in transform)
        {
            Renderer renderer = child.GetComponent<Renderer>();

            Material[] mats = renderer.materials;

            foreach(Material mat in mats) {

                //for each building in json file
                foreach (Building building in buildingsInJson.buildings)
                {
                    if ((child.name == building.name) || (child.name == building.housenumber + " " + building.street )) //== name or housenumber + street
                    {
                        var total_int = double.Parse(building.total_intensity);

                        if ( total_int < 100)
                        {
                            Color epccolor = new Color32(0, 255, 0, 255);
                            mat.color = epccolor;
                            //green
                        }
                        else if ( total_int < 100 && total_int < 199)
                        {
                            Color epccolor = new Color32(85, 255, 0, 255);
                            mat.color = epccolor;
                        }
                        else if ( total_int < 200 && total_int < 299)
                        {
                            Color epccolor = new Color32(170, 255, 0, 255);
                            mat.color = epccolor;
                        }
                        else if ( total_int < 300 && total_int < 399)
                        {
                            Color epccolor = new Color32(255, 255, 0, 255);
                            mat.color = epccolor;
                        }
                        else if ( total_int < 400 && total_int < 499)
                        {
                            Color epccolor = new Color32(255, 178, 0, 255);
                            mat.color = epccolor;
                        }
                        else if ( total_int < 500 && total_int < 599)
                        {
                            Color epccolor = new Color32(255, 0, 0, 255);
                            mat.color = epccolor;
                        //red
                        }
                        else if (total_int > 600)
                        {
                            Color epccolor = new Color32(153, 77, 0, 255);
                            mat.color = epccolor;
                            //brown
                        }                    
                    }
                }
            }
        }
    }
}