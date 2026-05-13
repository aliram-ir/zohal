using System;
using Zohal.Constants;
using Zohal.Enums;

namespace Zohal.Infrastructure
{
    public static class UtilityBillEndpointResolver
    {
        public static string Resolve(
            string billId,
            UtilityBillType? manualType = null)
        {
            // اولویت با انتخاب دستی
            if (manualType.HasValue)
            {
                return manualType.Value switch
                {
                    UtilityBillType.Gas => ZohalEndpoints.GasBill,

                    UtilityBillType.Water => ZohalEndpoints.WaterBill,

                    UtilityBillType.Electricity => ZohalEndpoints.ElectricityBill,

                    _ => throw new NotSupportedException(
                        $"Bill type '{manualType}' is not supported.")
                };
            }

            // تشخیص خودکار از روی شناسه قبض
            var prefix = billId[..1];

            return prefix switch
            {
                "1" => ZohalEndpoints.WaterBill,
                "2" => ZohalEndpoints.ElectricityBill,
                "3" => ZohalEndpoints.GasBill,

                _ => throw new NotSupportedException(
                    $"Bill id '{billId}' is not supported.")
            };
        }
    }
}
