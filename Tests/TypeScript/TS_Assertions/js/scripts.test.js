const { validateForm } = require('./scripts');
// Mocking DOM elements
document.body.innerHTML = `
    <form id="registrationForm">
        <input type="text" id="username" name="username">
        <input type="email" id="email" name="email">
        <div id="errorMessages"></div>
        <div id="successMessage" style="display:none;"></div>
    </form>
`;
//
describe('Form Validation', () => {
    const usernameInput = document.getElementById('username');
    const emailInput = document.getElementById('email');
    const errorMessagesDiv = document.getElementById('errorMessages');
    const successMessageDiv = document.getElementById('successMessage');
    const form = document.getElementById('registrationForm');

    beforeEach(() => {
        // Reset form fields and user messages before each test
        usernameInput.value = '';
        emailInput.value = '';
        errorMessagesDiv.innerHTML = '';
        errorMessagesDiv.style.display = 'none';
        successMessageDiv.style.display = 'none';
    });

    test('should show error if username is empty', () => {
        usernameInput.value = '';
        emailInput.value = 'test@example.com';
        validateForm();
        expect(errorMessagesDiv.innerHTML).toContain('Username is required.');
        expect(errorMessagesDiv.style.display).toBe('block');
        expect(successMessageDiv.style.display).toBe('none');
    });

    test('should not show error if username is provided', () => {
        usernameInput.value = 'testuser';
        emailInput.value = 'test@example.com';
        validateForm();
        expect(errorMessagesDiv.innerHTML).not.toContain('Username is required.');
        expect(successMessageDiv.style.display).toBe('block');
    });

    test('should trim whitespace in username', () => {
        usernameInput.value = '   testuser   ';
        emailInput.value = 'test@example.com';
        validateForm();
        expect(errorMessagesDiv.innerHTML).not.toContain('Username is required.');
        expect(successMessageDiv.style.display).toBe('block');
    });

    test('should show error if both username and email are empty', () => {
        usernameInput.value = '';
        emailInput.value = '';
        validateForm();
        expect(errorMessagesDiv.innerHTML).toContain('Username is required.');
        expect(errorMessagesDiv.innerHTML).toContain('Email is required.');
        expect(successMessageDiv.style.display).toBe('none');
    });

    test('accepts valid alphanumeric username', () => {
        usernameInput.value = 'alice123';
        emailInput.value = 'test@example.com';
        validateForm();
        expect(errorMessagesDiv.innerHTML).not.toContain('Username is required.');
        expect(successMessageDiv.style.display).toBe('block');
    });

    // The project currently only validates presence and trims whitespace.
    // The following tests are desirable username rules but are not yet
    // enforced by `validateForm`. Marked as todos so they can be implemented
    // once the validation logic is extended.
    test.todo('rejects username shorter than minimum length (e.g. < 3)');
    test.todo('rejects username longer than maximum length (e.g. > 20)');
    test.todo('rejects usernames with invalid characters (e.g. $ or spaces)');
    test.todo('requires username to start with a letter');
    test.todo('rejects reserved usernames like admin or root');
    test.todo('rejects inputs containing XSS or SQL injection payloads');
    test.todo('defines policy for Unicode/emoji in usernames and enforces it');
    test.todo('handles duplicate username attempts (backend conflict)');
});

// We recommend installing an extension to run jest tests.
