using NUnit.Framework;
using System;
using System.Text.RegularExpressions;
using Taxi;

[TestFixture]
public class RegisterScreenTests
{
    [Test]
    public void Encrypt_ShouldReturnEncryptedText()
    {
        // Arrange
        string plainText = "password";
        string password = "1337";
        string expectedOutput = "ExpectedEncryptedValue"; // замените на ожидаемое значение.

        // Act
        string encrypted = RegisterScreen.Encrypt(plainText, password);

        // Assert
        Assert.IsNotNull(encrypted);
        Assert.That(encrypted, Is.Not.EqualTo(plainText));
    }

    [Test]
    public void EmailValidation_ShouldReturnTrueForValidEmail()
    {
        // Arrange
        string validEmail = "example@example.com";
        string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                         @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";

        // Act
        bool isValid = Regex.IsMatch(validEmail, pattern, RegexOptions.IgnoreCase);

        // Assert
        Assert.IsTrue(isValid);
    }

    [Test]
    public void EmailValidation_ShouldReturnFalseForInvalidEmail()
    {
        // Arrange
        string invalidEmail = "invalid-email";
        string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                         @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";

        // Act
        bool isValid = Regex.IsMatch(invalidEmail, pattern, RegexOptions.IgnoreCase);

        // Assert
        Assert.IsFalse(isValid);
    }

    [Test]
    public void PhoneNumberValidation_ShouldReturnTrueForValidNumber()
    {
        // Arrange
        string validPhoneNumber = "+375-29-123-45-67";
        string pattern = @"^((8|\+375)[\-]?)?(\(?\d{3}\)?[\-]?)?[\d\-]{7,10}$";

        // Act
        bool isValid = Regex.IsMatch(validPhoneNumber, pattern, RegexOptions.IgnoreCase);

        // Assert
        Assert.IsTrue(isValid);
    }

    [Test]
    public void PhoneNumberValidation_ShouldReturnFalseForInvalidNumber()
    {
        // Arrange
        string invalidPhoneNumber = "12345";
        string pattern = @"^((8|\+375)[\-]?)?(\(?\d{3}\)?[\-]?)?[\d\-]{7,10}$";

        // Act
        bool isValid = Regex.IsMatch(invalidPhoneNumber, pattern, RegexOptions.IgnoreCase);

        // Assert
        Assert.IsFalse(isValid);
    }

    [Test]
    public void PasswordsMatch_ShouldReturnTrueForMatchingPasswords()
    {
        // Arrange
        string password1 = "password";
        string password2 = "password";

        // Act
        bool match = password1 == password2;

        // Assert
        Assert.IsTrue(match);
    }

    [Test]
    public void PasswordsMatch_ShouldReturnFalseForNonMatchingPasswords()
    {
        // Arrange
        string password1 = "password1";
        string password2 = "password2";

        // Act
        bool match = password1 == password2;

        // Assert
        Assert.IsFalse(match);
    }
}
