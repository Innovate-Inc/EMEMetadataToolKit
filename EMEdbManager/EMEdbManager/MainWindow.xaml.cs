﻿using System;
using System.Windows;
using System.Xml;

namespace EMEdbManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _pathEmeDb = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\Innovate! Inc\\EPA MetadataToolkit\\EMEdb\\";

        public MainWindow()
        {
            InitializeComponent();
            string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            XmlRecord_ThemeKeyEpa.Source = new Uri(_pathEmeDb + "KeywordsEPA.xml");
            XmlRecord_ThemeKeyUser.Source = new Uri(_pathEmeDb + "KeywordsUser.xml");
            XmlRecord_ThemeKeyPlace.Source = new Uri(_pathEmeDb + "KeywordsPlace.xml");
            XmlRecord_SystemofRecords.Source = new Uri(_pathEmeDb + "SystemofRecords.xml");
            XmlRecord_SystemofRecords.XPath = "/emeData/SystemOfRecord[SysRcrdName[(text())]]";
            XmlRecord_SecConsts.Source = new Uri(_pathEmeDb + "SecurityConstraints.xml");
        }

        private void lbxThemekeyEpa_loaded(object sender, RoutedEventArgs e)
        {
            lblKwEPACount.Content = "( " + lbxThemekeyEpa.Items.Count.ToString() + " )";
        }

        private void lbxThemekeyUser_loaded(object sender, RoutedEventArgs e)
        {
            lblKwUserCount.Content = "( " + lbxThemekeyUser.Items.Count.ToString() + " )";
        }
        private void lbxThemekeyPlace_loaded(object sender, RoutedEventArgs e)
        {
            lblKwPlaceCount.Content = "( " + lbxThemekeyPlace.Items.Count.ToString() + " )";
        }

        private void lbxSystemofRecords_loaded(object sender, RoutedEventArgs e)
        {
            lblSoRCount.Content = "( " + lbxSystemofRecords.Items.Count.ToString() + " )";
        }

        private void lbxSecConsts_loaded(object sender, RoutedEventArgs e)
        {
            lblSecConstsCount.Content = "( " + lbxSecConsts.Items.Count.ToString() + " )";
        }

        private void btnSaveThemekeyEpa_Click(object sender, RoutedEventArgs e)
        {
            string source = XmlRecord_ThemeKeyEpa.Source.LocalPath;
            XmlRecord_ThemeKeyEpa.Document.Save(source);
        }

        private void btnSaveSOR_Click(object sender, RoutedEventArgs e)
        {
            string source = XmlRecord_SystemofRecords.Source.LocalPath;
            XmlRecord_SystemofRecords.Document.Save(source);
        }

        private void btnSaveSecConsts_Click(object sender, RoutedEventArgs e)
        {
            string source = XmlRecord_SecConsts.Source.LocalPath;
            XmlRecord_SecConsts.Document.Save(source);
        }

        private void btnSaveThemekeyPlace_Click(object sender, RoutedEventArgs e)
        {
            string source = XmlRecord_ThemeKeyUser.Source.LocalPath;
            XmlRecord_ThemeKeyUser.Document.Save(source);
        }

        private void btnSaveThemekeyUser_Click(object sender, RoutedEventArgs e)
        {
            string source = XmlRecord_ThemeKeyUser.Source.LocalPath;
            XmlRecord_ThemeKeyUser.Document.Save(source);
        }

        private void btnAddThemekeyEpa_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = XmlRecord_ThemeKeyEpa.Document;
            XmlElement epaElement = doc.CreateElement("KeywordsEPA");
            XmlElement xmlEleThesaName = doc.CreateElement("themekt");
            XmlElement xmlEleKeyword = doc.CreateElement("themekey");
            XmlElement xmlEleDefault = doc.CreateElement("default");
            xmlEleThesaName.InnerText = "EPA GIS Keyword Thesaurus";
            xmlEleDefault.InnerText = "False";

            epaElement.AppendChild(xmlEleThesaName);
            epaElement.AppendChild(xmlEleKeyword);
            epaElement.AppendChild(xmlEleDefault);
            doc.DocumentElement.InsertAfter(epaElement, doc.DocumentElement.LastChild);
        }

        private void btnAddThemekeyUser_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = XmlRecord_ThemeKeyUser.Document;
            XmlElement userElement = doc.CreateElement("KeywordsUser");
            XmlElement xmlEleThesaName = doc.CreateElement("themekt");
            XmlElement xmlEleKeyword = doc.CreateElement("themekey");
            XmlElement xmlEleDefault = doc.CreateElement("default");
            xmlEleThesaName.InnerText = "User";
            xmlEleDefault.InnerText = "False";

            userElement.AppendChild(xmlEleThesaName);
            userElement.AppendChild(xmlEleKeyword);
            userElement.AppendChild(xmlEleDefault);
            doc.DocumentElement.InsertAfter(userElement, doc.DocumentElement.LastChild);
        }

        private void btnAddThemekeyPlace_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = XmlRecord_ThemeKeyPlace.Document;
            XmlElement placeElement = doc.CreateElement("KeywordsPlace");
            XmlElement xmlEleThesaName = doc.CreateElement("placekt");
            XmlElement xmlEleKeyword = doc.CreateElement("placekey");
            XmlElement xmlEleDefault = doc.CreateElement("default");
            xmlEleDefault.InnerText = "False";

            placeElement.AppendChild(xmlEleThesaName);
            placeElement.AppendChild(xmlEleKeyword);
            placeElement.AppendChild(xmlEleDefault);
            doc.DocumentElement.InsertAfter(placeElement, doc.DocumentElement.LastChild);
        }

        private void btnAddSecConsts_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = XmlRecord_SecConsts.Document;
            XmlElement xmlEleSecCnst = doc.CreateElement("SecurityConstraints");
            XmlElement xmlEleSecNote = doc.CreateElement("usenote");
            XmlElement xmlEleSecClass = doc.CreateElement("constsclass");
            xmlEleSecNote.InnerText = "EPA Category: ";
            xmlEleSecClass.InnerText = "non-public";

            xmlEleSecCnst.AppendChild(xmlEleSecNote);
            xmlEleSecCnst.AppendChild(xmlEleSecClass);
            doc.DocumentElement.InsertAfter(xmlEleSecCnst, doc.DocumentElement.LastChild);
        }

        private void btnAddSOR_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = XmlRecord_SecConsts.Document;
            XmlElement xmlEleSOR = doc.CreateElement("SystemOfRecord");
            XmlElement xmlEleSORname = doc.CreateElement("SysRcrdName");
            XmlElement xmlEleSORurl = doc.CreateElement("SysRcrdUrl");
            xmlEleSORname.InnerText = "New System of Record";

            xmlEleSOR.AppendChild(xmlEleSORname);
            xmlEleSOR.AppendChild(xmlEleSORurl);
            doc.DocumentElement.InsertAfter(xmlEleSOR, doc.DocumentElement.LastChild);
        }
    }
}
