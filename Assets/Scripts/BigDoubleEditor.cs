#if UNITY_EDITOR
using BreakInfinity;
using UnityEditor;
using UnityEngine;

namespace BreakInfinity
{
    [CustomPropertyDrawer(typeof(BigDouble))]
    public class BigDoubleDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            const float gapWidth = 10;

            var mantissaRect = new Rect(position.x, position.y, (position.width - gapWidth) * 0.66f, position.height);
            var gapRect = new Rect(mantissaRect.x + mantissaRect.width, position.y, gapWidth, position.height);
            var exponentRect = new Rect(gapRect.x + gapRect.width, position.y, (position.width - gapWidth) * 0.33f, position.height);

            var mantissaProperty = property.FindPropertyRelative("mantissa");
            var exponentProperty = property.FindPropertyRelative("exponent");

            // Optional polish: Draws an 'e' in the gap between the two number boxes
            EditorGUI.LabelField(gapRect, "e", new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter });

            EditorGUI.BeginChangeCheck();

            double mantissa = EditorGUI.DoubleField(mantissaRect, mantissaProperty.doubleValue,
                new GUIStyle(EditorStyles.numberField)
                {
                    alignment = TextAnchor.MiddleCenter
                });

            long exponent = EditorGUI.LongField(exponentRect, exponentProperty.longValue,
                new GUIStyle(EditorStyles.numberField)
                {
                    alignment = TextAnchor.MiddleCenter
                });

            if (EditorGUI.EndChangeCheck())
            {
                BigDouble normalized = BigDouble.Normalize(mantissa, exponent);
                mantissaProperty.doubleValue = normalized.Mantissa;
                exponentProperty.longValue = normalized.Exponent;
            }

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }
    }
}
#endif