using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace EgoParadise.UnityTypedAnimator.Editor
{
    public static class TypedAnimatorCodeGenerator
    {
        internal class Context
        {
            public StringBuilder builder;
            public AnimatorCodeGenConfigureAsset activeAnimator;
            public AnimatorCodeGenGlobalConfigureAsset config;
            public Dictionary<AnimatorControllerParameterType, IParameterWriter> writerTable;
            public string animatorName;
        }

        public static void Generate(AnimatorCodeGenGlobalConfigureAsset asset)
        {
            var context = new Context();

            context.builder = new StringBuilder();
            context.config = asset;
            context.writerTable = new Dictionary<AnimatorControllerParameterType, IParameterWriter>()
            {
                [AnimatorControllerParameterType.Bool] = new BoolParameterWriter(),
                [AnimatorControllerParameterType.Int] = new IntParameterWriter(),
                [AnimatorControllerParameterType.Float] = new FloatParameterWriter(),
                [AnimatorControllerParameterType.Trigger] = new TriggerParameterWriter(),
            };

            foreach (var configure in asset.configures)
            {
                context.activeAnimator = configure;
                context.animatorName = EscapeName(configure.name);
                ConstructSingle(context);
            }

            var path = $"{Application.dataPath}/{context.config.exportPath}.cs";
            var directory = Path.GetDirectoryName(path);
            Directory.CreateDirectory(directory);
            File.WriteAllText(path, context.builder.ToString());
            AssetDatabase.Refresh();
            Debug.Log($"{nameof(TypedAnimatorCodeGenerator)}: Exported Types to {path}");
        }

        public static string EscapeName(string name)
        {
            return name.Replace(" ", "").Replace("　", "");
        }

        private static StringBuilder ConstructSingle(Context context)
        {
            var builder = context.builder;
            builder.Append($"/// <auto-generated>\n" +
                           $"/// THIS (.cs) FILE IS GENERATED BY {nameof(TypedAnimatorCodeGenerator)}. DO NOT CHANGE IT.\n" +
                           $"/// </auto-generated>\n\n");
            builder.Append($"using UnityEngine;\n\n");
            
            using (builder.Block($"namespace {context.config.exportNamespace}\n{{\n", "}\n"))
            {
                WriteClass(context);
            }

            return builder;
        }

        private static void WriteClass(Context context)
        {
            var builder = context.builder;
            var classIndent = new string(' ', 4);
            var typeName = $"{context.config.typePrefix}{context.activeAnimator.typeName}{context.config.typeSuffix}";
            using (builder.Block($"{classIndent}class {typeName}\n{classIndent}{{\n", $"{classIndent}}}\n"))
            {
                WriteClassFieldAndConstructor(context);
                WriteParameterFunction(context);
            }
        }

        private static void WriteClassFieldAndConstructor(Context context)
        {
            var builder = context.builder;
            var classIndent = new string(' ', 8);
            var functionIndent = new string(' ', 12);
            builder.Append($"{classIndent}public readonly Animator animator = null;\n");
            foreach (var parameter in context.activeAnimator.animator.parameters)
            {
                var escapedParameterName = EscapeName(parameter.name);
                builder.Append($"{classIndent}public readonly int {escapedParameterName}Id = Animator.StringToHash(\"{parameter.name}\");\n");
            }
            foreach (var parameter in context.activeAnimator.animator.layers)
            {
                var escapedParameterName = EscapeName(parameter.name);
                builder.Append($"{classIndent}public readonly int {escapedParameterName}Id;\n");
            }
            builder.Append($"\n{classIndent}public {context.animatorName}(Animator animator)\n{classIndent}{{\n");
            builder.Append($"{functionIndent}this.animator = animator;\n");
            foreach (var parameter in context.activeAnimator.animator.layers)
            {
                var escapedParameterName = EscapeName(parameter.name);
                builder.Append($"{functionIndent}this.{escapedParameterName}Id = this.animator.GetLayerIndex(\"{parameter.name}\");\n");
            }
            builder.Append($"{classIndent}}}\n\n");
        }

        private static void WriteParameterFunction(Context context)
        {
            var builder = context.builder;
            foreach (var parameter in context.activeAnimator.animator.parameters)
            {
                var escapedParameterName = EscapeName(parameter.name);
                var writer = context.writerTable[parameter.type];
                writer.WriteGetParameterFunction(builder, escapedParameterName, 4 * 2, 4);
            }
            if(context.activeAnimator.animator.parameters.Any())
                builder.Append("\n");
            foreach (var parameter in context.activeAnimator.animator.parameters)
            {
                var escapedParameterName = EscapeName(parameter.name);
                var writer = context.writerTable[parameter.type];
                writer.WriteSetParameterFunction(builder, escapedParameterName, 4 * 2, 4);
            }

            if (context.activeAnimator.animator.parameters.Any())
                builder.Append("\n");
            foreach (var parameter in context.activeAnimator.animator.parameters)
            {
                var escapedParameterName = EscapeName(parameter.name);
                var writer = context.writerTable[parameter.type];
                writer.WriteOtherParameterFunction(builder, escapedParameterName, 4 * 2, 4);
            }

            if (context.activeAnimator.animator.layers.Any())
                builder.Append("\n");
            foreach (var parameter in context.activeAnimator.animator.layers)
            {
                var escapedParameterName = EscapeName(parameter.name);
                WriteGetLayerWeightFunction(builder, escapedParameterName, 4 * 2, 4);
            }
            if (context.activeAnimator.animator.layers.Any())
                builder.Append("\n");
            foreach (var parameter in context.activeAnimator.animator.layers)
            {
                var escapedParameterName = EscapeName(parameter.name);
                WriteSetLayerWeightFunction(builder, escapedParameterName, 4 * 2, 4);
            }
        }

        public static void WriteGetLayerWeightFunction(StringBuilder builder, string name, int baseIndent, int indentStep)
        {
            var indent = new string(' ', baseIndent);
            builder.Append($"{indent}public float Get{name}() => this.animator.GetLayerWeight(this.{name}Id);\n");
        }
        public static void WriteSetLayerWeightFunction(StringBuilder builder, string name, int baseIndent, int indentStep)
        {
            var indent = new string(' ', baseIndent);
            builder.Append($"{indent}public void Set{name}(float {name}) => this.animator.SetLayerWeight(this.{name}Id, {name});\n");
        }
    }
}