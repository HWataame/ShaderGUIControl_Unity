/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
カリング設定を描画するクラス

CullModeGUI.cs
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
    /// カリング設定を描画するクラス
    /// </summary>
    public static class CullModeGUI
    {
        /// <summary>
        /// カリング設定を選択するドロップダウンの選択用の表示
        /// </summary>
        private static readonly GUIContent[] CullModeTexts = new GUIContent[]
        {
            new("両面とも描画する(カリングしない・Off)"),
            new("表面のみ描画する(裏面をカリングする・Back)"),
            new("裏面のみ描画する(表面をカリングする・Front)")
        };

        /// <summary>
        /// カリング設定を選択するドロップダウンの選択用の値
        /// </summary>
        private static readonly int[] CullModeValues = new[]
        {
            (int)CullMode.Off,
            (int)CullMode.Back,
            (int)CullMode.Front
        };


        /// <summary>
        /// カリング設定を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="value">変更前の値</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CullMode CullModeDropdown(Rect rect, CullMode value)
        {
            // ドロップダウンを描画する
            return (CullMode)EditorGUI.IntPopup(rect, (int)value, CullModeTexts, CullModeValues);
        }

        /// <summary>
        /// カリング設定を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="value">変更前の値</param>
        /// <param name="label">左側のラベル</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CullMode CullModeDropdown(Rect rect, CullMode value, GUIContent label)
        {
            // ドロップダウンを描画する
            return (CullMode)EditorGUI.IntPopup(rect, label, (int)value, CullModeTexts, CullModeValues);
        }

        /// <summary>
        /// カリング設定を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CullModeDropdown(Rect rect, SerializedProperty property, GUIContent label)
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
                            value = (int)CullModeDropdown(rect, (CullMode)value, label);
                        }
                        else
                        {
                            // ラベルが指定されていない場合
                            value = (int)CullModeDropdown(rect, (CullMode)value);
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
        /// カリング設定を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="property">プロパティ</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CullModeDropdown(Rect rect, SerializedProperty property)
        {
            CullModeDropdown(rect, property, null);
        }

        /// <summary>
        /// カリング設定を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CullModeDropdown(Rect rect, MaterialProperty property, GUIContent label)
        {
            // プロパティが対応しない型の場合は既定値を仮代入する
            if (property.GetEnumValue(out CullMode value))
            {
                using (var change = MixedChangeCheckScope.BeginScope(property))
                {
                    // BlendModeのドロップダウンを描画する
                    if (label != null)
                    {
                        // ラベルが指定されている場合
                        value = CullModeDropdown(rect, value, label);
                    }
                    else
                    {
                        // ラベルが指定されていない場合
                        value = CullModeDropdown(rect, value);
                    }

                    // 変更された場合は変更を反映する
                    if (change.IsChanged) property.SetIntValue((int)value);
                }
            }
            else
            {
                // プロパティが非対応の型の場合は何もしない
                EditorGUI.HelpBox(rect, $"プロパティ「{label.text}」の値をCullModeとして解釈できません", MessageType.Error);
            }
        }

        /// <summary>
        /// カリング設定を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="property">プロパティ</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CullModeDropdown(Rect rect, MaterialProperty property)
        {
            CullModeDropdown(rect, property, null);
        }
    }
}
