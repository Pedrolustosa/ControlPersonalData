

namespace ControlPersonalData.Domain.Validation
{
    /// <summary>
    /// The domain exception validation.
    /// </summary>
    public class DomainExceptionValidation : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainExceptionValidation"/> class.
        /// </summary>
        /// <param name="error">The error.</param>
        public DomainExceptionValidation(string error) : base(error) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hasError">If true, has error.</param>
        /// <param name="error">The error.</param>
        /// <exception cref="DomainExceptionValidation"></exception>
        public static void When(bool hasError, string error)
        {
            if (hasError)
            {
                throw new DomainExceptionValidation(error);
            }
        }
    }
}
