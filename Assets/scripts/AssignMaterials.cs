using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignMaterials : MonoBehaviour
{
    public Texture2D bgTexture;
    public Texture buttonTexture;

    public TextAsset jsonFile; //read the buildings data from JSON file

    void Start()
    {
        AssignMaterialTotalInt();
    }

    void OnGUI() {

        GUIStyle style = new GUIStyle (GUI.skin.GetStyle("label"));
		style.fontSize = 12;
        style.normal.background = bgTexture;

        string gui = "";

		gui += "Urban energy modelling" + "\n" + "\n";
        gui += "Mouse pointer over buildings to display building energy consumption data" + "\n" + "\n";
        gui += " Navigation: " +  "\n";
        gui += "\t" + "Left mouse button: " +  "look" + "\n";
        gui += "\t" + "Right mouse button: " +  "pan" + "\n";
        gui += "\t" + "Scroll wheel: " +  "zoom" + "\n" + "\n";
        gui += "Building energy data obtained from NREL ComStock & ResStock datasets" + "\n";

        GUI.Box (new Rect (Screen.width/2 - 160, 10, 320, 175), gui, style);

        string gui2 = "";
        gui2 += "\n" +" Total energy usage (kWh/m2/yr)" + "\n" + "\n" + "\n";
        gui2 += " Total electricity usage (kWh/m2/yr)" + "\n" + "\n"+ "\n";
        gui2 += " Total natural gas usage (kWh/m2/yr)";

        //title and intro gui
        GUI.Box (new Rect (Screen.width - 270, 10, 260, 150), gui2, style); 

        //filter buttons
        if (GUI.Button(new Rect(Screen.width - 70, 20, 50, 30), buttonTexture))
            AssignMaterialTotalInt();

        if (GUI.Button(new Rect(Screen.width - 70, 60, 50, 30), buttonTexture))
            AssignMaterialTotalElec();

        if (GUI.Button(new Rect(Screen.width - 70, 100, 50, 30), buttonTexture))
            AssignMaterialTotalNgas();
            
    }

    void AssignMaterialTotalInt() 
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

    void AssignMaterialTotalElec()
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
                        var total_elec = double.Parse(building.total_elec);

                        if ( total_elec < 100)
                        {
                            Color epccolor = new Color32(0, 255, 0, 255);
                            mat.color = epccolor;
                            //green
                        }
                        else if ( total_elec < 100 && total_elec < 199)
                        {
                            Color epccolor = new Color32(170, 255, 0, 255);
                            mat.color = epccolor;
                        }
                        else if ( total_elec < 200 && total_elec < 299)
                        {
                            Color epccolor = new Color32(255, 255, 0, 255);
                            mat.color = epccolor;
                        }
                        else if ( total_elec > 300 && total_elec < 399)
                        {
                            Color epccolor = new Color32(255, 178, 0, 255);
                            mat.color = epccolor;
                        }
                        else if ( total_elec > 400 && total_elec < 499)
                        {
                            Color epccolor = new Color32(255, 0, 0, 255);
                            mat.color = epccolor;
                        //red
                        }
                        else if ( total_elec > 500)
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

    void AssignMaterialTotalNgas() 
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
                        var total_naturalgas = double.Parse(building.total_naturalgas);

                        if ( total_naturalgas < 50)
                        {
                            Color epccolor = new Color32(0, 255, 0, 255);
                            mat.color = epccolor;
                            //green
                        }
                        else if ( total_naturalgas > 50 && total_naturalgas < 99)
                        {
                            Color epccolor = new Color32(85, 255, 0, 255);
                            mat.color = epccolor;
                        }
                        else if ( total_naturalgas > 100 && total_naturalgas < 149)
                        {
                            Color epccolor = new Color32(170, 255, 0, 255);
                            mat.color = epccolor;
                        }
                        else if ( total_naturalgas > 150 && total_naturalgas < 199)
                        {
                            Color epccolor = new Color32(255, 255, 0, 255);
                            mat.color = epccolor;
                        }
                        else if ( total_naturalgas > 200 && total_naturalgas < 249)
                        {
                            Color epccolor = new Color32(255, 178, 0, 255);
                            mat.color = epccolor;
                        }
                        else if ( total_naturalgas > 250 && total_naturalgas < 299)
                        {
                            Color epccolor = new Color32(255, 0, 0, 255);
                            mat.color = epccolor;
                        //red
                        }
                        else if (total_naturalgas > 300)
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
    
