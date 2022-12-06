using UnityEditor.Animations;
using UnityEngine;

namespace EgoParadise.UnityTypedAnimator.Editor
{
    [CreateAssetMenu(fileName = "AnimatorCodeGenConfigureAsset", menuName = "EgoParadise/AnimatorCodeGen")]
    public class AnimatorCodeGenConfigureAsset : ScriptableObject
    {
        public AnimatorController animator = null;
        public string typeName = string.Empty;
    }
}
