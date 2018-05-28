// By Starsky Lara
// starsk@noumena.io
// Future Realities Seminar - IAAC - Institute for Advanced Architecture of Catalonia
// under a Creative Commons Attribution-ShareAlike 3.0 Unported License.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FutureRealities
{
	public class ID
	{
		public static string GoogleMapsApi = "AIzaSyCbzXQBO1FAPrTxf2hgxAvE5cI_5OExUd4";
		public static string GoogleFirebaseApi = "https://ar-futurerealities-dev.firebaseio.com/";

		public enum Scenes
		{
			SplashScreen = 0,
			Login = 1,
			Home = 2,
			ARAdd = 3,
			ARView = 4
		}

		public static string[] SceneNames
		{
			get
			{
				return new string[5] { "SplashScreen", "Login", "Home", "ARAdd", "ARView" };
			}
		}
	}
}

