/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
ブレンドモード設定を描画するクラス

BlendModeGUI.cs
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
    /// ブレンドモード設定を描画するクラス
    /// </summary>
    public static class BlendModeGUI
    {
        /// <summary>
        /// ブレンドモードを選択するドロップダウンの選択用の表示
        /// </summary>
        private static readonly GUIContent[] BlendModeTexts = new GUIContent[]
        {
            new("使用しない(Zero)"),
            new("そのまま使用する(One)"),
            new("描画する色を乗算する(SrcColor)"),
            new("描画する色のアルファ値を乗算する(SrcAlpha)"),
            new("描画前の色を乗算する(DstColor)"),
            new("描画前の色のアルファ値を乗算する(DstAlpha)"),
            new("(1 - 描画する色)を乗算する(OneMinusSrcColor)"),
            new("(1 - 描画する色のアルファ値)を乗算する(OneMinusSrcAlpha)"),
            new("(1 - 描画前の色)を乗算する(OneMinusDstColor)"),
            new("(1 - 描画前の色のアルファ値)を乗算する(OneMinusDstAlpha)"),
            new("描画する色のアルファ値と(1 - 描画前の色のアルファ値)のうち小さな値を乗算する(SrcAlphaSaturate)"),
        };

        /// <summary>
        /// ブレンドモードを選択するドロップダウンの選択用の値
        /// </summary>
        private static readonly int[] BlendModeValues = new[]
        {
            (int)BlendMode.Zero,
            (int)BlendMode.One,
            (int)BlendMode.SrcColor,
            (int)BlendMode.SrcAlpha,
            (int)BlendMode.DstColor,
            (int)BlendMode.DstAlpha,
            (int)BlendMode.OneMinusSrcColor,
            (int)BlendMode.OneMinusSrcAlpha,
            (int)BlendMode.OneMinusDstColor,
            (int)BlendMode.OneMinusDstAlpha,
            (int)BlendMode.SrcAlphaSaturate,
        };


        /// <summary>
        /// ブレンドモードを選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="value">変更前の値</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BlendMode BlendModeDropdown(Rect rect, BlendMode value)
        {
            // ドロップダウンを描画する
            return (BlendMode)EditorGUI.IntPopup(rect, (int)value, BlendModeTexts, BlendModeValues);
        }

        /// <summary>
        /// ブレンドモードを選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="value">変更前の値</param>
        /// <param name="label">左側のラベル</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BlendMode BlendModeDropdown(Rect rect, BlendMode value, GUIContent label)
        {
            // ドロップダウンを描画する
            return (BlendMode)EditorGUI.IntPopup(rect, label, (int)value, BlendModeTexts, BlendModeValues);
        }

        /// <summary>
        /// ブレンドモードを選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BlendModeDropdown(Rect rect, SerializedProperty property, GUIContent label)
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
                            value = (int)BlendModeDropdown(rect, (BlendMode)value, label);
                        }
                        else
                        {
                            // ラベルが指定されていない場合
                            value = (int)BlendModeDropdown(rect, (BlendMode)value);
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
        /// ブレンドモードを選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="property">プロパティ</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BlendModeDropdown(Rect rect, SerializedProperty property)
        {
            BlendModeDropdown(rect, property, null);
        }

        /// <summary>
        /// ブレンドモードを選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BlendModeDropdown(Rect rect, MaterialProperty property, GUIContent label)
        {
            // プロパティが対応しない型の場合は既定値を仮代入する
            if (property.GetEnumValue(out BlendMode value))
            {
                using (var change = MixedChangeCheckScope.BeginScope(property))
                {
                    // BlendModeのドロップダウンを描画する
                    if (label != null)
                    {
                        // ラベルが指定されている場合
                        value = BlendModeDropdown(rect, value, label);
                    }
                    else
                    {
                        // ラベルが指定されていない場合
                        value = BlendModeDropdown(rect, value);
                    }

                    // 変更された場合は変更を反映する
                    if (change.IsChanged) property.SetIntValue((int)value);
                }
            }
            else
            {
                // プロパティが非対応の型の場合は何もしない
                EditorGUI.HelpBox(rect, $"プロパティ「{label.text}」の値をBlendModeとして解釈できません", MessageType.Error);
            }
        }

        /// <summary>
        /// ブレンドモードを選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="property">プロパティ</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BlendModeDropdown(Rect rect, MaterialProperty property)
        {
            BlendModeDropdown(rect, property, null);
        }
    }
}
