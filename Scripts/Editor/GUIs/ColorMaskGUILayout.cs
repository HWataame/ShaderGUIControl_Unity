/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
自動レイアウトを適用したカラーマスクを描画するクラス

ColorMaskGUILayout.cs
────────────────────────────────────────
バージョン: 1.0.0
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

namespace HW.ShaderDropdown.Editor.GUIs
{
    /// <summary>
    /// 自動レイアウトを適用したカラーマスクを描画するクラス
    /// </summary>
    public static class ColorMaskGUILayout
    {
        /// <summary>
        /// 色のマスクを設定するボタン群のコントロールを描画する
        /// </summary>
        /// <param name="value">変更前の値</param>
        /// <param name="options">自動レイアウトのオプション</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ColorMaskField(byte value, params GUILayoutOption[] options)
        {
            // 色のマスクのコントロールを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            return ColorMaskGUI.ColorMaskField(rect, value);
        }

        /// <summary>
        /// 色のマスクを設定するボタン群のコントロールを描画する
        /// </summary>
        /// <param name="value">変更前の値</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="options">自動レイアウトのオプション</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ColorMaskField(byte value, GUIContent label, params GUILayoutOption[] options)
        {
            // 色のマスクのコントロールを描画する
            var rect = EditorGUILayout.GetControlRect(label != null && !string.IsNullOrEmpty(label.text), options);
            return ColorMaskGUI.ColorMaskField(rect, value, label);
        }

        /// <summary>
        /// 色のマスクを設定するボタン群のコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorMaskField(SerializedProperty property, GUIContent label, params GUILayoutOption[] options)
        {
            // 色のマスクのコントロールを描画する
            var rect = EditorGUILayout.GetControlRect(true, options);
            ColorMaskGUI.ColorMaskField(rect, property, label);
        }

        /// <summary>
        /// 色のマスクを設定するボタン群のコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorMaskField(SerializedProperty property, params GUILayoutOption[] options)
        {
            // 色のマスクのコントロールを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            ColorMaskGUI.ColorMaskField(rect, property);
        }

        /// <summary>
        /// 色のマスクを設定するボタン群のコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorMaskField(MaterialProperty property, GUIContent label, params GUILayoutOption[] options)
        {
            // 色のマスクのコントロールを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            ColorMaskGUI.ColorMaskField(rect, property, label);
        }

        /// <summary>
        /// 色のマスクを設定するボタン群のコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorMaskField(MaterialProperty property, params GUILayoutOption[] options)
        {
            // 色のマスクのコントロールを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            ColorMaskGUI.ColorMaskField(rect, property);
        }
    }
}
