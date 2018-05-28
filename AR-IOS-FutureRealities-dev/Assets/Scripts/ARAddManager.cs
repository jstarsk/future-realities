// By Starsky Lara
// starsk@noumena.io
// Future Realities Seminar - IAAC - Institute for Advanced Architecture of Catalonia
// under a Creative Commons Attribution-ShareAlike 3.0 Unported License.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARAddManager : MonoBehaviour {

	public GameObject ARAdd_1;
	public GameObject ARAdd_2;
	public GameObject ARAdd_3;

	public GameObject ARAdd;
	public int ARAddType;

	// Use this for initialization
	void Start () {
		ARAdd_1.SetActive(false);
		ARAdd_2.SetActive(false);
		ARAdd_3.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClickARAdd_1()
    {
		ARAdd_1.SetActive(true);
		ARAdd_2.SetActive(false);
        ARAdd_3.SetActive(false);
		ARAdd = ARAdd_1;
		ARAddType = 1;
	}
    
	public void OnClickARAdd_2()
    {
		ARAdd_1.SetActive(false);
		ARAdd_2.SetActive(true);
        ARAdd_3.SetActive(false);
		ARAdd = ARAdd_2;
		ARAddType = 2;

    }

	public void OnClickARAdd_3()
    {
		ARAdd_1.SetActive(false);
		ARAdd_2.SetActive(false);
		ARAdd_3.SetActive(true);
		ARAdd = ARAdd_3;
		ARAddType = 3;
    }
}
