﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UOGumpEditor {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.10.0.0")]
    internal sealed partial class UOSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static UOSettings defaultInstance = ((UOSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new UOSettings())));
        
        public static UOSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string UO_Folder {
            get {
                return ((string)(this["UO_Folder"]));
            }
            set {
                this["UO_Folder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("200")]
        public int DisplayMax {
            get {
                return ((int)(this["DisplayMax"]));
            }
            set {
                this["DisplayMax"] = value;
            }
        }
    }
}
