﻿#pragma checksum "..\..\..\Pages\CataloguePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9391CCB14218E1915CF041B63B43647E1077AEB436617BA83981A94387F2A10D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using RetrospektivaApp.Pages;
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


namespace RetrospektivaApp.Pages {
    
    
    /// <summary>
    /// CataloguePage
    /// </summary>
    public partial class CataloguePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 27 "..\..\..\Pages\CataloguePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockBasketInfo;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Pages\CataloguePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Badged BadgeBasketCount;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Pages\CataloguePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBasket;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Pages\CataloguePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBoxSearch;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Pages\CataloguePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboCategory;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Pages\CataloguePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboSort;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\Pages\CataloguePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LViewGoods;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\Pages\CataloguePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockCount;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\..\Pages\CataloguePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBoxSearchServices;
        
        #line default
        #line hidden
        
        
        #line 156 "..\..\..\Pages\CataloguePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboSortServices;
        
        #line default
        #line hidden
        
        
        #line 188 "..\..\..\Pages\CataloguePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBoxProducts;
        
        #line default
        #line hidden
        
        
        #line 220 "..\..\..\Pages\CataloguePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnPrev;
        
        #line default
        #line hidden
        
        
        #line 222 "..\..\..\Pages\CataloguePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBoxPageCount;
        
        #line default
        #line hidden
        
        
        #line 229 "..\..\..\Pages\CataloguePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnNext;
        
        #line default
        #line hidden
        
        
        #line 232 "..\..\..\Pages\CataloguePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockServicesCount;
        
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
            System.Uri resourceLocater = new System.Uri("/RetrospektivaApp;component/pages/cataloguepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\CataloguePage.xaml"
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
            
            #line 17 "..\..\..\Pages\CataloguePage.xaml"
            ((RetrospektivaApp.Pages.CataloguePage)(target)).IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.PageIsVisibleChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TextBlockBasketInfo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.BadgeBasketCount = ((MaterialDesignThemes.Wpf.Badged)(target));
            return;
            case 4:
            this.BtnBasket = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\Pages\CataloguePage.xaml"
            this.BtnBasket.Click += new System.Windows.RoutedEventHandler(this.BtnBasket_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TBoxSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 49 "..\..\..\Pages\CataloguePage.xaml"
            this.TBoxSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TBoxSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ComboCategory = ((System.Windows.Controls.ComboBox)(target));
            
            #line 54 "..\..\..\Pages\CataloguePage.xaml"
            this.ComboCategory.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboCategory_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ComboSort = ((System.Windows.Controls.ComboBox)(target));
            
            #line 57 "..\..\..\Pages\CataloguePage.xaml"
            this.ComboSort.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboSort_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.LViewGoods = ((System.Windows.Controls.ListView)(target));
            return;
            case 12:
            this.TextBlockCount = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 13:
            this.TBoxSearchServices = ((System.Windows.Controls.TextBox)(target));
            
            #line 147 "..\..\..\Pages\CataloguePage.xaml"
            this.TBoxSearchServices.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TBoxSearchServices_TextChanged);
            
            #line default
            #line hidden
            return;
            case 14:
            this.ComboSortServices = ((System.Windows.Controls.ComboBox)(target));
            
            #line 158 "..\..\..\Pages\CataloguePage.xaml"
            this.ComboSortServices.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboSortServices_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 15:
            this.ListBoxProducts = ((System.Windows.Controls.ListBox)(target));
            return;
            case 17:
            this.BtnPrev = ((System.Windows.Controls.Button)(target));
            
            #line 221 "..\..\..\Pages\CataloguePage.xaml"
            this.BtnPrev.Click += new System.Windows.RoutedEventHandler(this.BtnPrev_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            this.ListBoxPageCount = ((System.Windows.Controls.ListBox)(target));
            
            #line 222 "..\..\..\Pages\CataloguePage.xaml"
            this.ListBoxPageCount.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBoxPageCount_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 19:
            this.BtnNext = ((System.Windows.Controls.Button)(target));
            
            #line 230 "..\..\..\Pages\CataloguePage.xaml"
            this.BtnNext.Click += new System.Windows.RoutedEventHandler(this.BtnNext_Click);
            
            #line default
            #line hidden
            return;
            case 20:
            this.TextBlockServicesCount = ((System.Windows.Controls.TextBlock)(target));
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
            case 9:
            
            #line 115 "..\..\..\Pages\CataloguePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            break;
            case 10:
            
            #line 118 "..\..\..\Pages\CataloguePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            break;
            case 11:
            
            #line 124 "..\..\..\Pages\CataloguePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnAdd_Click);
            
            #line default
            #line hidden
            break;
            case 16:
            
            #line 202 "..\..\..\Pages\CataloguePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnBuy_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

