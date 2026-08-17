const { validateEmail } = require('../js/validate');

describe('validateEmail', () => {
  test('accepts valid emails', () => {
    expect(validateEmail('user@example.com')).toBe(true);
    expect(validateEmail('first.last@sub.domain.co')).toBe(true);
  });

  test('rejects invalid emails', () => {
    expect(validateEmail('not-an-email')).toBe(false);
    expect(validateEmail('user@localhost')).toBe(false);
    expect(validateEmail('')).toBe(false);
  });
});
