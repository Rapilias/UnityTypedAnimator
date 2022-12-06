using UnityEditor.Animations;
using UnityEngine;

namespace EgoParadise.UnityTypedAnimator.Editor
{
    [CreateAssetMenu(fileName = "AnimatorCodeGenConfigureAsset", menuName = "EgoParadise/AnimatorCodeGen")]
    public class AnimatorCodeGenConfigureAsset : ScriptableObject
    {
        [field: SerializeField]
        public AnimatorController animator { get; set; } = null;
        [field: SerializeField]
        public string typeName { get; set; } = string.Empty;
    }
}
