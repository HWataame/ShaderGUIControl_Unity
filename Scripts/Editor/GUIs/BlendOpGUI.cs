/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
ブレンド処理設定を描画するクラス

BlendOpGUI.cs
────────────────────────────────────────
バージョン: 1.0.0
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
using HW.GUIScopes;
using HW.ShaderDropdown.Editor.Extensions;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
#pragma warning disable IDE0063

namespace HW.ShaderDropdown.Editor.GUIs
{
    /// <summary>
    /// ブレンド処理設定を描画するクラス
    /// </summary>
    public static class BlendOpGUI
    {
        /// <summary>
        /// ブレンド処理を選択するドロップダウンの選択用の表示
        /// </summary>
        private static readonly GUIContent[] BlendOpTexts = new GUIContent[]
        {
            new("描画する色 + 描画前の色(Add)"),
            new("描画する色 - 描画前の色(Sub)"),
            new("描画前の色 - 描画する色(RevSub)"),
            new("描画する色と描画前の色のうち小さな方(Min)"),
            new("描画する色と描画前の色のうち大きな方(Max)"),
        };

        /// <summary>
        /// ブレンド処理を選択するドロップダウンの選択用の値
        /// </summary>
        private static readonly int[] BlendOpValues = new[]
        {
            (int)BlendOp.Add,
            (int)BlendOp.Subtract,
            (int)BlendOp.ReverseSubtract,
            (int)BlendOp.Min,
            (int)BlendOp.Max,
        };


        /// <summary>
        /// ブレンド処理を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="value">変更前の値</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BlendOp BlendOpDropdown(Rect rect, BlendOp value)
        {
            // ドロップダウンを描画する
            return (BlendOp)EditorGUI.IntPopup(rect, (int)value, BlendOpTexts, BlendOpValues);
        }

        /// <summary>
        /// ブレンド処理を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="value">変更前の値</param>
        /// <param name="label">左側のラベル</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BlendOp BlendOpDropdown(Rect rect, BlendOp value, GUIContent label)
        {
            // ドロップダウンを描画する
            return (BlendOp)EditorGUI.IntPopup(rect, label, (int)value, BlendOpTexts, BlendOpValues);
        }

        /// <summary>
        /// ブレンド処理を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BlendOpDropdown(Rect rect, SerializedProperty property, GUIContent label)
        {
            if (property.GetIntValue(out var value))
            {
                // プロパティから値を取得できた場合
                using (new EditorGUI.PropertyScope(rect, label, property))
                {
                    using (var change = MixedChangeCheckScope.BeginScope(property))
                    {
                        // ドロップダウンを描画する
                        if (label != null)
                        {
                            // ラベルが指定された場合
                            value = (int)BlendOpDropdown(rect, (BlendOp)value, label);
                        }
                        else
                        {
                            // ラベルが指定されていない場合
                            value = (int)BlendOpDropdown(rect, (BlendOp)value);
                        }

                        // 変更された場合は変更を反映する
                        if (change.IsChanged) property.intValue = value;
                    }
                }
            }
            else
            {
                // プロパティが非対応の型である場合はプロパティのみ描画する
                EditorGUI.PropertyField(rect, property, label, true);
            }
        }

        /// <summary>
        /// ブレンド処理を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="property">プロパティ</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BlendOpDropdown(Rect rect, SerializedProperty property)
        {
            BlendOpDropdown(rect, property, null);
        }

        /// <summary>
        /// ブレンド処理を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BlendOpDropdown(Rect rect, MaterialProperty property, GUIContent label)
        {
            // プロパティが対応しない型の場合は既定値を仮代入する
            if (property.GetEnumValue(out BlendOp value))
            {
                using (var change = MixedChangeCheckScope.BeginScope(property))
                {
                    // BlendModeのドロップダウンを描画する
                    if (label != null)
                    {
                        // ラベルが指定されている場合
                        value = BlendOpDropdown(rect, value, label);
                    }
                    else
                    {
                        // ラベルが指定されていない場合
                        value = BlendOpDropdown(rect, value);
                    }

                    // 変更された場合は変更を反映する
                    if (change.IsChanged) property.SetIntValue((int)value);
                }
            }
            else
            {
                // プロパティが非対応の型の場合は何もしない
                EditorGUI.HelpBox(rect, $"プロパティ「{label.text}」の値をBlendOpとして解釈できません", MessageType.Error);
            }
        }

        /// <summary>
        /// ブレンド処理を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="property">プロパティ</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BlendOpDropdown(Rect rect, MaterialProperty property)
        {
            BlendOpDropdown(rect, property, null);
        }
    }
}
