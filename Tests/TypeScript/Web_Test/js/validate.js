document.addEventListener('DOMContentLoaded', () => {
  const form = document.getElementById('signupForm');
  const username = document.getElementById('username');
  const email = document.getElementById('email');
  const usernameError = document.getElementById('usernameError');
  const emailError = document.getElementById('emailError');

  function validateEmail(e){
    return /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(e);
  }

  form.addEventListener('submit', (ev) => {
    ev.preventDefault();
    let valid = true;
    usernameError.textContent = '';
    emailError.textContent = '';

      if (!validateUsername(username.value)){
        usernameError.textContent = 'Please enter your name.';
        valid = false;
      }

    if (!email.value.trim()){
      emailError.textContent = 'Please enter your email.';
      valid = false;
    } else if (!validateEmail(email.value.trim())){
      emailError.textContent = 'Please enter a valid email address.';
      valid = false;
    }

    if (valid){
      // Replace with real submission logic as needed
      alert('Form submitted successfully!');
      form.reset();
    }
  });
});

// Expose validator for testing and external use
function validateEmail(e){
  return /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(e);
}

if (typeof window !== 'undefined') {
  window.validateEmail = validateEmail;
}

if (typeof module !== 'undefined' && module.exports) {
  module.exports = { validateEmail };
}

// Username validator: non-empty after trimming, max length 256
function validateUsername(s){
  if (typeof s !== 'string') return false;
  const t = s.trim();
  return t.length > 0 && t.length <= 256;
}

if (typeof window !== 'undefined') {
  window.validateUsername = validateUsername;
}

if (typeof module !== 'undefined' && module.exports) {
  module.exports.validateUsername = validateUsername;
}
