using System;
using Zohal.Constants;
using Zohal.Enums;

namespace Zohal.Infrastructure
{
    /// <summary>
    /// تعیین کننده اندپوینت استعلام قبض بر اساس اپراتور
    /// </summary>
    public static class SimCardBillEndpointResolver
    {
        /// <summary>
        /// دریافت اندپوینت مناسب برای استعلام قبض
        /// </summary>
        /// <param name="operatorType">نوع اپراتور</param>
        /// <returns>آدرس اندپوینت</returns>
        /// <exception cref="NotSupportedException">
        /// زمانی که اپراتور پشتیبانی نشود
        /// </exception>
        public static string Resolve(SimCardOperatorType operatorType)
        {
            return operatorType switch
            {
                SimCardOperatorType.HamrahAval => ZohalEndpoints.MciBill,

                SimCardOperatorType.Irancell => ZohalEndpoints.IrancellBill,

                SimCardOperatorType.Rightel => ZohalEndpoints.RightelBill,

                SimCardOperatorType.FixedLine => ZohalEndpoints.FixedLineBill,

                _ => throw new NotSupportedException(
                    $"Operator '{operatorType}' is not supported for bill inquiry.")
            };
        }
    }
}
