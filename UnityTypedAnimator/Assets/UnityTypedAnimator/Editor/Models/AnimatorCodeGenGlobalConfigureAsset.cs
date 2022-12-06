using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EgoParadise.UnityTypedAnimator.Editor
{
    [CreateAssetMenu(fileName = "AnimatorCodeGenGlobalConfigureAsset", menuName = "EgoParadise/AnimatorCodeGenGlobal")]
    public class AnimatorCodeGenGlobalConfigureAsset : ScriptableObject
    {
        [field: SerializeField]
        public string exportPath { get; set; }
        [field: SerializeField]
        public string exportNamespace { get; set; }
        [field: SerializeField]
        public string typePrefix { get; set; }
        [field: SerializeField]
        public string typeSuffix { get; set; }
        [field: SerializeField] 
        public bool splitFile { get; set; } = true;

        [field: SerializeField]
        public List<AnimatorCodeGenConfigureAsset> configures { get; set; } = new List<AnimatorCodeGenConfigureAsset>();
    }
}