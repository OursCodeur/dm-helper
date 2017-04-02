using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoardBuilder : MonoBehaviour {
    public GameObject Square;

    int width = 17;
    int height = 17;
    int[,] map;
    string seed;
    int randomFillPercent = 45;

    // Use this for initialization
    void Start() {
        GenerateMap();
        RandomFillMap();
        if (map != null) {
            foreach (var x in Enumerable.Range(0, width)) {
                foreach (var y in Enumerable.Range(0, height)) {
                    GameObject newSquare = Instantiate(Square) as GameObject;
                    newSquare.transform.SetParent(this.transform, false);
                }
            }
        }

    }

    void GenerateMap() {
        map = new int[width, height];
    }

    void RandomFillMap() {
        seed = Time.time.ToString();
        System.Random pseudoRandom = new System.Random(seed.GetHashCode());

        foreach (var x in Enumerable.Range(0, width)) {
            foreach (var y in Enumerable.Range(0, height)) {
                map[x, y] = pseudoRandom.Next(0, 100) < randomFillPercent ? 1 : 0;
            }
        }
    }

    public void ClearBoard() {

        Toggle[] squares = GetComponentsInChildren<Toggle>();
        foreach (Toggle square in squares) { square.isOn = false; }
    }
}
