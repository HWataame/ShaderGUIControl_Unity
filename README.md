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
1. Gitをインストールする
2. 追加したいプロジェクトを開き、Package Managerを開く
3. 以下の文字列をコピー、またはこのページ上部の「<> Code」からClone URLをコピーする

    https://github.com/HWataame/ShaderGUIControl_Unity.git
4. 「Package Manager」ウィンドウの左上の「＋」ボタンをクリックし、「Install package from git URL...」を選択する

    ![導入方法01](https://github.com/user-attachments/assets/6b334a95-a1dd-4063-9cb2-b6d1f81cd6cc)
5. 入力欄に手順2でコピーしたURLを貼り付け、「Install」ボタンを押す

    ![導入方法02](https://github.com/user-attachments/assets/de46ab93-bd78-4786-9e29-4477de68fb97)
6. (必要に応じて)Assembly Definition Assetの管理下のエディターコードで利用する場合は、`HW.ShaderGUIControl.Editor`をAssembly Definition Referencesに追加する

    ![導入方法03(必要に応じて)](https://github.com/user-attachments/assets/17165e76-ec45-478c-a0e3-f21f88099bc5)



## How to introduction / 日本語の「導入方法」は上にあります
1. Install Git to your computer.
2. Open Package Manager in the Unity project to which you want to add this feature.
3. Copy the following string, or copy the Clone URL from "<> Code" at the top of this page

    https://github.com/HWataame/ShaderGUIControl_Unity.git
4. Click the "+" button in the "Package Manager" window and select "Install package from git URL...".

    ![導入方法01](https://github.com/user-attachments/assets/6b334a95-a1dd-4063-9cb2-b6d1f81cd6cc)
5. Paste the URL copied in Step 2 into the input field and press the "Install" button.

    ![導入方法02](https://github.com/user-attachments/assets/de46ab93-bd78-4786-9e29-4477de68fb97)
6. (If necessary) For use in editor code under the control of Assembly Definition Asset...

   Add `HW.ShaderGUIControl.Editor` to "Assembly Definition References" in your Assembly Definition Asset.

    ![導入方法03(必要に応じて)](https://github.com/user-attachments/assets/17165e76-ec45-478c-a0e3-f21f88099bc5)

## ライセンス / License
MITライセンスです / Using "MIT license"

[LISENCE](/LICENSE)

## 依存するパッケージ(リポジトリ) / Dependencies
[GUI Scopes for UnityEditor](https://github.com/HWataame/GUIScopeUtil_Unity)

[LibEnumGenerics for Unity](https://github.com/HWataame/LibEnumGenerics_Unity)

