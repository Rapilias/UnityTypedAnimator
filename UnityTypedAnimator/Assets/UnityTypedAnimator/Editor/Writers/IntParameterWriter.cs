using System.Text;
using UnityEngine;

namespace EgoParadise.UnityTypedAnimator.Editor
{
    public class IntParameterWriter : IParameterWriter
    {
        public void WriteGetParameterFunction(StringBuilder builder, string name, int baseIndent)
        {
            var indent = new string(' ', baseIndent);
            builder.Append($"{indent}public int Get{name}() => this.animator.GetInteger(this.{name}Id);\n");
        }

        public void WriteSetParameterFunction(StringBuilder builder, string name, int baseIndent)
        {
            var indent = new string(' ', baseIndent);
            builder.Append($"{indent}public void Set{name}(int {name}) => this.animator.SetInteger(this.{name}Id, {name});\n");
        }

        public void WriteOtherParameterFunction(StringBuilder builder, string name, int baseIndent)
        {
        }
    }
}