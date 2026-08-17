const { validateUsername } = require('../js/validate');

describe('validateUsername', () => {
  test('rejects empty and whitespace-only', () => {
    expect(validateUsername('')).toBe(false);
    expect(validateUsername('   \t\n')).toBe(false);
  });

  test('accepts normal names', () => {
    expect(validateUsername('Alice')).toBe(true);
    expect(validateUsername(' José ')).toBe(true);
  });

  test('accepts unicode and emoji', () => {
    expect(validateUsername('ユーザー😀')).toBe(true);
  });

  test('rejects too long names and accepts boundary', () => {
    const long = 'a'.repeat(300);
    expect(validateUsername(long)).toBe(false);
    const ok = 'a'.repeat(256);
    expect(validateUsername(ok)).toBe(true);
  });

  test('non-string inputs return false', () => {
    expect(validateUsername(null)).toBe(false);
    expect(validateUsername(undefined)).toBe(false);
    expect(validateUsername(123)).toBe(false);
  });
});
