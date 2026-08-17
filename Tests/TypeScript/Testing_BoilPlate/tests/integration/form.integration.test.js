const fs = require('fs');
const path = require('path');
const { fireEvent } = require('@testing-library/dom');

const html = fs.readFileSync(path.resolve(__dirname, '../../index.html'), 'utf8');

describe('registration form integration', ()=>{
  beforeEach(()=>{
    document.documentElement.innerHTML = html;
    // load the script under test so it wires listeners
    require(path.resolve(__dirname, '../../js/validate.js'));
    // ensure DOMContentLoaded handlers run
    document.dispatchEvent(new Event('DOMContentLoaded'));
  });

  test('shows errors for invalid input and submits for valid input', ()=>{
    const username = document.getElementById('username');
    const email = document.getElementById('email');
    const form = document.getElementById('registrationForm');

    // invalid submission
    username.value = 'ab';
    email.value = 'bad-email';
    fireEvent.submit(form);
    expect(document.getElementById('usernameError').textContent).toMatch(/at least 3/);
    expect(document.getElementById('emailError').textContent).toMatch(/valid email/);

    // valid submission
    username.value = 'alice';
    email.value = 'alice@example.com';
    // intercept alert to avoid throwing in test
    const alerts = [];
    global.alert = (msg)=>alerts.push(msg);
    fireEvent.submit(form);
    expect(document.getElementById('usernameError').textContent).toBe('');
    expect(document.getElementById('emailError').textContent).toBe('');
    expect(alerts.length).toBe(1);
    expect(alerts[0]).toMatch(/Registration submitted/);
  });
});
