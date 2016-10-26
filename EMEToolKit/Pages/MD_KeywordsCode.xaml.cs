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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ESRI.ArcGIS.Metadata.Editor.Pages;
namespace EPAMetadataEditor.Pages
{
    /// <summary>
    /// Interaction logic for MD_KeywordsCode.xaml
    /// </summary>
    public partial class MD_KeywordsCode : EditorPage
    {
        private List<string> _listThemeK = new List<string>();

        public MD_KeywordsCode()
        {
            InitializeComponent();
        }

        public List<Control> AllChildren(DependencyObject parent)
        {
            var _List = new List<Control> { };
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var _Child = VisualTreeHelper.GetChild(parent, i);
                if (_Child is Control)
                    _List.Add(_Child as Control);
                _List.AddRange(AllChildren(_Child));
            }
            return _List;
        }

        private void MD_KeywordsCode_Loaded(object sender, RoutedEventArgs e)
        {
            FillXml();
        }

        private void chbxPCode_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;

            _listThemeK.Add(xmlCheckBox.InnerText);
            _listThemeK.Sort();
            _listThemeK = _listThemeK.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            tbxMDPCode.Text = "";

            foreach (string s in _listThemeK)
            {
                tbxMDPCode.Text += s + System.Environment.NewLine;
            }
            tbxMDPCode.Focus();
        }

        private void chbxPCode_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;

            _listThemeK.Remove(xmlCheckBox.InnerText);
            tbxMDPCode.Text = "";

            foreach (string s in _listThemeK)
            {
                tbxMDPCode.Text += s + System.Environment.NewLine;
            }
            tbxMDPCode.Focus();
        }

        private void btnLoadDefaultPCode_Click(object sender, RoutedEventArgs e)
        {
            ListBox liBox = (ListBox)lbxPCode;
            foreach (var liBoxItem in liBox.Items)
            {
                var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
                var liBoxChildren = AllChildren(liBoxCont);
                var liBoxName = "chbxPCode";
                var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
                System.Xml.XmlElement xmlTest = (System.Xml.XmlElement)liBoxCtrl.Content;
                if (xmlTest.NextSibling.InnerText.Contains("true"))
                { liBoxCtrl.IsChecked = true; }
                else
                { liBoxCtrl.IsChecked = false; }
            }
        }

        private void btnClearPCode_Click(object sender, RoutedEventArgs e)
        {
            ListBox liBox = (ListBox)lbxPCode;
            foreach (var liBoxItem in liBox.Items)
            {
                var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
                var liBoxChildren = AllChildren(liBoxCont);
                var liBoxName = "chbxPCode";
                var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
                liBoxCtrl.IsChecked = false;
            }
        }

        private void tbxPCode_Loaded(object sender, RoutedEventArgs e)
        {
            if (lbxPCode.IsVisible == true)
            {
                List<string> listPCode = new List<string>();
                if (tbxMDPCode.Text.Any())
                {
                    string[] strlistPCode = tbxMDPCode.Text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string s in strlistPCode)
                    {
                        listPCode.Add(s.Trim());
                    }
                }
                listPCode = listPCode.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
                listPCode.Sort();

                ListBox liBox = (ListBox)lbxPCode;
                foreach (var liBoxItem in liBox.Items)
                {
                    var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
                    var liBoxChildren = AllChildren(liBoxCont);
                    var chbxName = "chbxPCode";
                    var chBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == chbxName);
                    System.Xml.XmlElement xmlTest = (System.Xml.XmlElement)chBoxCtrl.Content;
                    chBoxCtrl.IsChecked = listPCode.Exists(s => s.Equals(xmlTest.InnerText.Trim()));
                }
            }
        }
    }
}