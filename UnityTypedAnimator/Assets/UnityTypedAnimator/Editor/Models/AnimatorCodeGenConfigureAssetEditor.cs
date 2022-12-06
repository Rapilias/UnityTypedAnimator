using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using EgoParadise.UnityTypedAnimator.Editor.Editor;
using System.Security.Cryptography;
using System.Text;

namespace EgoParadise.UnityTypedAnimator.Editor
{
    [CustomEditor(typeof(AnimatorCodeGenConfigureAsset))]
    public class AnimatorCodeGenConfigureAssetEditor : UnityEditor.Editor
    {
        private AnimatorCodeGenConfigureAsset targetAsset => this.target as AnimatorCodeGenConfigureAsset;
        private readonly GUID uxmlPath = new GUID("bad982d0cc0433248b6bc807423e4ce7");

        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();

            InspectorElement.FillDefaultInspector(root, this.serializedObject, this);

            var animator = root.QDefaultProperty(nameof(AnimatorCodeGenConfigureAsset.animator));
            var typeName = root.QDefaultProperty(nameof(AnimatorCodeGenConfigureAsset.typeName));
            var paramsText = new TextField();
            var button = new Button(() =>
            {
                var builder = new StringBuilder();
                foreach (var item in targetAsset.animator.parameters)
                {
                    builder.Append($"{item.type.ToString()}: {item.name}\n");
                }
                foreach (var item in targetAsset.animator.layers)
                {
                    builder.Append($"Layer: {item.name}\n");
                }
                paramsText.SetValueWithoutNotify(builder.ToString());
            });
            button.text = "View Parameters";
            root.Add(button);
            paramsText.multiline = true;
            paramsText.SetEnabled(false);
            root.Add(paramsText);

            return root;
        }
    }
}
