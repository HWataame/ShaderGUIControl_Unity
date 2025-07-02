/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
ステンシルの処理設定を描画するクラス

StencilOpGUI.cs
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
    /// ステンシルの処理設定を描画するクラス
    /// </summary>
    public static class StencilOpGUI
    {
        /// <summary>
        /// ステンシルの処理設定を選択するドロップダウンの選択用の表示
        /// </summary>
        private static readonly GUIContent[] StencilOpTexts = new GUIContent[]
        {
            new("何もしない(Keep)"),
            new("0を書き込む(Zero)"),
            new("参照値を書き込む(Replace)"),
            new("ビットを反転させる(Invert)"),
            new("バッファの値を増やす(255の次は255)(IncrSat)"),
            new("バッファの値を増やす(255の次は0)(IncrWrap)"),
            new("バッファの値を減らす(0の次は0)(DecrSat)"),
            new("バッファの値を減らす(0の次は255)(DecrWrap)")
        };

        /// <summary>
        /// ステンシルの処理設定を選択するドロップダウンの選択用の値
        /// </summary>
        private static readonly int[] StencilOpValues = new[]
        {
            (int)StencilOp.Keep,
            (int)StencilOp.Zero,
            (int)StencilOp.Replace,
            (int)StencilOp.IncrementSaturate,
            (int)StencilOp.DecrementSaturate,
            (int)StencilOp.Invert,
            (int)StencilOp.IncrementWrap,
            (int)StencilOp.DecrementWrap
        };


        /// <summary>
        /// ステンシルの処理設定を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="value">変更前の値</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StencilOp StencilOpDropdown(Rect rect, StencilOp value)
        {
            // ドロップダウンを描画する
            return (StencilOp)EditorGUI.IntPopup(rect, (int)value, StencilOpTexts, StencilOpValues);
        }

        /// <summary>
        /// ステンシルの処理設定を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="value">変更前の値</param>
        /// <param name="label">左側のラベル</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StencilOp StencilOpDropdown(Rect rect, StencilOp value, GUIContent label)
        {
            // ドロップダウンを描画する
            return (StencilOp)EditorGUI.IntPopup(rect, label, (int)value, StencilOpTexts, StencilOpValues);
        }

        /// <summary>
        /// ステンシルの処理設定を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void StencilOpDropdown(Rect rect, SerializedProperty property, GUIContent label)
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
                            value = (int)StencilOpDropdown(rect, (StencilOp)value, label);
                        }
                        else
                        {
                            // ラベルが指定されていない場合
                            value = (int)StencilOpDropdown(rect, (StencilOp)value);
                        }

                        // 変更された場合は変更を反映する
                        if (change.IsChanged) property.SetIntValue(value);
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
        /// ステンシルの処理設定を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="property">プロパティ</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void StencilOpDropdown(Rect rect, SerializedProperty property)
        {
            StencilOpDropdown(rect, property, null);
        }

        /// <summary>
        /// ステンシルの処理設定を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void StencilOpDropdown(Rect rect, MaterialProperty property, GUIContent label)
        {
            // プロパティが対応しない型の場合は既定値を仮代入する
            if (property.GetEnumValue(out StencilOp value))
            {
                using (var change = MixedChangeCheckScope.BeginScope(property))
                {
                    // BlendModeのドロップダウンを描画する
                    if (label != null)
                    {
                        // ラベルが指定されている場合
                        value = StencilOpDropdown(rect, value, label);
                    }
                    else
                    {
                        // ラベルが指定されていない場合
                        value = StencilOpDropdown(rect, value);
                    }

                    // 変更された場合は変更を反映する
                    if (change.IsChanged) property.SetIntValue((int)value);
                }
            }
            else
            {
                // プロパティが非対応の型の場合は何もしない
                EditorGUI.HelpBox(rect, $"プロパティ「{label.text}」の値をStencilOpとして解釈できません", MessageType.Error);
            }
        }

        /// <summary>
        /// ステンシルの処理設定を選択するドロップダウンのコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="property">プロパティ</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void StencilOpDropdown(Rect rect, MaterialProperty property)
        {
            StencilOpDropdown(rect, property, null);
        }
    }
}
