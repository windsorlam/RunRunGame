using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class SaveHighestScore : MonoBehaviour {
	FileStream filestr;
	StreamWriter writer;
	string strLine;
	// Use this for initialization
	void Start () {
		filestr = new FileStream("/Users/LIUXUNYU/Desktop/runrungame.txt",FileMode.Open);
		writer = new StreamWriter(filestr);
		String highestRecord = Score.highestScore.ToString ();
		
		try{
			writer.WriteLine(highestRecord);
			writer.Close();
		}
		catch (IOException ex){
			Debug.Log(ex.Message);
			//Console.ReadLine(); //?????
			return ;
		}
		filestr.Close();
	}

	// Update is called once per frame
	void Update () {

	}
}
