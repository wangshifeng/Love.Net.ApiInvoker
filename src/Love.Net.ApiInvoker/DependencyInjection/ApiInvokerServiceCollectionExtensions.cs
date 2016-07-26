// Copyright (c) lovedotnet team. All rights reserved.

using System;
using Love.Net.ApiInvoker;
using Love.Net.Core;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection {
    /// <summary>
    /// Contains extension methods to <see cref="IServiceCollection"/> for configuring identity services.
    /// </summary>
    public static class ApiInvokerServiceCollectionExtensions {
        /// <summary>
        /// Adds the API invoker to <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The services available in the application.</param>
        /// <param name="setupAction">An action to configure the <see cref="ApiInvokerOptions"/>.</param>
        /// <returns>An <see cref="ApiInvokerBuilder"/> for creating and configuring the identity system.</returns>
        public static ApiInvokerBuilder AddApiInvoker(this IServiceCollection services, Action<ApiInvokerOptions> setupAction) {
            if (services == null) {
                throw new ArgumentNullException(nameof(services));
            }
            if (setupAction == null) {
                throw new ArgumentNullException(nameof(setupAction));
            }
            services.Configure(setupAction);

            // No interface for the error describer so we can add errors without rev'ing the interface
            services.TryAddScoped<InvokeErrorDescriber>();

            var options = new ApiInvokerOptions();
            // setup it.
            setupAction(options);

            if (IsHttpPath(options.SendEmailApi)) {
                services.AddTransient<IEmailSender, ApiInvoker>();
            }
            if (IsHttpPath(options.SendSmsApi)) {
                services.AddTransient<ISmsSender, ApiInvoker>();
            }
            if (IsHttpPath(options.AppPushApi)) {
                services.AddTransient<IAppPush, ApiInvoker>();
            }

            return new ApiInvokerBuilder(services);
        }

        private static bool IsHttpPath(string api) {
            if (string.IsNullOrEmpty(api)) {
                return false;
            }

            try {
                Uri uri;
                if (Uri.TryCreate(api, UriKind.RelativeOrAbsolute, out uri)
                   &&
                  (uri.Scheme == "http" || uri.Scheme == "https")) {
                    return true;
                }

                return false;
            }
            catch {
                return false;
            }
        }
    }
}