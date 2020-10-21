using System;
using System.Runtime.InteropServices;

namespace RCSE_Reloaded.API.FluentService
{
	public static class Transparent
	{
		[DllImport("user32.dll")]
		private static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);
		public static void SetBlur(IntPtr handle)
		{
			var accent = new AccentPolicy
			{
				AccentState = AccentState.AccentEnableBlurBehind
			};

			var accentStructSize = Marshal.SizeOf(accent);
			var accentPtr = Marshal.AllocHGlobal(accentStructSize);
			Marshal.StructureToPtr(accent, accentPtr, false);

			var data = new WindowCompositionAttributeData
			{
				Attribute = WindowCompositionAttribute.WcaAccentPolicy,
				SizeOfData = accentStructSize,
				Data = accentPtr
			};

			SetWindowCompositionAttribute(handle, ref data);

			Marshal.FreeHGlobal(accentPtr);
		}
	}

	public enum AccentState
	{
		AccentDisabled = 0,
		AccentEnableGradient = 1,
		AccentEnableTransparentGradient = 2,
		AccentEnableBlurBehind = 3,
		AccentInvalidState = 4
	}

	public struct AccentPolicy
	{
		public AccentState AccentState;
		public int AccentFlags;
		public int GradientColor;
		public int AnimationId;

		public override bool Equals(object obj)
		{
			throw new NotImplementedException();
		}

		public override int GetHashCode()
		{
			throw new NotImplementedException();
		}

		public static bool operator ==(AccentPolicy left, AccentPolicy right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(AccentPolicy left, AccentPolicy right)
		{
			return !(left == right);
		}
	}

	public enum WindowCompositionAttribute
	{
		// ...
		WcaAccentPolicy = 19
		// ...
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct WindowCompositionAttributeData
	{
		public WindowCompositionAttribute Attribute;
		public IntPtr Data;
		public int SizeOfData;

		public override bool Equals(object obj)
		{
			throw new NotImplementedException();
		}

		public override int GetHashCode()
		{
			throw new NotImplementedException();
		}

		public static bool operator ==(WindowCompositionAttributeData left, WindowCompositionAttributeData right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(WindowCompositionAttributeData left, WindowCompositionAttributeData right)
		{
			return !(left == right);
		}
	}
}
