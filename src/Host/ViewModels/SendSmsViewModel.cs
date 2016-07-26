using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Host.ViewModels {
    public class SendSmsViewModel {
        public string Message { get; set; }
        public string Template { get; set; }
        public string PhoneNumber { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
    }
}
