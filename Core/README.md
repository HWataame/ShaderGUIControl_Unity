# Shader GUI Control
![トップ画像](https://github.com/user-attachments/assets/b39c47f4-4552-4409-9905-c5bb8200f274)

## 概要
マテリアルのインスペクターやエディター上にシェーダー機能系の設定を容易にするGUIコントロールを追加します

## 使用方法 / Usage
シェーダーのプロパティに以下のような属性を付与すると、プロパティのインスペクター上の表示が変化します

以下のように記述すると、トップ画像のような表示になります
```shaderlab
[CullModeDropdown]
_Cull           ("描画する面", float) = 2

[BlendModeDropdown]
_Blend          ("ブレンドモード", float) = 1

[BlendOpDropdown]
_BlendOp        ("色のブレンド処理", float) = 0

[CompareFunctionDropdown]
_ZTest          ("深度の比較方式", float) = 4

[StencilMaskField]
_Stencil        ("ステンシルの値", float) = 0

[ColorMaskField]
_ColorMask      ("カラーマスク", float) = 15

[StencilOpDropdown]
_StencilOp      ("ステンシルの処理", float) = 0
```
また、EditorWindowやインスペクター用にGUIコントロール単体で利用できたり、マテリアルを複数選択した時の表示にも対応しています

## 導入方法 / English "How to introduction" is below this
1. (必要に応じて)Assembly Definition Assetの管理下のエディターコードで利用する場合は、`HW.ShaderGUIControl.Editor`をAssembly Definition Referencesに追加する

    ![導入方法03(必要に応じて)](https://github.com/user-attachments/assets/17165e76-ec45-478c-a0e3-f21f88099bc5)



## How to introduction / 日本語の「導入方法」は上にあります
1. (If necessary) For use in editor code under the control of Assembly Definition Asset...

   Add `HW.ShaderGUIControl.Editor` to "Assembly Definition References" in your Assembly Definition Asset.

    ![導入方法03(必要に応じて)](https://github.com/user-attachments/assets/17165e76-ec45-478c-a0e3-f21f88099bc5)

## ライセンス / License
MITライセンスです / Using "MIT license"

[LISENCE](/LICENSE)

## 依存するパッケージ(リポジトリ) / Dependencies
[GUI Scopes for UnityEditor](https://github.com/HWataame/GUIScopeUtil_Unity)

[LibEnumGenerics for Unity](https://github.com/HWataame/LibEnumGenerics_Unity)

