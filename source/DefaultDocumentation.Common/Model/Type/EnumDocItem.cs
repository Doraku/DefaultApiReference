﻿using System.Text;
using System.Xml.Linq;
using ICSharpCode.Decompiler.CSharp.OutputVisitor;
using ICSharpCode.Decompiler.Output;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model.Type
{
    internal sealed class EnumDocItem : TypeDocItem
    {
        new public static readonly CSharpAmbience CodeAmbience = new()
        {
            ConversionFlags =
                ConversionFlags.ShowAccessibility
                | ConversionFlags.ShowDeclaringType
                | ConversionFlags.ShowDefinitionKeyword
                | ConversionFlags.ShowModifiers
                | ConversionFlags.ShowTypeParameterList
                | ConversionFlags.ShowTypeParameterVarianceModifier
        };

        public override GeneratedPages Page => GeneratedPages.Enums;

        public EnumDocItem(DocItem parent, ITypeDefinition type, XElement documentation)
            : base(parent, type, documentation)
        { }

        public override void WriteDefinition(StringBuilder builder)
        {
            builder.AppendLine(CodeAmbience.ConvertSymbol(Type));
            IType enumType = Type.GetEnumUnderlyingType();
            builder.AppendLine(enumType.IsKnownType(KnownTypeCode.Int32) ? string.Empty : " : " + enumType.FullName);
        }
    }
}
