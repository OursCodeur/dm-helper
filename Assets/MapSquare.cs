using UnityEngine;
using UnityEngine.UI;

public class MapSquare : MonoBehaviour {

	private	Toggle ParentToggle;
	
	void Start () {

		ParentToggle = GetComponent<Toggle> ();
		ParentToggle.onValueChanged.AddListener (delegate {ToggleEdges(); });
	}

	public void ToggleEdges() {

        int x = (int)ParentToggle.GetComponent<TwoDCoord>().coord.x;
		int y = (int)ParentToggle.GetComponent<TwoDCoord>().coord.y;

        MapHorizEdgesPanel boardH = GameObject.FindGameObjectWithTag("BoardH").GetComponent<MapHorizEdgesPanel>();
		MapVertEdgesPanel  boardV = GameObject.FindGameObjectWithTag("BoardV").GetComponent<MapVertEdgesPanel>();

		try { boardH.MapHorizEdgesArray [x  ,y	 ].isOn = ParentToggle.isOn; } catch (System.IndexOutOfRangeException) { /**/ }
		try { boardH.MapHorizEdgesArray [x  ,y-1 ].isOn = ParentToggle.isOn; } catch (System.IndexOutOfRangeException) { /**/ }
		try { boardV.MapVertEdgesArray  [x-1,y	 ].isOn = ParentToggle.isOn; } catch (System.IndexOutOfRangeException) { /**/ }
		try { boardV.MapVertEdgesArray  [x  ,y	 ].isOn = ParentToggle.isOn; } catch (System.IndexOutOfRangeException) { /**/ }
	}
}
