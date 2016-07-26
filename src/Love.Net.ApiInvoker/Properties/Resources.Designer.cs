using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Love.Net.ApiInvoker {
    /// <summary>
    ///    A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    internal class Resources {
        private static ResourceManager resourceMan;
        private static CultureInfo resourceCulture;
        
        internal Resources() {
        }
        
        /// <summary>
        ///    Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static ResourceManager ResourceManager {
            get {
                if (ReferenceEquals(resourceMan, null)) {
                    ResourceManager temp = new ResourceManager("Love.Net.ApiInvoker.Resources", typeof(Resources).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///    Overrides the current thread's CurrentUICulture property for all
        ///    resource lookups using this strongly typed resource class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to App push failure by invoking Api.
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
        ///    Looks up a localized string similar to Send email failure by invoking Api.
        /// </summary>
        public static string SendEmailFailure {
            get {
                return ResourceManager.GetString("SendEmailFailure", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Send SMS failure by invoking Api.
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
