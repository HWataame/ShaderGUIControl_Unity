/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
自動レイアウトを適用した比較方式設定を描画するクラス

CompareFunctionGUILayout.cs
────────────────────────────────────────
バージョン: 1.0.0
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

namespace HW.ShaderDropdown.Editor.GUIs
{
    /// <summary>
    /// 自動レイアウトを適用した比較方式設定を描画するクラス
    /// </summary>
    public static class CompareFunctionGUILayout
    {
        /// <summary>
        /// 比較方式を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="value">変更前の値</param>
        /// <param name="options">自動レイアウトのオプション</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CompareFunction CompareFunctionDropdown(CompareFunction value, params GUILayoutOption[] options)
        {
            // ドロップダウンを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            return CompareFunctionGUI.CompareFunctionDropdown(rect, value);
        }

        /// <summary>
        /// 比較方式を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="value">変更前の値</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="options">自動レイアウトのオプション</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CompareFunction CompareFunctionDropdown(CompareFunction value, GUIContent label, params GUILayoutOption[] options)
        {
            // ドロップダウンを描画する
            var rect = EditorGUILayout.GetControlRect(label != null && !string.IsNullOrEmpty(label.text), options);
            return CompareFunctionGUI.CompareFunctionDropdown(rect, value, label);
        }

        /// <summary>
        /// 比較方式を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CompareFunctionDropdown(SerializedProperty property, GUIContent label, params GUILayoutOption[] options)
        {
            // ドロップダウンを描画する
            var rect = EditorGUILayout.GetControlRect(true, options);
            CompareFunctionGUI.CompareFunctionDropdown(rect, property, label);
        }

        /// <summary>
        /// 比較方式を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CompareFunctionDropdown(SerializedProperty property, params GUILayoutOption[] options)
        {
            // ドロップダウンを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            CompareFunctionGUI.CompareFunctionDropdown(rect, property);
        }

        /// <summary>
        /// 比較方式を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CompareFunctionDropdown(MaterialProperty property, GUIContent label, params GUILayoutOption[] options)
        {
            // ドロップダウンを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            CompareFunctionGUI.CompareFunctionDropdown(rect, property, label);
        }

        /// <summary>
        /// 比較方式を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CompareFunctionDropdown(MaterialProperty property, params GUILayoutOption[] options)
        {
            // ドロップダウンを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            CompareFunctionGUI.CompareFunctionDropdown(rect, property);
        }
    }
}
