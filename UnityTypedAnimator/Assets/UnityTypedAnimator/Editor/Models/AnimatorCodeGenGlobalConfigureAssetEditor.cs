using EgoParadise.UnityTypedAnimator.Editor.Editor;
using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace EgoParadise.UnityTypedAnimator.Editor
{
    [CustomEditor(typeof(AnimatorCodeGenGlobalConfigureAsset))]
    public class AnimatorCodeGenGlobalConfigureAssetEditor : UnityEditor.Editor
    {
        private AnimatorCodeGenGlobalConfigureAsset targetAsset => this.target as AnimatorCodeGenGlobalConfigureAsset;

        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();

            InspectorElement.FillDefaultInspector(root, this.serializedObject, this);
            
            var exportFilePath = root.QDefaultProperty(nameof(AnimatorCodeGenGlobalConfigureAsset.exportFilePath));
            var exportDirectory = root.QDefaultProperty(nameof(AnimatorCodeGenGlobalConfigureAsset.exportDirectory));

            if(this.targetAsset.splitFile)
            {
                exportFilePath.SetEnabled(false);
                exportDirectory.SetEnabled(true);
            }
            else
            {
                exportFilePath.SetEnabled(true);
                exportDirectory.SetEnabled(false);
            }

            var button = new Button(() => TypedAnimatorCodeGenerator.Generate(this.targetAsset));
            button.text = "Generate";
            root.Add(button);
            
            return root;
        }
    }
}
