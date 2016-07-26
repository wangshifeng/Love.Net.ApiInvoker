// Copyright (c) lovedotnet team. All rights reserved.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Love.Net.Core;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Love.Net.ApiInvoker {
    /// <summary>
    /// Represents the default implementation for interfaces defined in Love.Net.Core by invoking RESTful API.
    /// </summary>
    public class ApiInvoker : IEmailSender, ISmsSender, IAppPush {
        private readonly ApiInvokerOptions _options;
        private readonly InvokeErrorDescriber _errorDescriber;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiInvoker"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="describer">The <see cref="InvokeErrorDescriber"/>.</param>
        public ApiInvoker(IOptions<ApiInvokerOptions> options, InvokeErrorDescriber describer = null) {
            _options = options.Value;
            _errorDescriber = describer ?? new InvokeErrorDescriber();
        }

        /// <summary>
        /// Sends the email asynchronous.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="message">The message.</param>
        /// <returns>The <see cref="Task" /> represents the asynchronous operation, containing the <see cref="InvokeResult" /> of the operation.</returns>
        public async Task<InvokeResult> SendEmailAsync(string email, string subject, string message) {
            using (var http = new HttpClient()) {
                var headers = _options.HeaderRetriever(_options.SendEmailApi);
                foreach (var item in headers) {
                    http.DefaultRequestHeaders.Add(item.Item1, item.Item2);
                }
                var value = new { Email = email, Subject = subject, Message = message };
                var response = await http.PostAsJsonAsync(_options.SendEmailApi, value);
                if (!response.IsSuccessStatusCode) {
                    var invokeError = _errorDescriber.SendEmailFailure();
                    invokeError.Details = new [] {
                        new InvokeError {
                            Code = response.ReasonPhrase,
                            Message = await response.Content.ReadAsStringAsync()
                        }
                    };

                    return InvokeResult.Failed(invokeError);
                }

                return InvokeResult.Success;
            }
        }

        /// <summary>
        /// Sends the Sms message asynchronous.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="message">The message.</param>
        /// <returns>The <see cref="Task" /> represents the asynchronous operation, containing the <see cref="InvokeResult" /> of the operation.</returns>
        public async Task<InvokeResult> SendSmsAsync(string phoneNumber, string message) {
            using (var http = new HttpClient()) {
                var headers = _options.HeaderRetriever(_options.SendSmsApi);
                foreach (var item in headers) {
                    http.DefaultRequestHeaders.Add(item.Item1, item.Item2);
                }
                var value = new { PhoneNumber = phoneNumber, Message = message };
                var response = await http.PostAsJsonAsync(_options.SendSmsApi, value);
                if (!response.IsSuccessStatusCode) {
                    var invokeError = _errorDescriber.SendSmsFailure();
                    invokeError.Details = new[] {
                        new InvokeError {
                            Code = response.ReasonPhrase,
                            Message = await response.Content.ReadAsStringAsync()
                        }
                    };

                    return InvokeResult.Failed(invokeError);
                }

                return InvokeResult.Success;
            }
        }

        /// <summary>
        /// Sends the Sms message asynchronous.
        /// </summary>
        /// <param name="template">The template.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The <see cref="Task" /> represents the asynchronous operation, containing the <see cref="InvokeResult" /> of the operation.</returns>
        public async Task<InvokeResult> SendSmsAsync(string template, string phoneNumber, params Tuple<string, string>[] parameters) {
            using (var http = new HttpClient()) {
                var headers = _options.HeaderRetriever(_options.SendSmsApi);
                foreach (var item in headers) {
                    http.DefaultRequestHeaders.Add(item.Item1, item.Item2);
                }
                var value = new { Template = template, PhoneNumber = phoneNumber, Parameters = parameters.ToDictionary() };
                var response = await http.PostAsJsonAsync(_options.SendSmsApi, value);
                if (!response.IsSuccessStatusCode) {
                    var invokeError = _errorDescriber.SendSmsFailure();
                    invokeError.Details = new[] {
                        new InvokeError {
                            Code = response.ReasonPhrase,
                            Message = await response.Content.ReadAsStringAsync()
                        }
                    };

                    return InvokeResult.Failed(invokeError);
                }

                return InvokeResult.Success;
            }
        }

        /// <summary>
        /// Pushes the message to App asynchronous.
        /// </summary>
        /// <typeparam name="TMessage">The type of the message</typeparam>
        /// <param name="appId">The App identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns>The <see cref="Task" /> represents the asynchronous operation, containing the <see cref="InvokeResult" /> of the operation.</returns>
        public async Task<InvokeResult> PushMessageToAppAsync<TMessage>(string appId, TMessage message) where TMessage : class {
            using (var http = new HttpClient()) {
                var headers = _options.HeaderRetriever(_options.AppPushApi);
                foreach (var item in headers) {
                    http.DefaultRequestHeaders.Add(item.Item1, item.Item2);
                }
                var response = await http.PostAsync(_options.AppPushApi, GetHttpContent(appId, message));
                if (!response.IsSuccessStatusCode) {
                    var invokeError = _errorDescriber.AppPushFailure();
                    invokeError.Details = new[] {
                        new InvokeError {
                            Code = response.ReasonPhrase,
                            Message = await response.Content.ReadAsStringAsync()
                        }
                    };

                    return InvokeResult.Failed(invokeError);
                }

                return InvokeResult.Success;
            }
        }

        /// <summary>
        /// Pushes the message to list clients asynchronous.
        /// </summary>
        /// <typeparam name="TMessage">The type of the message</typeparam>
        /// <param name="appId">The App identifier.</param>
        /// <param name="message">The message.</param>
        /// <param name="targets">The target clients that message will be push to.</param>
        /// <returns>The <see cref="Task" /> represents the asynchronous operation, containing the <see cref="InvokeResult" /> of the operation.</returns>
        public async Task<InvokeResult> PushMessageToListAsync<TMessage>(string appId, TMessage message, params Target[] targets) where TMessage : class {
            if (targets.Length != 0 && targets.Any(t => string.IsNullOrEmpty(t.ClientId) && string.IsNullOrEmpty(t.Alias))) {
                return InvokeResult.Failed(_errorDescriber.TargetError());
            }

            using (var http = new HttpClient()) {
                var headers = _options.HeaderRetriever(_options.AppPushApi);
                foreach (var item in headers) {
                    http.DefaultRequestHeaders.Add(item.Item1, item.Item2);
                }
                var response = await http.PostAsync(_options.AppPushApi, GetHttpContent(appId, message, targets));
                if (!response.IsSuccessStatusCode) {
                    var invokeError = _errorDescriber.AppPushFailure();
                    invokeError.Details = new[] {
                        new InvokeError {
                            Code = response.ReasonPhrase,
                            Message = await response.Content.ReadAsStringAsync()
                        }
                    };

                    return InvokeResult.Failed(invokeError);
                }

                return InvokeResult.Success;
            }
        }

        private HttpContent GetHttpContent<TMessage>(string appId, TMessage message, params Target[] targets) where TMessage : class {
            using (var memory = new MemoryStream()) {
                using (var writer = new BinaryWriter(memory)) {
                    writer.Write(appId);

                    if (typeof(TMessage) == typeof(string)) {
                        writer.Write(message.ToString());
                    }
                    else {
                        var json = JsonConvert.SerializeObject(message, new JsonSerializerSettings {
                            DateFormatString = "yyyy-MM-dd HH:mm:ss"
                        });
                        writer.Write(json);
                    }

                    var length = targets.Length;
                    writer.Write(length);
                    foreach (var target in targets) {
                        writer.Write(target.ClientId ?? "");
                        writer.Write(target.Alias ?? "");
                    }
                }

                return new ByteArrayContent(memory.ToArray());
            }
        }
    }

    internal static class Extensions {
        public static Dictionary<string, string> ToDictionary(this Tuple<string, string>[] tuples) {
            var parameters = new Dictionary<string, string>();
            foreach (var item in tuples) {
                parameters[item.Item1] = item.Item2;
            }

            return parameters;
        }
    }
}
