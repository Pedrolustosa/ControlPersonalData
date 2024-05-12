namespace ControlPersonalData.Domain.Validation
{
    /// <summary>
    /// The domain exception validation.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="DomainExceptionValidation"/> class.
    /// </remarks>
    /// <param name="error">The error.</param>
    public class DomainExceptionValidation(string error) : Exception(error)
    {

        /// <summary>
        /// Validations
        /// </summary>
        /// <param name="hasError">If true, has error.</param>
        /// <param name="error">The error.</param>
        /// <exception cref="DomainExceptionValidation"></exception>
        public static void When(bool hasError, string error)
        {
            if (hasError) throw new DomainExceptionValidation(error);
        }
    }
}
