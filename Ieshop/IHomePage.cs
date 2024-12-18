// --------------------------------------------------------------------------------------------------------------------
// © [Balla Bhargav], [2024]. All rights reserved.
// This code is the property of [Your Company Name] and is protected by copyright law. Unauthorized reproduction or
// distribution of this code, or any portion of it, may result in civil and criminal penalties and will be prosecuted
// to the maximum extent possible under the law.
// --------------------------------------------------------------------------------------------------------------------

namespace Ieshop
{
    public interface IHomePage
    {
        /// <summary>
        /// Navigates to the homepage.
        /// </summary>
        void NavigateToHomePage();

        /// <summary>
        /// Verifies if the image is displayed on the page.
        /// </summary>
        /// <returns>True if the image is displayed; otherwise, false.</returns>
        bool IsImageDisplayed();

        /// <summary>
        /// Gets the value of the 'src' attribute of the image.
        /// </summary>
        /// <returns>The 'src' attribute value.</returns>
        string GetImageSrc();

        /// <summary>
        /// Gets the value of the 'alt' attribute of the image.
        /// </summary>
        /// <returns>The 'alt' attribute value.</returns>
        string GetImageAlt();

        /// <summary>
        /// Gets the value of the 'class' attribute of the image.
        /// </summary>
        /// <returns>The 'class' attribute value.</returns>
        string GetImageClass();
    }
}
