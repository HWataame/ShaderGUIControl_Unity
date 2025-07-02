/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
リポジトリのテーブルのレコード

GitRepositoryRecord.cs
────────────────────────────────────────
バージョン: 1.0.0
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace HW.GitPackageInstaller.Core.Data
{
    /// <summary>
    /// リポジトリのテーブルのレコード
    /// </summary>
    [Serializable]
    internal struct GitRepositoryRecord
    {
        /// <summary>
        /// Git URL
        /// </summary>
        [SerializeField]
        private string gitUrl;
        /// <summary>
        /// パッケージ名
        /// </summary>
        [SerializeField]
        private string packageName;
        /// <summary>
        /// GUIDを判定するアセットのパス
        /// </summary>
        [SerializeField]
        private string guidCheckPath;
        /// <summary>
        /// GUID
        /// </summary>
        [SerializeField]
        private string guid;

        /// <summary>
        /// Git URL
        /// </summary>
        public readonly string GitUrl
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => gitUrl;
        }

        /// <summary>
        /// パッケージ名
        /// </summary>
        public readonly string PackageName
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => packageName;
        }

        /// <summary>
        /// GUIDを判定するアセットのパス
        /// </summary>
        public readonly string GuidCheckPath
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => guidCheckPath;
        }

        /// <summary>
        /// GUID
        /// </summary>
        public readonly string Guid
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => guid;
        }
    }
}
