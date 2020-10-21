// RelaperCrystal's Simple Editor
// Copyright (C) RelaperCrystal and contributors 2020.

using System;

namespace RCSE_Reloaded
{
	/// <summary>
	/// 本类替代 CommonVals 作为本程序的全部属性所在地。
	/// </summary>
	public static class Common
	{
		private static string filters = "C# 源代码 (*.cs)|*.cs|C 源代码 (*.c)|*.c|C++ 源代码 (*.cpp;*.cxx)|*.cpp;*.cxx|Visual Basic 源代码 (*.vb)|*.vb|HTML (*.htm;*.html)|*.htm;*.html|XAML (*.xml)|*.xml|YAML (*.yml)|*.yml|Properties (*.properties)|*.properties|批处理文件 (*.bat;*.cmd)|*.bat;*.cmd|JAVA (*.java)|*.java|Python (*.py)|*.py|所有文件 (*.*)|*.*";

		// 警告：分发成不同分支必须修改本处
		private const string ProgramName = "SimpleEditor";
		private const string ProgramAttribute = "rcsereloaded";
		private const string ProgramFullName = "RelaperCrystal's Simple Editor";
		private const string ProgramShortName = "RCSE";

		// 以下为版本号
		private const string Snapshot = "21:20-20-A";
		private static readonly Version Version = new Version(1, 1, 0, 0);
		private const bool IsSnapshot = true;
		private const string LegacyFormVersion = Snapshot + "/1--20200515A";

		public static MainFrm FormInstance;

		/// <summary>
		/// 获取本产品的名称。
		/// </summary>
		/// <value>
		/// 一个常量，表示本产品的一般情况下使用的名称。
		/// </value>
		public static string ProductName => ProgramName;

		/// <summary>
		/// 获取本产品的完整名称。
		/// </summary>
		/// <value>
		/// 一个常量，表示本产品的完整名称。
		/// </value>
		public static string ProductFullName => ProgramFullName;

		/// <summary>
		/// 获取本产品的名称缩写。
		/// </summary>
		/// <value>
		/// 一个常量，表示本产品的完整名称的缩写。
		/// </value>
		public static string ProductShortName => ProgramShortName;

		/// <summary>
		/// 获取本产品的附加信息。
		/// </summary>
		/// <remarks>
		/// 此信息通常用于访问 Github API 或其它 API 时表明本产品的身份。此外，可以用于标识本产品的专用数据。一般与本产品的完整名称、普通名称甚至缩写有关。
		/// </remarks>
		/// <value>
		/// 一个常量，表示本产品的附加信息名称。
		/// </value>
		public static string ProductAttribute => ProgramAttribute;

		/// <summary>
		/// 获取本产品作为 <see cref="System.Version"/> 的版本号。
		/// </summary>
		/// <value>
		/// 一个只读变量，表示本产品的版本。
		/// </value>
		public static Version ProductVersion => Version;

		/// <summary>
		/// 获取本产品的最新快照代码。
		/// </summary>
		/// <remarks>
		/// 快照代码在不同阶段意义不同。查询本属性前，应该先查询
		/// </remarks>
		/// <value>
		/// 一个常量，表示本产品的快照代码。
		/// </value>
		public static string ProductSnapshot => Snapshot;

		/// <summary>
		/// 获取本产品是否为快照版本。
		/// </summary>
		/// <remarks>
		/// 本属性返回一个常量，代表是否为快照版。如需要获取版本号，请按以下顺序：先查询本属性，获得是否为快照；如果不是，
		/// 查询 <see cref="ProductVersion"/> 获取正式版本号；如果是，则查询 <see cref="ProductSnapshot"/> 得到快照代码。
		/// </remarks>
		public static bool IsProductInSnapshot => IsSnapshot;

		internal static string Filters => filters;
	}

	internal static class CommonValues
	{
		public const string Filters = "C# 源代码 (*.cs)|*.cs|C 源代码 (*.c)|*.c|C++ 源代码 (*.cpp;*.cxx)|*.cpp;*.cxx|Visual Basic 源代码 (*.vb)|*.vb|HTML (*.htm;*.html)|*.htm;*.html|XAML (*.xml)|*.xml|YAML (*.yml)|*.yml|Properties (*.properties)|*.properties|批处理文件 (*.bat;*.cmd)|*.bat;*.cmd|JAVA (*.java)|*.java|Python (*.py)|*.py|所有文件 (*.*)|*.*";
		public const string Snapshot = "21:20-20-A";
		public const string VerNumber = "1.1";
		public const bool IsSnapshot = true;
		public const string ProgramName = "SimpleEditor";
		public const string ProgramFullName = "RelaperCrystal's Simple Editor";
		public const string ProgramShortName = "RCSE";
		public const string LegacyFormVersion = Snapshot + "/1--20200515A";
	}

	public struct Setting
	{
		public bool UseMainMenu;
		public bool UseWhiteColor;
		public bool UseFluentDesign;
		public string SearchUrl;

		public override bool Equals(object obj)
		{
			throw new NotImplementedException();
		}

		public override int GetHashCode()
		{
			throw new NotImplementedException();
		}

		public static bool operator ==(Setting left, Setting right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Setting left, Setting right)
		{
			return !(left == right);
		}
	}
}
