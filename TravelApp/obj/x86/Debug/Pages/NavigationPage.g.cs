﻿#pragma checksum "C:\Users\Brent\Documents\School\Windows\TravelApp\TravelApp\Pages\NavigationPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BCA593A79717B7A9239DCC8B3AFEC96BBF51EFF19BA467A96CBC5DCC383F0C85"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TravelApp.Pages
{
    partial class NavigationPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Pages\NavigationPage.xaml line 14
                {
                    this.Large = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 3: // Pages\NavigationPage.xaml line 26
                {
                    this.Medium = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 4: // Pages\NavigationPage.xaml line 38
                {
                    this.Small = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 5: // Pages\NavigationPage.xaml line 65
                {
                    this.PaneHeader = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6: // Pages\NavigationPage.xaml line 66
                {
                    this.Menu = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 7: // Pages\NavigationPage.xaml line 75
                {
                    this.BtnLogout = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.BtnLogout).Click += this.BtnLogout_Click;
                }
                break;
            case 9: // Pages\NavigationPage.xaml line 70
                {
                    global::Windows.UI.Xaml.Controls.Button element9 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element9).Click += this.Button_Click;
                }
                break;
            case 10: // Pages\NavigationPage.xaml line 81
                {
                    this.SplitViewFrame = (global::Windows.UI.Xaml.Controls.Frame)(target);
                    ((global::Windows.UI.Xaml.Controls.Frame)this.SplitViewFrame).Navigated += this.SplitViewFrame_OnNavigated;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
