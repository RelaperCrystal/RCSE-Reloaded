﻿using ICSharpCode.AvalonEdit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCSE_Reloaded
{
    public partial class FindDlg : Form
    {
        TextEditor editor;
        public FindDlg(ref TextEditor edit)
        {
            InitializeComponent();
            editor = edit;
        }

        private void FindDlg_Load(object sender, EventArgs e)
        {

        }
    }
}
