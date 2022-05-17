using System.Text;
using UnityEngine;

namespace EgoParadise.UnityTypedAnimator.Editor
{
    public class BoolParameterWriter : IParameterWriter
    {
        public void WriteGetParameterFunction(StringBuilder builder, string name, int baseIndent, int indentStep)
        {
            var indent = new string(' ', baseIndent);
            builder.Append($"{indent}public bool Get{name}() => this.animator.GetBool(this.{name}Id);\n");
            
        }

        public void WriteSetParameterFunction(StringBuilder builder, string name, int baseIndent, int indentStep)
        {
            var indent = new string(' ', baseIndent);
            builder.Append($"{indent}public void Set{name}(bool {name}) => this.animator.SetBool(this.{name}Id, {name});\n");
        }

        public void WriteOtherParameterFunction(StringBuilder builder, string name, int baseIndent, int indentStep)
        {
        }
    }
}
