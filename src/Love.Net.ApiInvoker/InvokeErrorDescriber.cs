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
        /// <returns>An <see cref="InvokeError"/> indicating the send email failure.</returns>
        public virtual InvokeError SendEmailFailure() {
            return new InvokeError {
                Code = nameof(SendEmailFailure),
                Message = Resources.SendEmailFailure
            };
        }

        /// <summary>
        /// Returns an <see cref="InvokeError"/> indicating the send SMS failure.
        /// </summary>
        /// <returns>An <see cref="InvokeError"/> indicating the send SMS failure.</returns>
        public virtual InvokeError SendSmsFailure() {
            return new InvokeError {
                Code = nameof(SendSmsFailure),
                Message = Resources.SendSmsFailure
            };
        }

        /// <summary>
        /// Returns an <see cref="InvokeError"/> indicating the app push failure.
        /// </summary>
        /// <returns>An <see cref="InvokeError"/> indicating the app push failure.</returns>
        public virtual InvokeError AppPushFailure() {
            return new InvokeError {
                Code = nameof(SendSmsFailure),
                Message = Resources.AppPushFailure
            };
        }

        /// <summary>
        /// Returns an <see cref="InvokeError"/> indicating the <see cref="Target"/> is invalid.
        /// </summary>
        /// <returns>An <see cref="InvokeError"/> indicating the <see cref="Target"/> is invalid.</returns>
        public virtual InvokeError TargetError() {
            return new InvokeError {
                Code = nameof(Target),
                Message = Resources.TargetError
            };
        }
    }
}
