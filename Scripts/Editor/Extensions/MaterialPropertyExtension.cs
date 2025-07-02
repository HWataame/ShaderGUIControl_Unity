/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
MaterialPropertyクラスへの処理を保持するクラス

MaterialPropertyExtension.cs
────────────────────────────────────────
バージョン: 1.0.0
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
using System;
using System.Runtime.CompilerServices;
using UnityEditor;

namespace HW.ShaderDropdown.Editor.Extensions
{
    /// <summary>
    /// MaterialPropertyクラスへの処理を保持するクラス
    /// </summary>
    internal static class MaterialPropertyExtension
    {
        /// <summary>
        /// マテリアルのプロパティから列挙型の値を取得する
        /// </summary>
        /// <typeparam name="T">取得する値の列挙型</typeparam>
        /// <param name="property">プロパティ</param>
        /// <param name="value">取得された値</param>
        /// <returns>処理結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GetEnumValue<T>(this MaterialProperty property, out T value) where T : unmanaged, Enum
        {
            if (property == null)
            {
                // プロパティがnullである場合は失敗
                value = default;
                return false;
            }

            switch (property.type)
            {
                case MaterialProperty.PropType.Float:
                case MaterialProperty.PropType.Range:
                    // 実数型である場合
                    value = Enum<T>.ToEnum(property.floatValue);
                    return true;
                case MaterialProperty.PropType.Int:
                    // 整数型である場合
                    value = Enum<T>.ToEnum(property.intValue);
                    return true;
                default:
                    // 非対応の型である場合は失敗
                    value = default;
                    return false;
            }
        }

        /// <summary>
        /// マテリアルのプロパティから整数値を取得する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="value">設定する値</param>
        /// <returns>処理結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GetIntValue(this MaterialProperty property, out int value)
        {
            if (property == null)
            {
                // プロパティがnullである場合は失敗
                value = default;
                return false;
            }

            switch (property.type)
            {
                case MaterialProperty.PropType.Float:
                case MaterialProperty.PropType.Range:
                    // 実数値として取得する
                    value = (int)property.floatValue;
                    return true;
                case MaterialProperty.PropType.Int:
                    // 整数値として取得する
                    value = property.intValue;
                    return true;
                default:
                    // 非対応の型である場合は失敗
                    value = default;
                    return false;
            }
        }

        /// <summary>
        /// マテリアルのプロパティに整数値を設定する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="value">設定する値</param>
        /// <returns>処理結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SetIntValue(this MaterialProperty property, int value)
        {
            // プロパティがnullである場合は失敗
            if (property == null) return false;

            switch (property.type)
            {
                case MaterialProperty.PropType.Float:
                case MaterialProperty.PropType.Range:
                    // 実数値として代入する
                    property.floatValue = value;
                    return true;
                case MaterialProperty.PropType.Int:
                    // 整数値として代入する
                    property.intValue = value;
                    return true;
                default:
                    // 非対応の型である場合は失敗
                    return false;
            }
        }
    }
}
