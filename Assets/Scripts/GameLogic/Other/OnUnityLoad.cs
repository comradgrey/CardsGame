using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class OnUnityLoad: MonoBehaviour {

    static OnUnityLoad() {
        if (!EditorApplication.isPlaying)
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
