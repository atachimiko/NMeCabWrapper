NMeCabWrapper
============================

NMeCab(形態素解析エンジンMeCabの.NET版)のDLLを動的に読み込んで
処理を呼び出すためのラッパーライブラリです。

Requirements
------------
# VisualSutdio2012
# .NET Framework 4 / 4.5
# [impromptu-interface](https://github.com/ekonbenefits/impromptu-interface)

Build
------------
impromptu-interfaceライブラリを使用しています。
NuGetからimpromptu-interfaceのパッケージを取得してください。

Sample
------------
別途、下記のリンクよりNMeCabのランタイムライブラリと形態素解析に必要な辞書を用意します。
形態素解析に必要な辞書についてはNMeCabの配布パッケージにipadic辞書ファイルが同梱しております。(確認 2014/1/20)

```c#
static void Main(string[] args)
{
	string dllPath = Path.Combine(@"C:\NMeCab\Lib", "LibNMeCab.dll");
	var manager = new NMeCabManager(dllPath);
	
	IMeCabParam param = manager.CreateMeCabParam();
	param.DicDir = @"C:\NMeCab\ipadic"; // ← ipadicの辞書ファイルまでのパス
	
	using(IMeCabTagger tagger = n.CreateMeCabTagger(param))
	{
		var parsed = trigger.Parse(@"仰げば　尊し　我が師の恩
教の庭にも　はや幾年
思えば　いと疾し　この年月
今こそ　別れめ　いざさらば");

		Console.WriteLine(parsed);
	}
}
```

関連情報
--------
[NMeCab(形態素解析エンジンMeCabの.NET版)](http://sourceforge.jp/projects/nmecab/)


ライセンス(LICENSE)
--------
Copyright (c) 2014, atachimiko
All rights reserved.

Redistribution and use in source and binary forms, with or without modification,
are permitted provided that the following conditions are met:

* Redistributions of source code must retain the above copyright notice, this
  list of conditions and the following disclaimer.

* Redistributions in binary form must reproduce the above copyright notice, this
  list of conditions and the following disclaimer in the documentation and/or
  other materials provided with the distribution.

* Neither the name of the atachimiko nor the names of its
  contributors may be used to endorse or promote products derived from
  this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR
ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON
ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
