using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EgoParadise.UnityTypedAnimator.Editor
{
    [CreateAssetMenu(fileName = "AnimatorCodeGenGlobalConfigureAsset", menuName = "EgoParadise/AnimatorCodeGenGlobal")]
    public class AnimatorCodeGenGlobalConfigureAsset : ScriptableObject
    {
        public string exportDirectory;
        public string exportFilePath;
        public string exportNamespace;
        public string typePrefix;
        public string typeSuffix;
        public bool splitFile = true;

        public List<AnimatorCodeGenConfigureAsset> configures = new List<AnimatorCodeGenConfigureAsset>();
    }
}