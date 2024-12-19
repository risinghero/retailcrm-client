using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Retailcrm.Versions.V5
{
    public partial class Client
    {
        /// <summary>
        /// Get delivery settings
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public new Task<Response> DeliverySettingGet(string code)
        {
            throw new ArgumentException("This method is unavailable in API V5", code);
        }

        /// <summary>
        /// Update delivery settings
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public new Task<Response> DeliverySettingsEdit(Dictionary<string, object> configuration)
        {
            throw new ArgumentException("This method is unavailable in API V5");
        }
    }
}
