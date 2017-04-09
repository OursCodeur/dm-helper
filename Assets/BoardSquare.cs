using UnityEngine;
using UnityEngine.UI;

public class BoardSquare : MonoBehaviour {

	private	Toggle thisToggle;
	
	void Start () {

		thisToggle = GetComponent<Toggle> ();
		thisToggle.onValueChanged.AddListener (delegate {ToggleEdges(); });
	}

	public void ToggleEdges() {

        int x = (int)thisToggle.GetComponent<TwoDCoord>().coord.x;
		int y = (int)thisToggle.GetComponent<TwoDCoord>().coord.y;

        BoardHorizOverlay boardH = GameObject.FindGameObjectWithTag("BoardH").GetComponent<BoardHorizOverlay>();
		BoardVertOverlay  boardV = GameObject.FindGameObjectWithTag("BoardV").GetComponent<BoardVertOverlay>();

		try { boardH.horizEdgesArray [x  ,y	 ].isOn = thisToggle.isOn; } catch (System.IndexOutOfRangeException) { /**/ }
		try { boardH.horizEdgesArray [x  ,y-1].isOn = thisToggle.isOn; } catch (System.IndexOutOfRangeException) { /**/ }
		try { boardV.vertEdgesArray  [x-1,y	 ].isOn = thisToggle.isOn; } catch (System.IndexOutOfRangeException) { /**/ }
		try { boardV.vertEdgesArray  [x  ,y	 ].isOn = thisToggle.isOn; } catch (System.IndexOutOfRangeException) { /**/ }
	}
}
