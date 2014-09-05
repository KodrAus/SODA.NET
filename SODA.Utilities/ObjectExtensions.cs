using System;

namespace SODA.Utilities
{
    /// <summary>
    /// Extension methods for all objects.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// ToString that handles cases where the target is null.
        /// </summary>
        public static string SafeToString(this object target)
        {
            if (target != null)
                return target.ToString();
            else
                return String.Empty;
        }
    }
}
