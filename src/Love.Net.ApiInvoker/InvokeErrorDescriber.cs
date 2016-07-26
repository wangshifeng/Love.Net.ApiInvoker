// Copyright (c) lovedotnet team. All rights reserved.

using Love.Net.Core;

namespace Love.Net.ApiInvoker {
    public class InvokeErrorDescriber {
        /// <summary>
        /// Returns the default <see cref="InvokeError"/>.
        /// </summary>
        /// <returns>The default <see cref="InvokeError"/>,</returns>
        public virtual InvokeError DefaultError() {
            return new InvokeError {
                Code = nameof(DefaultError),
                Message = Resources.DefaultError
            };
        }

        /// <summary>
        /// Returns an <see cref="InvokeError"/> indicating the send email failure.
        /// </summary>
        /// <param name="sendEmailApi">The send email API.</param>
        /// <returns>An <see cref="InvokeError"/> indicating the send email failure.</returns>
        public virtual InvokeError SendEmailFailure(string sendEmailApi) {
            return new InvokeError {
                Code = nameof(SendEmailFailure),
                Message = string.Format(Resources.SendEmailFailure, sendEmailApi)
            };
        }

        /// <summary>
        /// Returns an <see cref="InvokeError"/> indicating the send SMS failure.
        /// </summary>
        /// <param name="sendSmsApi">The send SMS API.</param>
        /// <returns>An <see cref="InvokeError"/> indicating the send SMS failure.</returns>
        public virtual InvokeError SendSmsFailure(string sendSmsApi) {
            return new InvokeError {
                Code = nameof(SendSmsFailure),
                Message = string.Format(Resources.SendSmsFailure, sendSmsApi)
            };
        }

        /// <summary>
        /// Returns an <see cref="InvokeError"/> indicating the app push failure.
        /// </summary>
        /// <param name="appPushApi">The app push API.</param>
        /// <returns>An <see cref="InvokeError"/> indicating the app push failure.</returns>
        public virtual InvokeError AppPushFailure(string appPushApi) {
            return new InvokeError {
                Code = nameof(SendSmsFailure),
                Message = string.Format(Resources.SendSmsFailure, appPushApi)
            };
        }

        public virtual InvokeError TargetError() {
            return new InvokeError {
                Code = nameof(Target),
                Message = Resources.TargetError
            };
        }
    }
}
