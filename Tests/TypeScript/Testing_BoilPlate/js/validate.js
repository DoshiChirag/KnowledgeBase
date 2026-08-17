const validators = (typeof require === 'function' && typeof module !== 'undefined') ? require('./validators') : (window.validators || { validateEmail: (v) => /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(v) });

document.addEventListener('DOMContentLoaded', ()=>{
  const form = document.getElementById('registrationForm');
  const username = document.getElementById('username');
  const email = document.getElementById('email');
  const usernameError = document.getElementById('usernameError');
  const emailError = document.getElementById('emailError');

  form.addEventListener('submit', (e)=>{
    let ok = true;
    usernameError.textContent = '';
    emailError.textContent = '';

    if(!username.value || username.value.trim().length < 3){
      usernameError.textContent = 'Enter at least 3 characters.';
      ok = false;
    }

    if(!email.value || !validators.validateEmail(email.value)){
      emailError.textContent = 'Enter a valid email address.';
      ok = false;
    }

    if(!ok){
      e.preventDefault();
    } else {
      // For demo purposes prevent actual submission and show a message
      e.preventDefault();
      alert('Registration submitted: ' + username.value + ' — ' + email.value);
      form.reset();
    }
  });
});