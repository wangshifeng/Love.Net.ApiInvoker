﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Love.Net.ApiInvoker {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///    A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        internal Resources() {
        }
        
        /// <summary>
        ///    Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Love.Net.ApiInvoker.Resources", typeof(Resources).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///    Overrides the current thread's CurrentUICulture property for all
        ///    resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to App push failure by invoking Api {0}.
        /// </summary>
        public static string AppPushFailure {
            get {
                return ResourceManager.GetString("AppPushFailure", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to An unknown failure has occurred..
        /// </summary>
        public static string DefaultError {
            get {
                return ResourceManager.GetString("DefaultError", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Send email failure by invoking Api {0}.
        /// </summary>
        public static string SendEmailFailure {
            get {
                return ResourceManager.GetString("SendEmailFailure", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Send SMS failure by invoking Api {0}.
        /// </summary>
        public static string SendSmsFailure {
            get {
                return ResourceManager.GetString("SendSmsFailure", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Target client id and alias cannot be empty at the same.
        /// </summary>
        public static string TargetError {
            get {
                return ResourceManager.GetString("TargetError", resourceCulture);
            }
        }
    }
}
