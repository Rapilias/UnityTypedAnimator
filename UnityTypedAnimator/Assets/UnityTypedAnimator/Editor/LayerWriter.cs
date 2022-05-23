using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace EgoParadise.UnityTypedAnimator.Editor
{
    public class LayerWriter
    {
        public static void WriteGetLayerWeightFunction(StringBuilder builder, string name, int baseIndent, int indentStep)
        {
            var indent = new string(' ', baseIndent);
            builder.Append($"{indent}public float Get{name}Weight() => this.animator.GetLayerWeight(this.{name}Id);\n");
        }
        public static void WriteSetLayerWeightFunction(StringBuilder builder, string name, int baseIndent, int indentStep)
        {
            var indent = new string(' ', baseIndent);
            builder.Append($"{indent}public void Set{name}Weight(float {name}) => this.animator.SetLayerWeight(this.{name}Id, {name});\n");
        }
    }
}
