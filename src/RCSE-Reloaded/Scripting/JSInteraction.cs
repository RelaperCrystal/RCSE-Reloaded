using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCSE_Reloaded.Scripting
{
	public static class JSInteraction
	{
		public static string windowTitle
		{
			get => Common.formInstance.Text;
			set => Common.formInstance.Text = value;
		}

		public static void messageBox(string text)
		{
			MessageBox.Show(text);
		}
	}
}
