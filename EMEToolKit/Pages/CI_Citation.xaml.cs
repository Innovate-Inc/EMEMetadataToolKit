﻿/*
COPYRIGHT 1995-2009 ESRI
TRADE SECRETS: ESRI PROPRIETARY AND CONFIDENTIAL
Unpublished material - all rights reserved under the 
Copyright Laws of the United States.
For additional information, contact:
Environmental Systems Research Institute, Inc.
Attn: Contracts Dept
380 New York Street
Redlands, California, USA 92373
email: contracts@esri.com
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.ComponentModel;

using ESRI.ArcGIS.Metadata.Editor; using ESRI.ArcGIS.Metadata.Editor.Pages; namespace CustomMetadataEditor.Pages
{
    /// <summary>
    /// Interaction logic for CI_Citation.xaml
    /// </summary>
  public partial class CI_Citation : EditorPage, INotifyPropertyChanged
  {

    public static readonly DependencyProperty SupressPartiesProperty = DependencyProperty.Register(
       "SupressParties",
       typeof(Boolean),
       typeof(CI_Citation));

    public static readonly DependencyProperty SupressOnlineResourceProperty = DependencyProperty.Register(
       "SupressOnlineResource",
       typeof(Boolean),
       typeof(CI_Citation));

    public Boolean SupressParties
    {
      get { return (Boolean)this.GetValue(SupressPartiesProperty); }
      set { this.SetValue(SupressPartiesProperty, value); }
    }

    public Boolean SupressOnlineResource
    {
      get { return (Boolean)this.GetValue(SupressOnlineResourceProperty); }
      set { this.SetValue(SupressOnlineResourceProperty, value); }
    }

    public CI_Citation()
    {
      InitializeComponent();
    }
  }
}
