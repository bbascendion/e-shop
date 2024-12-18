// --------------------------------------------------------------------------------------------------------------------
// © [Sampath Palaniappan], [2024]. All rights reserved.
// This code is the property of [Your Company Name] and is protected by copyright law. Unauthorized reproduction or
// distribution of this code, or any portion of it, may result in civil and criminal penalties and will be prosecuted
// to the maximum extent possible under the law.
// --------------------------------------------------------------------------------------------------------------------

public interface IPasswordResetPage
{
    /// <summary>
    /// Navigate to the login page.
    /// </summary>
    void NavigateToLoginPage();

    /// <summary>
    /// Click the "Forgot your password?" link on the login page.
    /// </summary>
    void ClickForgotPasswordLink();

    /// <summary>
    /// Enter an email address in the "Forgot Password" form.
    /// </summary>
    /// <param name="email">The email address to enter.</param>
    void EnterEmail(string email);

    /// <summary>
    /// Click the "Reset Password" button on the "Forgot Password" page.
    /// </summary>
    void ClickResetPasswordButton();

    /// <summary>
    /// Get the confirmation message displayed after initiating a password reset.
    /// </summary>
    /// <returns>The confirmation message text.</returns>
    string GetConfirmationMessage();

    /// <summary>
    /// Get the header text on the "Forgot Password" page (e.g., "Forgot password confirmation").
    /// </summary>
    /// <returns>The header text.</returns>
    string GetHeader();

    /// <summary>
    /// Get the error message if the entered email address is invalid.
    /// </summary>
    /// <returns>The error message text.</returns>
    string GetErrorMessage();

    /// <summary>
    /// Get the alt text of the image displayed on the "Forgot Password" page (e.g., "eShop On Web").
    /// </summary>
    /// <returns>The alt text of the image.</returns>
    string GetImageAltText();
}
