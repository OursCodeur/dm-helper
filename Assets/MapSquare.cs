using UnityEngine;
using UnityEngine.UI;

public class MapSquare : MonoBehaviour {

	private	Toggle thisToggle;
	
	void Start () {

		thisToggle = GetComponent<Toggle> ();
		thisToggle.onValueChanged.AddListener (delegate {ToggleEdges(); });
	}

	public void ToggleEdges() {

        int x = (int)thisToggle.GetComponent<TwoDCoord>().coord.x;
		int y = (int)thisToggle.GetComponent<TwoDCoord>().coord.y;

        MapHorizEdgesPanel boardH = GameObject.FindGameObjectWithTag("BoardH").GetComponent<MapHorizEdgesPanel>();
		MapVertEdgesPanel  boardV = GameObject.FindGameObjectWithTag("BoardV").GetComponent<MapVertEdgesPanel>();

		try { boardH.MapHorizEdgesArray [x  ,y	 ].isOn = thisToggle.isOn; } catch (System.IndexOutOfRangeException) { /**/ }
		try { boardH.MapHorizEdgesArray [x  ,y-1 ].isOn = thisToggle.isOn; } catch (System.IndexOutOfRangeException) { /**/ }
		try { boardV.MapVertEdgesArray  [x-1,y	 ].isOn = thisToggle.isOn; } catch (System.IndexOutOfRangeException) { /**/ }
		try { boardV.MapVertEdgesArray  [x  ,y	 ].isOn = thisToggle.isOn; } catch (System.IndexOutOfRangeException) { /**/ }
	}
}
