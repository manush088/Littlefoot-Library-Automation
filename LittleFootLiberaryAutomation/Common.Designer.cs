﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LittleFootLiberaryAutomation {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.3.0.0")]
    internal sealed partial class Common : global::System.Configuration.ApplicationSettingsBase {
        
        private static Common defaultInstance = ((Common)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Common())));
        
        public static Common Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\\\Log\\\\LogTest")]
        public string LogFileLocation {
            get {
                return ((string)(this["LogFileLocation"]));
            }
            set {
                this["LogFileLocation"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\\\Form\\\\Web.html")]
        public string WebsiteURL {
            get {
                return ((string)(this["WebsiteURL"]));
            }
            set {
                this["WebsiteURL"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\\\Users\\\\manus\\\\source\\\\repos\\\\LittleFootLiberaryAutomation\\\\LittleFootLiberary" +
            "Automation\\\\TestData\\\\LibData.csv")]
        public string CSVFilePath {
            get {
                return ((string)(this["CSVFilePath"]));
            }
            set {
                this["CSVFilePath"] = value;
            }
        }
    }
}