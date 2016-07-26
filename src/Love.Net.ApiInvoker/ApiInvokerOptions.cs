// Copyright (c) lovedotnet team. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Love.Net.ApiInvoker {
    /// <summary>
    /// Represents all the options you can use to configure the <see cref="ApiInvoker"/>.
    /// </summary>
    public class ApiInvokerOptions {
        /// <summary>
        /// Gets or sets the send Sms API URL.
        /// </summary>
        /// <value>The send Sms API URL.</value>
        public string SendSmsApi { get; set; }
        /// <summary>
        /// Gets or sets the send email API URL.
        /// </summary>
        /// <value>The send email API URL.</value>
        public string SendEmailApi { get; set; }
        /// <summary>
        /// Gets or sets the App push API URL.
        /// </summary>
        /// <value>The App push API URL.</value>
        public string AppPushApi { get; set; }
        /// <summary>
        /// Gets or sets the header retriever.
        /// </summary>
        /// <value>The header retriever.</value>
        public Func<string, IEnumerable<Tuple<string, string>>> HeaderRetriever { get; set; } = (api) => Enumerable.Empty<Tuple<string, string>>();
    }
}
