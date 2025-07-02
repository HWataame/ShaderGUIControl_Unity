/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
自動レイアウトを適用したステンシルの処理設定を描画するクラス

StencilOpGUILayout.cs
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
    /// 自動レイアウトを適用したステンシルの処理設定を描画するクラス
    /// </summary>
    public static class StencilOpGUILayout
    {
        /// <summary>
        /// ステンシルの処理設定を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="value">変更前の値</param>
        /// <param name="options">自動レイアウトのオプション</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StencilOp StencilOpDropdown(StencilOp value, params GUILayoutOption[] options)
        {
            // ドロップダウンを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            return StencilOpGUI.StencilOpDropdown(rect, value);
        }

        /// <summary>
        /// ステンシルの処理設定を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="value">変更前の値</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="options">自動レイアウトのオプション</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StencilOp StencilOpDropdown(StencilOp value, GUIContent label, params GUILayoutOption[] options)
        {
            // ドロップダウンを描画する
            var rect = EditorGUILayout.GetControlRect(label != null && !string.IsNullOrEmpty(label.text), options);
            return StencilOpGUI.StencilOpDropdown(rect, value, label);
        }

        /// <summary>
        /// ステンシルの処理設定を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void StencilOpDropdown(SerializedProperty property, GUIContent label, params GUILayoutOption[] options)
        {
            // ドロップダウンを描画する
            var rect = EditorGUILayout.GetControlRect(true, options);
            StencilOpGUI.StencilOpDropdown(rect, property, label);
        }

        /// <summary>
        /// ステンシルの処理設定を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void StencilOpDropdown(SerializedProperty property, params GUILayoutOption[] options)
        {
            // ドロップダウンを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            StencilOpGUI.StencilOpDropdown(rect, property);
        }

        /// <summary>
        /// ステンシルの処理設定を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void StencilOpDropdown(MaterialProperty property, GUIContent label, params GUILayoutOption[] options)
        {
            // ドロップダウンを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            StencilOpGUI.StencilOpDropdown(rect, property, label);
        }

        /// <summary>
        /// ステンシルの処理設定を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void StencilOpDropdown(MaterialProperty property, params GUILayoutOption[] options)
        {
            // ドロップダウンを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            StencilOpGUI.StencilOpDropdown(rect, property);
        }
    }
}
