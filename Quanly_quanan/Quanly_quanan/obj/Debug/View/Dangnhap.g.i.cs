﻿#pragma checksum "..\..\..\View\Dangnhap.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7840A3882FAAF74AA356631162B0B3ED462B3CBB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using System.Windows.Interactivity;
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


namespace Quanly_quanan.View {
    
    
    /// <summary>
    /// Dangnhap
    /// </summary>
    public partial class Dangnhap : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\View\Dangnhap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Quanly_quanan.View.Dangnhap wd_dangnhap;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\View\Dangnhap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_username;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\View\Dangnhap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pb_pass;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\..\View\Dangnhap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_pass;
        
        #line default
        #line hidden
        
        
        #line 177 "..\..\..\View\Dangnhap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_login;
        
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
            System.Uri resourceLocater = new System.Uri("/Quanly_quanan;component/view/dangnhap.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\Dangnhap.xaml"
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
            this.wd_dangnhap = ((Quanly_quanan.View.Dangnhap)(target));
            return;
            case 2:
            this.tb_username = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.pb_pass = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.tb_pass = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            
            #line 161 "..\..\..\View\Dangnhap.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.ToggleButton_Checked);
            
            #line default
            #line hidden
            
            #line 162 "..\..\..\View\Dangnhap.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.ToggleButton_Unchecked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btn_login = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

