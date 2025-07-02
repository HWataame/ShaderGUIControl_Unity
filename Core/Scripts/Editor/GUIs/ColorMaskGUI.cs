/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
カラーマスクを描画するクラス

ColorMaskGUI.cs
────────────────────────────────────────
バージョン: 1.0.0
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
using HW.GUIScopes;
using HW.ShaderDropdown.Editor.Extensions;
using System;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
#pragma warning disable IDE0063

namespace HW.ShaderDropdown.Editor.GUIs
{
    /// <summary>
    /// カラーマスクを描画するクラス
    /// </summary>
    public static class ColorMaskGUI
    {
        /// <summary>
        /// カラーマスクのボタンの文字列
        /// </summary>
        private static readonly string[] ColorMaskButtonText = new string[]
        {
            "A", "B", "G", "R"
        };


        /// <summary>
        /// 色のマスクを設定するボタン群のコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="value">変更前の値</param>
        /// <param name="label">左側のラベル</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ColorMaskField(Rect rect, byte value, GUIContent label)
        {
            // ラベルが指定されていない場合はラベルなし版の処理を実行する
            if (label == null) return ColorMaskField(rect, value);

            Rect currentRect = rect;
            if (label != null)
            {
                // ラベルの幅を取得する
                float labelWidth = EditorGUIUtility.labelWidth;

                // ラベルを描画する
                currentRect.width = labelWidth - 2;
                EditorGUI.LabelField(currentRect, label);

                // 範囲を調整する
                currentRect.x += labelWidth + 2;
                currentRect.xMax = rect.xMax;
            }

            // GUIを描画する
            return ColorMaskField(currentRect, value);
        }

        /// <summary>
        /// 色のマスクを設定するボタン群のコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="value">変更前の値</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ColorMaskField(Rect rect, byte value)
        {
            // 範囲を計算する
            const float ValueFieldWidth = 64;
            var currentRect = rect;
            currentRect.width = MathF.Ceiling((rect.width - ValueFieldWidth - 8) / 4);

            bool isMixed = EditorGUI.showMixedValue;
            int newValue = value;
            using (var change = new EditorGUI.ChangeCheckScope())
            {
                var buttonStyle = GUI.skin.button;
                ReadOnlySpan<string> buttonTexts = ColorMaskButtonText;
                for (int i = 3; i >= 0; --i)
                {
                    // ボタンを描画する
                    int flagValue = 1 << i;
                    newValue &= ~flagValue;
                    if (GUI.Toggle(currentRect, !isMixed && (value & flagValue) != 0, buttonTexts[i], buttonStyle))
                    {
                        // ボタンがONの状態であればフラグを適用する
                        newValue |= flagValue;
                    }

                    currentRect.x += currentRect.width + 2;
                }

                // 変更があった場合は反映する
                if (change.changed) value = (byte)(newValue & 0x0f);
            }

            using (var change = new MixedChangeCheckScope(isMixed))
            {
                // 数値入力欄を描画する
                currentRect.xMin = rect.xMax - ValueFieldWidth;
                currentRect.xMax = rect.xMax;
                newValue = Math.Clamp(EditorGUI.IntField(currentRect, value), 0, 15);

                // 変更があった場合は反映する
                if (change.IsChanged) value = (byte)newValue;
            }

            return value;
        }

        /// <summary>
        /// 色のマスクを設定するボタン群のコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorMaskField(Rect rect, SerializedProperty property, GUIContent label)
        {
            if (property.GetIntValue(out var value))
            {
                // プロパティから値を取得できた場合
                using (new EditorGUI.PropertyScope(rect, label, property))
                {
                    using (var change = MixedChangeCheckScope.BeginScope(property))
                    {
                        // 選択GUIを描画する
                        if (label != null)
                        {
                            // ラベルが指定された場合
                            value = ColorMaskField(rect, (byte)value, label);
                        }
                        else
                        {
                            // ラベルが指定されていない場合
                            value = ColorMaskField(rect, (byte)value);
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
        /// 色のマスクを設定するボタン群のコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="property">プロパティ</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorMaskField(Rect rect, SerializedProperty property)
        {
            ColorMaskField(rect, property, null);
        }

        /// <summary>
        /// 色のマスクを設定するボタン群のコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorMaskField(Rect rect, MaterialProperty property, GUIContent label)
        {
            if (property.GetIntValue(out var intValue))
            {
                // プロパティから値を取得できた場合
                byte value = (byte)intValue;
                using (var change = MixedChangeCheckScope.BeginScope(property))
                {
                    // 選択GUIを描画する
                    if (label != null)
                    {
                        // ラベルが指定されている場合
                        value = ColorMaskField(rect, value, label);
                    }
                    else
                    {
                        // ラベルが指定されていない場合
                        value = ColorMaskField(rect, value);
                    }

                    // 変更された場合は変更を反映する
                    if (change.IsChanged) property.SetIntValue((int)value);
                }
            }
            else
            {
                // プロパティが非対応の型の場合は何もしない
                EditorGUI.HelpBox(rect, $"プロパティ「{label.text}」の値を数値として解釈できません", MessageType.Error);
            }
        }

        /// <summary>
        /// 色のマスクを設定するボタン群のコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="property">プロパティ</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorMaskField(Rect rect, MaterialProperty property)
        {
            ColorMaskField(rect, property, null);
        }
    }
}
