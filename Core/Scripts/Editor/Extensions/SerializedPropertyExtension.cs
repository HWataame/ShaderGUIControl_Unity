/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
SerializedPropertyクラスへの処理を保持するクラス

SerializedPropertyExtension.cs
────────────────────────────────────────
バージョン: 1.0.0
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
using System.Runtime.CompilerServices;
using UnityEditor;

namespace HW.ShaderDropdown.Editor.Extensions
{
    /// <summary>
    /// SerializedPropertyクラスへの処理を保持するクラス
    /// </summary>
    internal static class SerializedPropertyExtension
    {
        /// <summary>
        /// プロパティから整数値を取得する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="value">値</param>
        /// <returns>処理結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GetIntValue(this SerializedProperty property, out int value)
        {
            if (property == null)
            {
                // 引数がnullである場合は失敗
                value = default;
                return false;
            }

            switch (property.propertyType)
            {
                case SerializedPropertyType.Integer:
                case SerializedPropertyType.Enum:
                    // 整数値として取得する
                    value = property.intValue;
                    return true;
                case SerializedPropertyType.Float:
                    // 実数値として取得する
                    value = (int)property.floatValue;
                    return true;
                default:
                    // 非対応の型である場合は失敗
                    value = default;
                    return false;
            }
        }

        /// <summary>
        /// 整数値をプロパティに設定する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="value">値</param>
        /// <returns>処理結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SetIntValue(this SerializedProperty property, int value)
        {
            // 引数がnullである場合は失敗
            if (property == null) return false;

            switch (property.propertyType)
            {
                case SerializedPropertyType.Integer:
                case SerializedPropertyType.Enum:
                    // 整数値として代入する
                    property.intValue = value;
                    return true;
                case SerializedPropertyType.Float:
                    // 実数値として代入する
                    property.floatValue = value;
                    return true;
                default:
                    // 非対応の型である場合は失敗
                    return false;
            }
        }
    }
}
