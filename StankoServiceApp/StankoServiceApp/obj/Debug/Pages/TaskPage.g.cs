﻿#pragma checksum "..\..\..\Pages\TaskPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9A7C01810763FFBCDD5F6B9BFCEF3D78EB4082B9"
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
using DevExpress.Xpf.Bars;
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
using DevExpress.Xpf.Ribbon;
using StankoServiceApp;
using StankoServiceApp.Pages;
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


namespace StankoServiceApp.Pages {
    
    
    /// <summary>
    /// TaskPage
    /// </summary>
    public partial class TaskPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.GridControl gcTask;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.TreeListView tbTask;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.GridColumn column1;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.GridColumn column2;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.GridColumn column3;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.GridColumn column4;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.GridColumn column5;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.GridColumn column6;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.GridColumn column7;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.GridColumn column8;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Bars.BarButtonItem bbiNewTask;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Bars.BarButtonItem bbiEditTask;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Bars.BarButtonItem bbiDeleteTask;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Bars.BarButtonItem bbiRefresh;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Bars.BarButtonItem bbiStandartPrint;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Bars.BarButtonItem bbiShowTask;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Ribbon.RibbonPageGroup rpgStatus;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Bars.BarButtonItem status1;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Bars.BarButtonItem status2;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Bars.BarButtonItem status6;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Bars.BarButtonItem status5;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Bars.BarButtonItem status4;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Bars.BarButtonItem status3;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Ribbon.RibbonPageGroup rpgPriority;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Bars.BarButtonItem prior6;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Bars.BarButtonItem prior5;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Bars.BarButtonItem prior4;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Bars.BarButtonItem prior3;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Bars.BarButtonItem prior2;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Bars.BarButtonItem prior1;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Bars.BarEditItem bbiFilterStatus;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.Settings.ComboBoxEditSettings cbFilterStatus;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Bars.BarEditItem bbiFilterPriority;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.Settings.ComboBoxEditSettings cbFilterPriority;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\Pages\TaskPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Bars.BarButtonItem bbiClearFilter;
        
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
            System.Uri resourceLocater = new System.Uri("/StankoServiceApp;component/pages/taskpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\TaskPage.xaml"
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
            
            #line 16 "..\..\..\Pages\TaskPage.xaml"
            ((StankoServiceApp.Pages.TaskPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.gcTask = ((DevExpress.Xpf.Grid.GridControl)(target));
            
            #line 24 "..\..\..\Pages\TaskPage.xaml"
            this.gcTask.CurrentItemChanged += new DevExpress.Xpf.Grid.CurrentItemChangedEventHandler(this.gcTask_CurrentItemChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tbTask = ((DevExpress.Xpf.Grid.TreeListView)(target));
            return;
            case 4:
            this.column1 = ((DevExpress.Xpf.Grid.GridColumn)(target));
            return;
            case 5:
            this.column2 = ((DevExpress.Xpf.Grid.GridColumn)(target));
            return;
            case 6:
            this.column3 = ((DevExpress.Xpf.Grid.GridColumn)(target));
            return;
            case 7:
            this.column4 = ((DevExpress.Xpf.Grid.GridColumn)(target));
            return;
            case 8:
            this.column5 = ((DevExpress.Xpf.Grid.GridColumn)(target));
            return;
            case 9:
            this.column6 = ((DevExpress.Xpf.Grid.GridColumn)(target));
            return;
            case 10:
            this.column7 = ((DevExpress.Xpf.Grid.GridColumn)(target));
            return;
            case 11:
            this.column8 = ((DevExpress.Xpf.Grid.GridColumn)(target));
            return;
            case 12:
            this.bbiNewTask = ((DevExpress.Xpf.Bars.BarButtonItem)(target));
            
            #line 68 "..\..\..\Pages\TaskPage.xaml"
            this.bbiNewTask.ItemClick += new DevExpress.Xpf.Bars.ItemClickEventHandler(this.bbiNewTask_ItemClick);
            
            #line default
            #line hidden
            return;
            case 13:
            this.bbiEditTask = ((DevExpress.Xpf.Bars.BarButtonItem)(target));
            
            #line 69 "..\..\..\Pages\TaskPage.xaml"
            this.bbiEditTask.ItemClick += new DevExpress.Xpf.Bars.ItemClickEventHandler(this.bbiEditTask_ItemClick);
            
            #line default
            #line hidden
            return;
            case 14:
            this.bbiDeleteTask = ((DevExpress.Xpf.Bars.BarButtonItem)(target));
            
            #line 70 "..\..\..\Pages\TaskPage.xaml"
            this.bbiDeleteTask.ItemClick += new DevExpress.Xpf.Bars.ItemClickEventHandler(this.bbiDeleteTask_ItemClick);
            
            #line default
            #line hidden
            return;
            case 15:
            this.bbiRefresh = ((DevExpress.Xpf.Bars.BarButtonItem)(target));
            
            #line 71 "..\..\..\Pages\TaskPage.xaml"
            this.bbiRefresh.ItemClick += new DevExpress.Xpf.Bars.ItemClickEventHandler(this.bbiRefresh_ItemClick);
            
            #line default
            #line hidden
            return;
            case 16:
            this.bbiStandartPrint = ((DevExpress.Xpf.Bars.BarButtonItem)(target));
            
            #line 74 "..\..\..\Pages\TaskPage.xaml"
            this.bbiStandartPrint.ItemClick += new DevExpress.Xpf.Bars.ItemClickEventHandler(this.bbiStandartPrint_ItemClick);
            
            #line default
            #line hidden
            return;
            case 17:
            this.bbiShowTask = ((DevExpress.Xpf.Bars.BarButtonItem)(target));
            
            #line 75 "..\..\..\Pages\TaskPage.xaml"
            this.bbiShowTask.ItemClick += new DevExpress.Xpf.Bars.ItemClickEventHandler(this.bbiShowTask_ItemClick);
            
            #line default
            #line hidden
            return;
            case 18:
            this.rpgStatus = ((DevExpress.Xpf.Ribbon.RibbonPageGroup)(target));
            return;
            case 19:
            this.status1 = ((DevExpress.Xpf.Bars.BarButtonItem)(target));
            
            #line 80 "..\..\..\Pages\TaskPage.xaml"
            this.status1.ItemClick += new DevExpress.Xpf.Bars.ItemClickEventHandler(this.status1_ItemClick);
            
            #line default
            #line hidden
            return;
            case 20:
            this.status2 = ((DevExpress.Xpf.Bars.BarButtonItem)(target));
            
            #line 81 "..\..\..\Pages\TaskPage.xaml"
            this.status2.ItemClick += new DevExpress.Xpf.Bars.ItemClickEventHandler(this.status2_ItemClick);
            
            #line default
            #line hidden
            return;
            case 21:
            this.status6 = ((DevExpress.Xpf.Bars.BarButtonItem)(target));
            
            #line 82 "..\..\..\Pages\TaskPage.xaml"
            this.status6.ItemClick += new DevExpress.Xpf.Bars.ItemClickEventHandler(this.status6_ItemClick);
            
            #line default
            #line hidden
            return;
            case 22:
            this.status5 = ((DevExpress.Xpf.Bars.BarButtonItem)(target));
            
            #line 83 "..\..\..\Pages\TaskPage.xaml"
            this.status5.ItemClick += new DevExpress.Xpf.Bars.ItemClickEventHandler(this.status5_ItemClick);
            
            #line default
            #line hidden
            return;
            case 23:
            this.status4 = ((DevExpress.Xpf.Bars.BarButtonItem)(target));
            
            #line 84 "..\..\..\Pages\TaskPage.xaml"
            this.status4.ItemClick += new DevExpress.Xpf.Bars.ItemClickEventHandler(this.status4_ItemClick);
            
            #line default
            #line hidden
            return;
            case 24:
            this.status3 = ((DevExpress.Xpf.Bars.BarButtonItem)(target));
            
            #line 85 "..\..\..\Pages\TaskPage.xaml"
            this.status3.ItemClick += new DevExpress.Xpf.Bars.ItemClickEventHandler(this.status3_ItemClick);
            
            #line default
            #line hidden
            return;
            case 25:
            this.rpgPriority = ((DevExpress.Xpf.Ribbon.RibbonPageGroup)(target));
            return;
            case 26:
            this.prior6 = ((DevExpress.Xpf.Bars.BarButtonItem)(target));
            
            #line 89 "..\..\..\Pages\TaskPage.xaml"
            this.prior6.ItemClick += new DevExpress.Xpf.Bars.ItemClickEventHandler(this.prior6_ItemClick);
            
            #line default
            #line hidden
            return;
            case 27:
            this.prior5 = ((DevExpress.Xpf.Bars.BarButtonItem)(target));
            
            #line 90 "..\..\..\Pages\TaskPage.xaml"
            this.prior5.ItemClick += new DevExpress.Xpf.Bars.ItemClickEventHandler(this.prior5_ItemClick);
            
            #line default
            #line hidden
            return;
            case 28:
            this.prior4 = ((DevExpress.Xpf.Bars.BarButtonItem)(target));
            
            #line 91 "..\..\..\Pages\TaskPage.xaml"
            this.prior4.ItemClick += new DevExpress.Xpf.Bars.ItemClickEventHandler(this.prior4_ItemClick);
            
            #line default
            #line hidden
            return;
            case 29:
            this.prior3 = ((DevExpress.Xpf.Bars.BarButtonItem)(target));
            
            #line 92 "..\..\..\Pages\TaskPage.xaml"
            this.prior3.ItemClick += new DevExpress.Xpf.Bars.ItemClickEventHandler(this.prior3_ItemClick);
            
            #line default
            #line hidden
            return;
            case 30:
            this.prior2 = ((DevExpress.Xpf.Bars.BarButtonItem)(target));
            
            #line 93 "..\..\..\Pages\TaskPage.xaml"
            this.prior2.ItemClick += new DevExpress.Xpf.Bars.ItemClickEventHandler(this.prior2_ItemClick);
            
            #line default
            #line hidden
            return;
            case 31:
            this.prior1 = ((DevExpress.Xpf.Bars.BarButtonItem)(target));
            
            #line 94 "..\..\..\Pages\TaskPage.xaml"
            this.prior1.ItemClick += new DevExpress.Xpf.Bars.ItemClickEventHandler(this.prior1_ItemClick);
            
            #line default
            #line hidden
            return;
            case 32:
            this.bbiFilterStatus = ((DevExpress.Xpf.Bars.BarEditItem)(target));
            
            #line 98 "..\..\..\Pages\TaskPage.xaml"
            this.bbiFilterStatus.EditValueChanged += new System.Windows.RoutedEventHandler(this.bbiFilterStatus_EditValueChanged);
            
            #line default
            #line hidden
            return;
            case 33:
            this.cbFilterStatus = ((DevExpress.Xpf.Editors.Settings.ComboBoxEditSettings)(target));
            return;
            case 34:
            this.bbiFilterPriority = ((DevExpress.Xpf.Bars.BarEditItem)(target));
            
            #line 103 "..\..\..\Pages\TaskPage.xaml"
            this.bbiFilterPriority.EditValueChanged += new System.Windows.RoutedEventHandler(this.bbiFilterPriority_EditValueChanged);
            
            #line default
            #line hidden
            return;
            case 35:
            this.cbFilterPriority = ((DevExpress.Xpf.Editors.Settings.ComboBoxEditSettings)(target));
            return;
            case 36:
            this.bbiClearFilter = ((DevExpress.Xpf.Bars.BarButtonItem)(target));
            
            #line 108 "..\..\..\Pages\TaskPage.xaml"
            this.bbiClearFilter.ItemClick += new DevExpress.Xpf.Bars.ItemClickEventHandler(this.bbiClearFilter_ItemClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

