using System;
using System.Collections.Generic;
using System.Text;

namespace Sign.Contract
{
    /// <summary>
    /// ResultCode
    /// </summary>
    public enum StatusCodeEnum
    {
        /// <summary>
        /// InvalidParameter
        /// </summary>
        InvalidParameter = -1,
        /// <summary>
        /// Signature Fail
        /// </summary>
        SignatureFail = -2,
        /// <summary>
        /// Success
        /// </summary>
        Success = 20000,
        /// <summary>
        /// Login Failed,
        /// </summary>
        LoginFailed = 30001,
        /// <summary>
        /// Update Data Failed，not exists data
        /// </summary>
        UpdateNoDataed = 30002,
        /// <summary>
        /// ServiceInternalError
        /// </summary>
        ServiceInternalError = 40000,
        /// <summary>
        /// The collection section failed to update
        /// </summary>
        ServiceListError = 40001,
        /// <summary>
        /// service overdue
        /// </summary>
        Serviceoverdue = 40004,
        /// <summary>
        /// service WebException
        /// </summary>
        ServiceWebException = 40005,


    }
}
