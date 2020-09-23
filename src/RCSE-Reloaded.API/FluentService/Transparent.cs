using System;
using System.Runtime.InteropServices;

namespace RCSE_Reloaded.API.FluentService
{
	public static class Transparent
	{
		[DllImport("user32.dll")]
		internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);
		public static void SetBlur(IntPtr Handle)
		{
			var accent = new AccentPolicy
			{
				AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND
			};

			var accentStructSize = Marshal.SizeOf(accent);
			var accentPtr = Marshal.AllocHGlobal(accentStructSize);
			Marshal.StructureToPtr(accent, accentPtr, false);

			var data = new WindowCompositionAttributeData
			{
				Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY,
				SizeOfData = accentStructSize,
				Data = accentPtr
			};

			SetWindowCompositionAttribute(Handle, ref data);

			Marshal.FreeHGlobal(accentPtr);
		}
	}

	public enum AccentState
	{
		ACCENT_DISABLED = 0,
		ACCENT_ENABLE_GRADIENT = 1,
		ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
		ACCENT_ENABLE_BLURBEHIND = 3,
		ACCENT_INVALID_STATE = 4
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
		WCA_ACCENT_POLICY = 19
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
