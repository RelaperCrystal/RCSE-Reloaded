using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RCSE_Reloaded.API
{
	public static class FolderTree
	{
		public static void PaintTreeView(ref TreeView treeView, string fullPath)
		{
			try
			{
				treeView.Nodes.Clear(); //清空TreeView


				DirectoryInfo dirs = new DirectoryInfo(fullPath); //获得程序所在路径的目录对象
				DirectoryInfo[] dir = dirs.GetDirectories();//获得目录下文件夹对象
				FileInfo[] file = dirs.GetFiles();//获得目录下文件对象
				int dircount = dir.Count();//获得文件夹对象数量
				int filecount = file.Count();//获得文件对象数量


				//循环文件夹
				for (int i = 0; i < dircount; i++)
				{
					treeView.Nodes.Add(dir[i].Name);
					string pathNode = fullPath + "\\" + dir[i].Name;
					GetMultiNode(treeView.Nodes[i], pathNode);
				}


				//循环文件
				for (int j = 0; j < filecount; j++)
				{
					treeView.Nodes.Add(file[j].Name);
				}
			}
			catch
			{
				// ReSharper disable once LocalizableElement
				Console.WriteLine("Looks like something wrong!!!");
			}
		}

		public static  bool GetMultiNode(TreeNode treeNode, string path)
		{
			if (Directory.Exists(path) == false)
			{ return false; }


			DirectoryInfo dirs = new DirectoryInfo(path); //获得程序所在路径的目录对象
			DirectoryInfo[] dir = dirs.GetDirectories();//获得目录下文件夹对象
			FileInfo[] file = dirs.GetFiles();//获得目录下文件对象
			int dircount = dir.Count();//获得文件夹对象数量
			int filecount = file.Count();//获得文件对象数量
			int sumcount = dircount + filecount;


			if (sumcount == 0)
			{ return false; }


			//循环文件夹
			for (int j = 0; j < dircount; j++)
			{
				treeNode.Nodes.Add(dir[j].Name);
				string pathNodeB = Path.Combine(path, dir[j].Name);
				GetMultiNode(treeNode.Nodes[j], pathNodeB);
			}


			//循环文件
			for (int j = 0; j < filecount; j++)
			{
				treeNode.Nodes.Add(file[j].Name);
			}
			return true;
		}
	}
}
