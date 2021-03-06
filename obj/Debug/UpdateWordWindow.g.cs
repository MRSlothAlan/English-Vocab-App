#pragma checksum "..\..\UpdateWordWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "577E837F15600B228DCBBA293322203F1CEB7316"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using EngVocabApp;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace EngVocabApp {
    
    
    /// <summary>
    /// UpdateWordWindow
    /// </summary>
    public partial class UpdateWordWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\UpdateWordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal EngVocabApp.UpdateWordWindow UpdateWordWindow_Main;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\UpdateWordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label OriginalSpellingLabel;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\UpdateWordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label OriginalMeaningLabel;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\UpdateWordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UpdatedSpellingTextBox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\UpdateWordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UpdatedMeaningTextBox;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\UpdateWordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label OriginalIDLabel;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\UpdateWordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label isValidSpellingLabel;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\UpdateWordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Submit_Button;
        
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
            System.Uri resourceLocater = new System.Uri("/EngVocabApp;component/updatewordwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UpdateWordWindow.xaml"
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
            this.UpdateWordWindow_Main = ((EngVocabApp.UpdateWordWindow)(target));
            return;
            case 2:
            this.OriginalSpellingLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.OriginalMeaningLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.UpdatedSpellingTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\UpdateWordWindow.xaml"
            this.UpdatedSpellingTextBox.KeyUp += new System.Windows.Input.KeyEventHandler(this.UpdatedSpellingTextBox_KeyUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.UpdatedMeaningTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.OriginalIDLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.isValidSpellingLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.Submit_Button = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\UpdateWordWindow.xaml"
            this.Submit_Button.Click += new System.Windows.RoutedEventHandler(this.Submit_Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

