using System.Text;
using UnityEngine;

namespace EgoParadise.UnityTypedAnimator.Editor
{
    public class FloatParameterWriter : IParameterWriter
    {
        public void WriteGetParameterFunction(StringBuilder builder, string name, int baseIndent)
        {
            var indent = new string(' ', baseIndent);
            builder.Append($"{indent}public float Get{name}() => this.animator.GetFloat(this.{name}Id);\n");
            
        }

        public void WriteSetParameterFunction(StringBuilder builder, string name, int baseIndent)
        {
            var indent = new string(' ', baseIndent);
            builder.Append($"{indent}public void Set{name}(float {name}) => this.animator.SetFloat(this.{name}Id, {name});\n");
        }

        public void WriteOtherParameterFunction(StringBuilder builder, string name, int baseIndent)
        {
        }
    }
}
