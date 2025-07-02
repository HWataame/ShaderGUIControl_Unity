/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
リポジトリのテーブル

GitRepositoryTable.cs
────────────────────────────────────────
バージョン: 1.0.0
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HW.GitPackageInstaller.Core.Data
{
    /// <summary>
    /// リポジトリのテーブル
    /// </summary>
    [Serializable]
    [CreateAssetMenu(menuName = "HW.GitPackageInstaller/Repository Table", fileName = "repotbl")]
    internal class GitRepositoryTable : ScriptableObject, IEnumerable<GitRepositoryRecord>
    {
        /// <summary>
        /// リポジトリデータ
        /// </summary>
        [SerializeField]
        private GitRepositoryRecord[] records = new GitRepositoryRecord[0];


        /// <summary>
        /// 列挙子を取得する
        /// </summary>
        /// <returns>列挙子</returns>
        public IEnumerator<GitRepositoryRecord> GetEnumerator()
        {
            return (records as IEnumerable<GitRepositoryRecord>)?.GetEnumerator();
        }

        /// <summary>
        /// 列挙子を取得する
        /// </summary>
        /// <returns>列挙子</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
