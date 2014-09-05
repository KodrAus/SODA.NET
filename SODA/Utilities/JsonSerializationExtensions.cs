namespace SODA.Utilities
{
    /// <summary>
    /// Convenience methods for JSON serialization.
    /// </summary>
    public static class JsonSerializationExtensions
    {
        /// <summary>
        /// Serializes the target object into its JSON string representation.
        /// </summary>
        /// <returns>The serialized JSON string of the target object.</returns>
        public static string ToJsonString(this object target)
        {
            return target == null ? null : Newtonsoft.Json.JsonConvert.SerializeObject(target);
        }

        /// <summary>
        /// Deserializes the specified JSON string into an object of the specified .NET type.
        /// </summary>
        /// <returns>An object of type <typeparam name="T">T</typeparam>.</returns>
        internal static T deserializeJsonTo<T>(this string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }
    }
}
