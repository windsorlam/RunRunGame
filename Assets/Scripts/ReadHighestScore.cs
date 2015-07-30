using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class ReadHighestScore: MonoBehaviour {
	FileStream filestr;
	StreamReader reader;
	string strLine;
	// Use this for initialization
	void Start () {
		filestr = new FileStream("Assets/Data/runrungame.txt",FileMode.OpenOrCreate);
		reader = new StreamReader(filestr);

		//as long as the game start, get the highest score from the file
		try{
			strLine = reader.ReadLine();
			/*
				while(strLine != null){
					Debug.Log("We got: " + strLine);
					strLine = reader.ReadLine();
				}*/
			Score.highestScore = float.Parse(strLine);
			reader.Close();
		}
		catch(IOException ex){
			Debug.Log("Error: " + ex.Message);
			strLine = reader.ReadLine();
			return;
		}
		filestr.Close();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
