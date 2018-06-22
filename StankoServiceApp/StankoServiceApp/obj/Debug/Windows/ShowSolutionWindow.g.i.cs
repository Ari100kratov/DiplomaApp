﻿#pragma checksum "..\..\..\Windows\ShowSolutionWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "349905578BB587B8BBC202A8B26D034A36F2C4AC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using DevExpress.Core;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.ConditionalFormatting;
using DevExpress.Xpf.Core.DataSources;
using DevExpress.Xpf.Core.Serialization;
using DevExpress.Xpf.Core.ServerMode;
using DevExpress.Xpf.DXBinding;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Editors.DataPager;
using DevExpress.Xpf.Editors.DateNavigator;
using DevExpress.Xpf.Editors.ExpressionEditor;
using DevExpress.Xpf.Editors.Filtering;
using DevExpress.Xpf.Editors.Flyout;
using DevExpress.Xpf.Editors.Popups;
using DevExpress.Xpf.Editors.Popups.Calendar;
using DevExpress.Xpf.Editors.RangeControl;
using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.Editors.Settings.Extension;
using DevExpress.Xpf.Editors.Validation;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Grid.ConditionalFormatting;
using DevExpress.Xpf.Grid.LookUp;
using DevExpress.Xpf.Grid.TreeList;
using DevExpress.Xpf.LayoutControl;
using StankoServiceApp.Windows;
using StankoserviceEnums;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace StankoServiceApp.Windows {
    
    
    /// <summary>
    /// ShowSolutionWindow
    /// </summary>
    public partial class ShowSolutionWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 25 "..\..\..\Windows\ShowSolutionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.LayoutControl.LayoutControl lcWorker;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Windows\ShowSolutionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbDate;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Windows\ShowSolutionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbComment;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Windows\ShowSolutionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.GridControl gcFiles;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Windows\ShowSolutionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.TableView tvFiles;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Windows\ShowSolutionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.GridColumn columnIcon;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Windows\ShowSolutionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.GridColumn columnDate;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Windows\ShowSolutionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.GridColumn columnDownload;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Windows\ShowSolutionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.ComboBoxEdit cbFilterStatus;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\Windows\ShowSolutionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Core.SimpleButton sbSave;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/StankoServiceApp;component/windows/showsolutionwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\ShowSolutionWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 14 "..\..\..\Windows\ShowSolutionWindow.xaml"
            ((StankoServiceApp.Windows.ShowSolutionWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lcWorker = ((DevExpress.Xpf.LayoutControl.LayoutControl)(target));
            return;
            case 3:
            this.tbDate = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.tbComment = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.gcFiles = ((DevExpress.Xpf.Grid.GridControl)(target));
            
            #line 35 "..\..\..\Windows\ShowSolutionWindow.xaml"
            this.gcFiles.ItemsSourceChanged += new DevExpress.Xpf.Grid.ItemsSourceChangedEventHandler(this.gcFiles_ItemsSourceChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.tvFiles = ((DevExpress.Xpf.Grid.TableView)(target));
            return;
            case 7:
            this.columnIcon = ((DevExpress.Xpf.Grid.GridColumn)(target));
            return;
            case 8:
            this.columnDate = ((DevExpress.Xpf.Grid.GridColumn)(target));
            return;
            case 9:
            this.columnDownload = ((DevExpress.Xpf.Grid.GridColumn)(target));
            return;
            case 11:
            this.cbFilterStatus = ((DevExpress.Xpf.Editors.ComboBoxEdit)(target));
            return;
            case 12:
            this.sbSave = ((DevExpress.Xpf.Core.SimpleButton)(target));
            
            #line 67 "..\..\..\Windows\ShowSolutionWindow.xaml"
            this.sbSave.Click += new System.Windows.RoutedEventHandler(this.sbSave_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 10:
            
            #line 57 "..\..\..\Windows\ShowSolutionWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseLeftButtonDown);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

