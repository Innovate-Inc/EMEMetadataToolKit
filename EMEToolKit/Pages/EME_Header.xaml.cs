﻿using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace EPAMetadataEditor.Pages
{
    /// <summary>
    /// Interaction logic for EME_Header.xaml
    /// </summary>
    public partial class EME_Header : UserControl
    {
        public EME_Header()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
