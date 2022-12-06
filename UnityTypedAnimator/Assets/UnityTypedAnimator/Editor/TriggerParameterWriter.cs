using System.Text;
using UnityEngine;

namespace EgoParadise.UnityTypedAnimator.Editor
{
    public class TriggerParameterWriter : IParameterWriter
    {
        public void WriteGetParameterFunction(StringBuilder builder, string name, int baseIndent, int indentStep)
        {
        }

        public void WriteSetParameterFunction(StringBuilder builder, string name, int baseIndent, int indentStep)
        {
            var indent = new string(' ', baseIndent);
            builder.Append($"{indent}public void Set{name}() => this.animator.SetTrigger(this.{name}Id);\n");
        }

        public void WriteOtherParameterFunction(StringBuilder builder, string name, int baseIndent, int indentStep)
        {
            var indent = new string(' ', baseIndent);
            builder.Append($"{indent}public void Reset{name}() => this.animator.ResetTrigger(this.{name}Id);\n");
        }
    }
}
