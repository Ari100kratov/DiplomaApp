﻿#pragma checksum "..\..\..\Windows\EditTaskWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "77E48025C2740AA92F2D995F2EB23C6987FE1D4B"
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
using DevExpress.Xpf.Office.UI;
using DevExpress.Xpf.RichEdit;
using DevExpress.Xpf.RichEdit.UI;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Menu;
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
    /// EditTaskWindow
    /// </summary>
    public partial class EditTaskWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\Windows\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.TextEdit teNameTask;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Windows\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.ComboBoxEdit ceProject;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Windows\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.DateEdit deEndDate;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Windows\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.ComboBoxEdit cePriority;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Windows\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.LayoutControl.LayoutItem liStatus;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Windows\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.ComboBoxEdit ceStatus;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Windows\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.LayoutControl.LayoutItem liComment;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Windows\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.MemoEdit meComment;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Windows\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.LayoutControl.LayoutItem liCompletionDate;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Windows\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.DateEdit deCompletionDate;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Windows\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.MemoEdit meDescription;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Windows\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.GridControl gcFiles;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\Windows\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Core.SimpleButton sbDeleteFile;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\Windows\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Core.SimpleButton sbEditFile;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\Windows\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Core.SimpleButton sbAddFile;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\Windows\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgPhoto;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\Windows\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbFIO;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\Windows\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbDateOfBirth;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\Windows\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbPhone;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\Windows\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbDateOfEmploy;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\Windows\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbPosition;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\Windows\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbEmail;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\Windows\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Core.SimpleButton sbSelectWorker;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\Windows\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Core.SimpleButton sbDeleteWorker;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\Windows\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lblError;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\..\Windows\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Core.SimpleButton sbCancel;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\Windows\EditTaskWindow.xaml"
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
            System.Uri resourceLocater = new System.Uri("/StankoServiceApp;component/windows/edittaskwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\EditTaskWindow.xaml"
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
            
            #line 15 "..\..\..\Windows\EditTaskWindow.xaml"
            ((StankoServiceApp.Windows.EditTaskWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.teNameTask = ((DevExpress.Xpf.Editors.TextEdit)(target));
            return;
            case 3:
            this.ceProject = ((DevExpress.Xpf.Editors.ComboBoxEdit)(target));
            return;
            case 4:
            this.deEndDate = ((DevExpress.Xpf.Editors.DateEdit)(target));
            return;
            case 5:
            this.cePriority = ((DevExpress.Xpf.Editors.ComboBoxEdit)(target));
            return;
            case 6:
            this.liStatus = ((DevExpress.Xpf.LayoutControl.LayoutItem)(target));
            return;
            case 7:
            this.ceStatus = ((DevExpress.Xpf.Editors.ComboBoxEdit)(target));
            
            #line 40 "..\..\..\Windows\EditTaskWindow.xaml"
            this.ceStatus.EditValueChanged += new DevExpress.Xpf.Editors.EditValueChangedEventHandler(this.ceStatus_EditValueChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.liComment = ((DevExpress.Xpf.LayoutControl.LayoutItem)(target));
            return;
            case 9:
            this.meComment = ((DevExpress.Xpf.Editors.MemoEdit)(target));
            return;
            case 10:
            this.liCompletionDate = ((DevExpress.Xpf.LayoutControl.LayoutItem)(target));
            return;
            case 11:
            this.deCompletionDate = ((DevExpress.Xpf.Editors.DateEdit)(target));
            return;
            case 12:
            this.meDescription = ((DevExpress.Xpf.Editors.MemoEdit)(target));
            return;
            case 13:
            this.gcFiles = ((DevExpress.Xpf.Grid.GridControl)(target));
            
            #line 61 "..\..\..\Windows\EditTaskWindow.xaml"
            this.gcFiles.CurrentItemChanged += new DevExpress.Xpf.Grid.CurrentItemChangedEventHandler(this.gcFiles_CurrentItemChanged);
            
            #line default
            #line hidden
            return;
            case 14:
            this.sbDeleteFile = ((DevExpress.Xpf.Core.SimpleButton)(target));
            
            #line 73 "..\..\..\Windows\EditTaskWindow.xaml"
            this.sbDeleteFile.Click += new System.Windows.RoutedEventHandler(this.sbDeleteFile_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.sbEditFile = ((DevExpress.Xpf.Core.SimpleButton)(target));
            
            #line 74 "..\..\..\Windows\EditTaskWindow.xaml"
            this.sbEditFile.Click += new System.Windows.RoutedEventHandler(this.sbEditFile_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.sbAddFile = ((DevExpress.Xpf.Core.SimpleButton)(target));
            
            #line 75 "..\..\..\Windows\EditTaskWindow.xaml"
            this.sbAddFile.Click += new System.Windows.RoutedEventHandler(this.sbAddFile_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            this.imgPhoto = ((System.Windows.Controls.Image)(target));
            return;
            case 18:
            this.tbFIO = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 19:
            this.tbDateOfBirth = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 20:
            this.tbPhone = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 21:
            this.tbDateOfEmploy = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 22:
            this.tbPosition = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 23:
            this.tbEmail = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 24:
            this.sbSelectWorker = ((DevExpress.Xpf.Core.SimpleButton)(target));
            
            #line 113 "..\..\..\Windows\EditTaskWindow.xaml"
            this.sbSelectWorker.Click += new System.Windows.RoutedEventHandler(this.sbSelectWorker_Click);
            
            #line default
            #line hidden
            return;
            case 25:
            this.sbDeleteWorker = ((DevExpress.Xpf.Core.SimpleButton)(target));
            
            #line 116 "..\..\..\Windows\EditTaskWindow.xaml"
            this.sbDeleteWorker.Click += new System.Windows.RoutedEventHandler(this.sbDeleteWorker_Click);
            
            #line default
            #line hidden
            return;
            case 26:
            this.lblError = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 27:
            this.sbCancel = ((DevExpress.Xpf.Core.SimpleButton)(target));
            return;
            case 28:
            this.sbSave = ((DevExpress.Xpf.Core.SimpleButton)(target));
            
            #line 128 "..\..\..\Windows\EditTaskWindow.xaml"
            this.sbSave.Click += new System.Windows.RoutedEventHandler(this.sbSave_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
