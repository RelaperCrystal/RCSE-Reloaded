# RCSE 重置版

由 Avalon Edit 强力驱动，现在的 RCSE 已经支持语法高亮功能。另外，本代码被从头重写。

关于 RCSE - Remastered: 这个项目是在初期夭折的，最后选用了 WinForm 的原因是设计简单。本来想用 Ribbon 结果这个想法也夭折了。最后中规中矩的还是用了老的菜单栏设计。

| 名称     | Badge                                                        |
| -------- | ------------------------------------------------------------ |
| 构建     | [![Build Status](https://endermanmc.visualstudio.com/RCSEReloaded-CI/_apis/build/status/RelaperCrystal.RCSE-Reloaded?branchName=master)](https://endermanmc.visualstudio.com/RCSEReloaded-CI/_build/latest?definitionId=6&branchName=master) |
| 协议     | ![GitHub](https://img.shields.io/github/license/RelaperCrystal/RCSE-Reloaded) |
| 当前版本 | ![GitHub release (latest by date)](https://img.shields.io/github/v/release/RelaperCrystal/RCSE-Reloaded) |

## RC 版本

RC 相比之前的测试版更新可能会更缓慢，也会更稳定。

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