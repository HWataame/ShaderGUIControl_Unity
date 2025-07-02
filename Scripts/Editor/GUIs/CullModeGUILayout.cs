/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
自動レイアウトを適用したカリング設定を描画するクラス

CullModeGUILayout.cs
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
    /// 自動レイアウトを適用したカリング設定を描画するクラス
    /// </summary>
    public static class CullModeGUILayout
    {
        /// <summary>
        /// カリング設定を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="value">変更前の値</param>
        /// <param name="options">自動レイアウトのオプション</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CullMode CullModeDropdown(CullMode value, params GUILayoutOption[] options)
        {
            // ドロップダウンを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            return CullModeGUI.CullModeDropdown(rect, value);
        }

        /// <summary>
        /// カリング設定を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="value">変更前の値</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="options">自動レイアウトのオプション</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CullMode CullModeDropdown(CullMode value, GUIContent label, params GUILayoutOption[] options)
        {
            // ドロップダウンを描画する
            var rect = EditorGUILayout.GetControlRect(label != null && !string.IsNullOrEmpty(label.text), options);
            return CullModeGUI.CullModeDropdown(rect, value, label);
        }

        /// <summary>
        /// カリング設定を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CullModeDropdown(SerializedProperty property, GUIContent label, params GUILayoutOption[] options)
        {
            // ドロップダウンを描画する
            var rect = EditorGUILayout.GetControlRect(true, options);
            CullModeGUI.CullModeDropdown(rect, property, label);
        }

        /// <summary>
        /// カリング設定を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CullModeDropdown(SerializedProperty property, params GUILayoutOption[] options)
        {
            // ドロップダウンを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            CullModeGUI.CullModeDropdown(rect, property);
        }

        /// <summary>
        /// カリング設定を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CullModeDropdown(MaterialProperty property, GUIContent label, params GUILayoutOption[] options)
        {
            // ドロップダウンを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            CullModeGUI.CullModeDropdown(rect, property, label);
        }

        /// <summary>
        /// カリング設定を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CullModeDropdown(MaterialProperty property, params GUILayoutOption[] options)
        {
            // ドロップダウンを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            CullModeGUI.CullModeDropdown(rect, property);
        }
    }
}
