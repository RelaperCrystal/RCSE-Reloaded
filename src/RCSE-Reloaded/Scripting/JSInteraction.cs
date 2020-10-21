using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace RCSE_Reloaded.Scripting
{
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public static class JSInteraction
	{
		public static string windowTitle
		{
			get => Common.FormInstance.Text;
			set => Common.FormInstance.Text = value;
		}

		public static void messageBox(string text)
		{
			MessageBox.Show(text);
		}
	}
}
