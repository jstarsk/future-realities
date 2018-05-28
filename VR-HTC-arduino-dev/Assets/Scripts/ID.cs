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

        public enum Scenes
        {
            startExperience = 0,
            LoadVRGameObjects = 1,
            opening = 2,
            VR_A = 3,
            ending = 4
        }

        public static string[] SceneNames
        {
            get
            {
                return new string[5] { "startExperience", "LoadVRGameObjects", "opening", "VR_A", "ending" };
            }
        }
    }
}

