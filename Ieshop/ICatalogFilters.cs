// --------------------------------------------------------------------------------------------------------------------
// © [Balla Bhargav], [2024]. All rights reserved.
// This code is the property of [Your Company Name] and is protected by copyright law. Unauthorized reproduction or
// distribution of this code, or any portion of it, may result in civil and criminal penalties and will be prosecuted
// to the maximum extent possible under the law.
// --------------------------------------------------------------------------------------------------------------------

namespace Ieshop
{
    /// <summary>
    /// Interface for managing catalog filters on the website.
    /// </summary>
    public interface ICatalogFilters
    {
        /// <summary>
        /// Sets the brand filter based on the specified brand value.
        /// </summary>
        /// <param name="brandValue">The brand value to filter by.</param>
        void SetBrandFilter(string brandValue);

        /// <summary>
        /// Sets the type filter based on the specified type value.
        /// </summary>
        /// <param name="typeValue">The type value to filter by.</param>
        void SetTypeFilter(string typeValue);

        /// <summary>
        /// Submits the selected filters.
        /// </summary>
        void SubmitFilters();

        /// <summary>
        /// Gets the current URL of the page.
        /// </summary>
        /// <returns>The current URL as a string.</returns>
        string GetCurrentUrl();

        /// <summary>
        /// Verifies if the current URL contains the expected partial URL.
        /// </summary>
        /// <param name="expectedPartialUrl">The expected partial URL as a string.</param>
        /// <returns>True if the URL contains the expected partial URL; otherwise, false.</returns>
        bool IsCurrentUrl(string expectedPartialUrl);

        /// <summary>
        /// Waits until the current URL contains the expected partial URL.
        /// </summary>
        /// <param name="expectedPartialUrl">The expected partial URL as a string.</param>
        /// <param name="timeoutSeconds">The maximum amount of time to wait, in seconds. Default is 10 seconds.</param>
        void WaitForUrlToContain(string expectedPartialUrl, int timeoutSeconds = 10);

        /// <summary>
        /// Navigates to the next page of the catalog.
        /// </summary>
        void NavigateToNextPage();

        /// <summary>
        /// Navigates to the previous page of the catalog.
        /// </summary>
        void NavigateToPreviousPage();
    }
}
