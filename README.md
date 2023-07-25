# AI Prompt Editor
ChatGPT & Google Bard Client Application.  
It supports Windows 10 and later, as well as MacOS.  

ChatGPT、Google Bard用のプロンプトエディター＆クライアントアプリです。Windows10以降、MacOSに対応。
  
## Version 1.5.0 の新機能

- [Webアプリ版](https://tmcgptd.web.app/)を新規開発し、デスクトップ版のログをクラウドで同期できるようにしました。スマホでもログを閲覧できます。（クラウド機能／Webアプリ版を利用するには、ユーザー登録、またはGoogle/Microsoft/GitHubアカウントでのログインが必要です。）
- Webアプリ版にAPIキーを設定すれば、ブラウザでもチャットが可能です。機能は最低限ですが、デスクトップ版と同じく古い会話履歴を自動的に圧縮して半永久的に会話が継続できる機能は実装しています。
- バックエンドサービスのコストの関係で、登録ユーザー数を制限する場合があります。(ローカルで使う分には今までと変わらないので、クラウドサービスが終了してもデスクトップ版のログは消えません。)
クラウド機能が不要な方は [ver 1.2.x](https://github.com/Jun-Murakami/AI_Prompt_Editor/releases/tag/v1.2.1) をご利用ください。

## 機能:  

- **縦5分割のプロンプトエディタ**  
文章を切り貼りして、長めの命令文／プロンプトを構成しやすいようになっています。送信時は自動的に結合されます。
- **Webブラウザ内臓**  
内蔵のブラウザでチャットできます。プロンプトエディタから直接文章を送信可能です。
- **ログのインポート**  
ChatGPTとBardのログをインポートできます。取り込んだ全てのログに対してテキスト全文検索が出来ます。
- **定型句プリセット機能**  
よく使う定型句を登録しておいて、エディターに挿入できます。
- **プロンプトテンプレート＆ログ**  
プロンプトのテンプレートを保存、読み込みできます。送信した文章の履歴も自動的に保存します。

> 複数のコンピューターでチャットログを同期するには、画面右上のデータベースアイコンをクリックして、データベースファイルの保存場所をクラウドドライブ（Dropboxなど）に設定してください。

API対応バージョンは[こちら](https://github.com/Jun-Murakami/AI_Prompt_Editor-2.0)

## New features in version 1.5.0 !

- A new [web app](https://tmcgptd.web.app/) version has been developed to allow logs from the desktop version to be synchronized in the cloud. You can also view the logs on your smartphone. (To use the cloud function/web app version, user registration or login via Google/Microsoft/GitHub account is required.)
- If you set an API key in the web app version, you can chat in the browser. The features are minimal, but like the desktop version, it compresses old conversation histories automatically, allowing semi-permanent continuation of conversations.
- We may limit the number of registered users because of the cost of using the backend service.
(The logs of the desktop version will not be lost even if the cloud service is terminated, since it is still the same as before for local use.)
If you do not need the cloud function, please use [ver 1.2.x](https://github.com/Jun-Murakami/AI_Prompt_Editor/releases/tag/v1.2.1).

## Features:  
  
- **Vertical 5-split text editor**  
Designed to make it easy to cut and paste text to configure prompts.
- **Built-in web browser**
Chat directly within the built-in web browser. Send messages directly from the prompt editor and use ChatGPT on Google Bard.
- **Importing logs**  
Import logs from ChatGPT/Bard and conduct full-text searches across all imported logs.
- **Preset phrase function**  
You can register frequently used phrases and insert them into the editor.
- **Prompt template & history**  
Save and load prompt templates. The history of sent messages is also automatically stored.

<img width="1194" alt="スクリーンショット 2023-06-05 03 04 32" src="https://github.com/Jun-Murakami/AI_Prompt_Editor/assets/126404131/dbe7432e-67aa-4438-a1c1-fd19d0692117">
<img width="1194" alt="スクリーンショット 2023-06-05 03 04 32" src="https://github.com/Jun-Murakami/AI_Prompt_Editor/assets/126404131/26234fc0-6447-4cf2-9761-ad979af6e726">

[AvaloniaUI](https://github.com/AvaloniaUI/Avalonia) is used for multi-platform support.

More information (japanese) : お知らせや詳細な解説などはnoteで書いてこうと思います。

https://note.com/junmurakami

by Jun Murakami
