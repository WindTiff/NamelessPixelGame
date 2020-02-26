using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class AssetBundleControl
{
    [MenuItem("Assets/CreateAssetBundle")]
    public static void CreateAssetBundle() {

        BuildPipeline.BuildAssetBundles("Assets/AssetBundles", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }


}
