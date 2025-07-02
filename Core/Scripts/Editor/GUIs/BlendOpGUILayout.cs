/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
自動レイアウトを適用したブレンド処理設定を描画するクラス

BlendOpGUILayout.cs
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
    /// 自動レイアウトを適用したブレンド処理設定を描画するクラス
    /// </summary>
    public static class BlendOpGUILayout
    {
        /// <summary>
        /// ブレンド処理を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="value">変更前の値</param>
        /// <param name="options">自動レイアウトのオプション</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BlendOp BlendOpDropdown(BlendOp value, params GUILayoutOption[] options)
        {
            // ドロップダウンを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            return BlendOpGUI.BlendOpDropdown(rect, value);
        }

        /// <summary>
        /// ブレンド処理を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="value">変更前の値</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="options">自動レイアウトのオプション</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BlendOp BlendOpDropdown(BlendOp value, GUIContent label, params GUILayoutOption[] options)
        {
            // ドロップダウンを描画する
            var rect = EditorGUILayout.GetControlRect(label != null && !string.IsNullOrEmpty(label.text), options);
            return BlendOpGUI.BlendOpDropdown(rect, value, label);
        }

        /// <summary>
        /// ブレンド処理を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BlendOpDropdown(SerializedProperty property, GUIContent label, params GUILayoutOption[] options)
        {
            // ドロップダウンを描画する
            var rect = EditorGUILayout.GetControlRect(true, options);
            BlendOpGUI.BlendOpDropdown(rect, property, label);
        }

        /// <summary>
        /// ブレンド処理を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BlendOpDropdown(SerializedProperty property, params GUILayoutOption[] options)
        {
            // ドロップダウンを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            BlendOpGUI.BlendOpDropdown(rect, property);
        }

        /// <summary>
        /// ブレンド処理を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BlendOpDropdown(MaterialProperty property, GUIContent label, params GUILayoutOption[] options)
        {
            // ドロップダウンを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            BlendOpGUI.BlendOpDropdown(rect, property, label);
        }

        /// <summary>
        /// ブレンド処理を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BlendOpDropdown(MaterialProperty property, params GUILayoutOption[] options)
        {
            // ドロップダウンを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            BlendOpGUI.BlendOpDropdown(rect, property);
        }
    }
}
