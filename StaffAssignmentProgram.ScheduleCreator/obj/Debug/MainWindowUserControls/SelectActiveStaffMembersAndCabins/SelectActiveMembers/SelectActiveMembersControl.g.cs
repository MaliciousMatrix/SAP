﻿#pragma checksum "..\..\..\..\..\MainWindowUserControls\SelectActiveStaffMembersAndCabins\SelectActiveMembers\SelectActiveMembersControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "792B01E6C043A34BDD0D3AE3CC8CFCA406ED1AC7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GalaSoft.MvvmLight.Command;
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


namespace SAP.ScheduleCreator.MainWindowUserControls.SelectActiveStaffMembersAndCabins.SelectActiveMembers {
    
    
    /// <summary>
    /// SelectActiveMembersControl
    /// </summary>
    public partial class SelectActiveMembersControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\..\MainWindowUserControls\SelectActiveStaffMembersAndCabins\SelectActiveMembers\SelectActiveMembersControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox StaffSearch;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\MainWindowUserControls\SelectActiveStaffMembersAndCabins\SelectActiveMembers\SelectActiveMembersControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox StaffSearchType;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\..\MainWindowUserControls\SelectActiveStaffMembersAndCabins\SelectActiveMembers\SelectActiveMembersControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView MemberList;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\..\MainWindowUserControls\SelectActiveStaffMembersAndCabins\SelectActiveMembers\SelectActiveMembersControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StaffSelectAll;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\..\..\MainWindowUserControls\SelectActiveStaffMembersAndCabins\SelectActiveMembers\SelectActiveMembersControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StaffDeselectAll;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\..\..\MainWindowUserControls\SelectActiveStaffMembersAndCabins\SelectActiveMembers\SelectActiveMembersControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StaffGoToFirst;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\..\..\MainWindowUserControls\SelectActiveStaffMembersAndCabins\SelectActiveMembers\SelectActiveMembersControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StaffGoToLast;
        
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
            System.Uri resourceLocater = new System.Uri("/StaffAssignmentProgram.ScheduleCreator;component/mainwindowusercontrols/selectac" +
                    "tivestaffmembersandcabins/selectactivemembers/selectactivememberscontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\MainWindowUserControls\SelectActiveStaffMembersAndCabins\SelectActiveMembers\SelectActiveMembersControl.xaml"
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
            this.StaffSearch = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.StaffSearchType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.MemberList = ((System.Windows.Controls.ListView)(target));
            return;
            case 4:
            this.StaffSelectAll = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.StaffDeselectAll = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.StaffGoToFirst = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.StaffGoToLast = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
