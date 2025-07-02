/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
自動レイアウトを適用したステンシル用のマスクを描画するクラス

StencilMaskGUILayout.cs
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
    /// 自動レイアウトを適用したステンシル用のマスクを描画するクラス
    /// </summary>
    public static class StencilMaskGUILayout
    {
        /// <summary>
        /// ステンシル用のマスクを設定するボタン群のコントロールを描画する
        /// </summary>
        /// <param name="value">変更前の値</param>
        /// <param name="options">自動レイアウトのオプション</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte StencilMaskField(byte value, params GUILayoutOption[] options)
        {
            // ステンシル用のマスクのコントロールを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            return StencilMaskGUI.StencilMaskField(rect, value);
        }

        /// <summary>
        /// ステンシル用のマスクを設定するボタン群のコントロールを描画する
        /// </summary>
        /// <param name="value">変更前の値</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="options">自動レイアウトのオプション</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte StencilMaskField(byte value, GUIContent label, params GUILayoutOption[] options)
        {
            // ステンシル用のマスクのコントロールを描画する
            var rect = EditorGUILayout.GetControlRect(label != null && !string.IsNullOrEmpty(label.text), options);
            return StencilMaskGUI.StencilMaskField(rect, value, label);
        }

        /// <summary>
        /// ステンシル用のマスクを設定するボタン群のコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void StencilMaskField(SerializedProperty property, GUIContent label, params GUILayoutOption[] options)
        {
            // ステンシル用のマスクのコントロールを描画する
            var rect = EditorGUILayout.GetControlRect(true, options);
            StencilMaskGUI.StencilMaskField(rect, property, label);
        }

        /// <summary>
        /// ステンシル用のマスクを設定するボタン群のコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void StencilMaskField(SerializedProperty property, params GUILayoutOption[] options)
        {
            // ステンシル用のマスクのコントロールを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            StencilMaskGUI.StencilMaskField(rect, property);
        }

        /// <summary>
        /// ステンシル用のマスクを設定するボタン群のコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void StencilMaskField(MaterialProperty property, GUIContent label, params GUILayoutOption[] options)
        {
            // ステンシル用のマスクのコントロールを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            StencilMaskGUI.StencilMaskField(rect, property, label);
        }

        /// <summary>
        /// ステンシル用のマスクを設定するボタン群のコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void StencilMaskField(MaterialProperty property, params GUILayoutOption[] options)
        {
            // ステンシル用のマスクのコントロールを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            StencilMaskGUI.StencilMaskField(rect, property);
        }
    }
}
