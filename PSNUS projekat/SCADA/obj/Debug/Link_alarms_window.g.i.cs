﻿#pragma checksum "..\..\Link_alarms_window.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A5B2F05C2E614BA2ABB37D134A9DAAEA328ADA5A3E6D2D04B2B05817D8114844"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SCADA;
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


namespace SCADA {
    
    
    /// <summary>
    /// Link_alarms_window
    /// </summary>
    public partial class Link_alarms_window : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\Link_alarms_window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label AI_info;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Link_alarms_window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Link_alarm;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Link_alarms_window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Unlink_alarm;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Link_alarms_window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Close;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Link_alarms_window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox Data_grid_all;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Link_alarms_window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox Data_grid_linked;
        
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
            System.Uri resourceLocater = new System.Uri("/SCADA;component/link_alarms_window.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Link_alarms_window.xaml"
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
            this.AI_info = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.Link_alarm = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\Link_alarms_window.xaml"
            this.Link_alarm.Click += new System.Windows.RoutedEventHandler(this.Link_alarm_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Unlink_alarm = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\Link_alarms_window.xaml"
            this.Unlink_alarm.Click += new System.Windows.RoutedEventHandler(this.Unlink_alarm_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_Close = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\Link_alarms_window.xaml"
            this.btn_Close.Click += new System.Windows.RoutedEventHandler(this.Close_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Data_grid_all = ((System.Windows.Controls.ListBox)(target));
            
            #line 15 "..\..\Link_alarms_window.xaml"
            this.Data_grid_all.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Link_alarm_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Data_grid_linked = ((System.Windows.Controls.ListBox)(target));
            
            #line 22 "..\..\Link_alarms_window.xaml"
            this.Data_grid_linked.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Unlink_alarm_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

