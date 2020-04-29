# RCSE 重置版

_快照火热发行中！ 前往 Releases 页面了解更多！_

由 Avalon Edit 强力驱动，现在的 RCSE 已经支持语法高亮功能。另外，本代码被从头重写。

关于 RCSE - Remastered: 这个项目是在初期夭折的，最后选用了 WinForm 的原因是设计简单。本来想用 Ribbon 结果这个想法也夭折了。最后中规中矩的还是用了老的菜单栏设计。

| 名称     | Badge                                                        |
| -------- | ------------------------------------------------------------ |
| 构建     | ![Azure DevOps builds](https://img.shields.io/azure-devops/build/EndermanMC/3294c2da-3353-4772-aaf9-f5375d96fc9e/6?style=flat-square) |
| 协议     | ![GitHub](https://img.shields.io/github/license/RelaperCrystal/RCSE-Reloaded) |
| 当前版本 | ![GitHub release (latest by date)](https://img.shields.io/github/v/release/RelaperCrystal/RCSE-Reloaded) |

## 版本说明

快照版是下一个版本的预览版，每次修改不论大小都会有一个自己的快照版，但是大部分快照版都是不发布二进制文件的。Alpha 版是快照版之上的版本，稳定性比快照版好，通常在下一个版本的所有主要新增内容完成后发布，不再添加大功能。Beta 版是 Alpha 之上的版本，不再添加任何功能，仅做微调和 Bug 修复。发布候选是 Beta 之上的版本，不再添加任何功能，注重修复问题。其后便是正式版，为了修复 bug 通常会有正式版之后的小版本。

一个版本的所有预览版本共享一个分支，在正式发布后与 master 合并并且移除该预览分支。

## 安装程序

安装程序使用 Inno Setup 向导创建，使用非官方简体中文语言包。

## 构建

> 已经还原所有 Nuget 包，并使用 VS2019 成功打开。不需要的 MetroFramework 已经被清理。升级部分包。

| 包名                     | 版本       | 用途                       |
| ------------------------ | ---------- | -------------------------- |
| AvalonEdit               | 6.0.0      | 编辑器核心功能支持         |
| CommandLineParser        | 2.6.0      | 命令行功能与启动支持       |
| Common.Log               |            | 废弃                       |
| ICSharpCode.NRefactory   | 5.5.1      | 保留以作将来代码自动完成   |
| log4net                  | 2.0.8      | 日志功能支持               |
| WindowsAPICodePack-Core  | **1.1.2**  | 错误窗口与部分其它功能支持 |
| WindowsAPICodePack-Shell | 1.1.1      | 错误窗口与部分其它功能支持 |
| Mono.Cecil               | **0.11.1** | 保留                       |

需要以上包才能构建 RCSE。

可以在源码根目录下输入`msbuild`程序来进行构建。

## 扩展

使用 Microsoft Code Anylasis 扩展。可能会使用 CodeMaid 扩展。
