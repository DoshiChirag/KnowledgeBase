document.addEventListener('DOMContentLoaded', () => {
    const form = document.getElementById('registrationForm');
    if (form) {
        form.addEventListener('submit', validateForm);
    }
});

function validateForm(event) {
    if (event) {
        event.preventDefault(); // Prevent actual form submission
    }

    const usernameInput = document.getElementById('username');
    const emailInput = document.getElementById('email');
    const errorMessagesDiv = document.getElementById('errorMessages');
    const successMessageDiv = document.getElementById('successMessage');

    let errors = [];
    errorMessagesDiv.innerHTML = ''; // Clear any previous errors
    successMessageDiv.style.display = 'none'; // Hide the success message

    const username = usernameInput ? usernameInput.value.trim() : '';
    const email = emailInput ? emailInput.value.trim() : '';

    if (username === '') {
        errors.push('Username is required.');
    }

    if (email === '') {
        errors.push('Email is required.');
    } else {
        // Basic email validation
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!emailRegex.test(email)) {
            errors.push('Invalid email format.');
        }
    }

    if (errors.length > 0) {
        errorMessagesDiv.innerHTML = errors.join('<br>');
        errorMessagesDiv.style.display = 'block';
    } else {
        successMessageDiv.innerHTML = 'Form submitted successfully!';
        successMessageDiv.style.display = 'block';
        errorMessagesDiv.style.display = 'none';
    }
}

// Export form validation function for testing purposes only
if (typeof module !== 'undefined' && module.exports) {
    module.exports = { validateForm };
}
