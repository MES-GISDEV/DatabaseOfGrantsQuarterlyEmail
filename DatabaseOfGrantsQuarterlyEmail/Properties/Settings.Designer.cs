//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseOfGrantsQuarterlyEmail.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("o365-exchange.menv.com")]
        public string SMTPClient {
            get {
                return ((string)(this["SMTPClient"]));
            }
            set {
                this["SMTPClient"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("bh1rM/242zgwBkDIvkChDOt/JoqpuDOnAzEsty+ATv++yqny8UFAx2zLNCkKCy33K072yLW3SomqauPri" +
            "N/Rxonbx3YS0vglnJBIH/dc4hnAGgSEnbmSzHRDJxohhFf2")]
        public string MyConnection {
            get {
                return ((string)(this["MyConnection"]));
            }
            set {
                this["MyConnection"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("bh1rM/242zgwBkDIvkChDIJFvsWqS8xwAzEsty+ATv++yqny8UFAx2zLNCkKCy33qmrj64jf0caJ28d2E" +
            "tL4JZyQSB/3XOIZwBoEhJ25ksx0QycaIYRX9g==")]
        public string MyProduction {
            get {
                return ((string)(this["MyProduction"]));
            }
            set {
                this["MyProduction"] = value;
            }
        }
    }
}
