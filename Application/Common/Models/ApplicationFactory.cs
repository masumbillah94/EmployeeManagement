namespace Application.Common.Models
{
    internal static class ApplicationFactory
    {
        #region Internal Methods

        internal static ResponseDetail<T> CreateResponseDetails<T>()
        {
            return new ResponseDetail<T>();
        }

        #endregion Internal Methods
    }
}
