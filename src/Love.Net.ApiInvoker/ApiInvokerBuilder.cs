// Copyright (c) lovedotnet team. All rights reserved.

using Microsoft.Extensions.DependencyInjection;

namespace Love.Net.ApiInvoker {
    /// <summary>
    /// Helper functions for configuring <see cref="ApiInvoker"/>.
    /// </summary>
    public class ApiInvokerBuilder {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiInvokerBuilder"/> class.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to attach to.</param>
        public ApiInvokerBuilder(IServiceCollection services) {
            Services = services;
        }

        /// <summary>
        /// Gets the <see cref="IServiceCollection"/> services are attached to.
        /// </summary>
        /// <value>
        /// The <see cref="IServiceCollection"/> services are attached to.
        /// </value>
        public IServiceCollection Services { get; }

        /// <summary>
        /// Adds an <see cref="InvokeErrorDescriber"/>.
        /// </summary>
        /// <typeparam name="TDescriber">The type of the error describer.</typeparam>
        /// <returns>The current <see cref="ApiInvokerBuilder"/> instance.</returns>
        public virtual ApiInvokerBuilder AddErrorDescriber<TDescriber>() where TDescriber : InvokeErrorDescriber {
            Services.AddScoped<InvokeErrorDescriber, TDescriber>();
            return this;
        }
    }
}
