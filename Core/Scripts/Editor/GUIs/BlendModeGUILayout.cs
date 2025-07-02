/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
自動レイアウトを適用したブレンドモード設定を描画するクラス

BlendModeGUILayout.cs
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
    /// 自動レイアウトを適用したブレンドモード設定を描画するクラス
    /// </summary>
    public static class BlendModeGUILayout
    {
        /// <summary>
        /// ブレンドモードを選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="value">変更前の値</param>
        /// <param name="options">自動レイアウトのオプション</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BlendMode BlendModeDropdown(BlendMode value, params GUILayoutOption[] options)
        {
            // ドロップダウンを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            return BlendModeGUI.BlendModeDropdown(rect, value);
        }

        /// <summary>
        /// ブレンドモードを選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="value">変更前の値</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="options">自動レイアウトのオプション</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BlendMode BlendModeDropdown(BlendMode value, GUIContent label, params GUILayoutOption[] options)
        {
            // ドロップダウンを描画する
            var rect = EditorGUILayout.GetControlRect(label != null && !string.IsNullOrEmpty(label.text), options);
            return BlendModeGUI.BlendModeDropdown(rect, value, label);
        }

        /// <summary>
        /// ブレンドモードを選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BlendModeDropdown(SerializedProperty property, GUIContent label, params GUILayoutOption[] options)
        {
            // ドロップダウンを描画する
            var rect = EditorGUILayout.GetControlRect(true, options);
            BlendModeGUI.BlendModeDropdown(rect, property, label);
        }

        /// <summary>
        /// ブレンドモードを選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BlendModeDropdown(SerializedProperty property, params GUILayoutOption[] options)
        {
            // ドロップダウンを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            BlendModeGUI.BlendModeDropdown(rect, property);
        }

        /// <summary>
        /// ブレンドモードを選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BlendModeDropdown(MaterialProperty property, GUIContent label, params GUILayoutOption[] options)
        {
            // ドロップダウンを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            BlendModeGUI.BlendModeDropdown(rect, property, label);
        }

        /// <summary>
        /// ブレンドモードを選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BlendModeDropdown(MaterialProperty property, params GUILayoutOption[] options)
        {
            // ドロップダウンを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            BlendModeGUI.BlendModeDropdown(rect, property);
        }
    }
}
