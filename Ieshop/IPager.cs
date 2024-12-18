// --------------------------------------------------------------------------------------------------------------------
// © [Balla Bhargav], [2024]. All rights reserved.
// This code is the property of [Your Company Name] and is protected by copyright law. Unauthorized reproduction or
// distribution of this code, or any portion of it, may result in civil and criminal penalties and will be prosecuted
// to the maximum extent possible under the law.
// --------------------------------------------------------------------------------------------------------------------
namespace Ieshop
{
    public interface IPager
    {
        /// <summary>
        /// Checks if the 'Previous' link is displayed.
        /// </summary>
        /// <returns>True if the 'Previous' link is displayed; otherwise, false.</returns>
        bool IsPreviousLinkDisplayed();

        /// <summary>
        /// Checks if the 'Previous' link is enabled.
        /// </summary>
        /// <returns>True if the 'Previous' link is enabled; otherwise, false.</returns>
        bool IsPreviousLinkEnabled();

        /// <summary>
        /// Checks if the 'Next' link is displayed.
        /// </summary>
        /// <returns>True if the 'Next' link is displayed; otherwise, false.</returns>
        bool IsNextLinkDisplayed();

        /// <summary>
        /// Checks if the 'Next' link is enabled.
        /// </summary>
        /// <returns>True if the 'Next' link is enabled; otherwise, false.</returns>
        bool IsNextLinkEnabled();

        /// <summary>
        /// Clicks the 'Previous' link.
        /// </summary>
        void ClickPrevious();

        /// <summary>
        /// Clicks the 'Next' link.
        /// </summary>
        void ClickNext();

        /// <summary>
        /// Gets the current URL after navigation.
        /// </summary>
        string GetCurrentUrl();

        /// <summary>
        /// Checks if the current URL matches the expected URL or contains a specific substring.
        /// </summary>
        /// <param name="expectedPartialUrl">The expected substring of the URL.</param>
        /// <returns>True if the current URL matches or contains the expected substring; otherwise, false.</returns>
        bool IsCurrentUrl(string expectedPartialUrl);
    }
}
