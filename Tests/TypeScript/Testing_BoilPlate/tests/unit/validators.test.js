const path = require('path');
const validators = require(path.resolve(__dirname, '../../js/validators.js'));

describe('validators.validateEmail', ()=>{
  test('accepts valid emails', ()=>{
    expect(validators.validateEmail('alice@example.com')).toBe(true);
    expect(validators.validateEmail('user.name+tag@sub.domain.co')).toBe(true);
  });

  test('rejects invalid emails', ()=>{
    expect(validators.validateEmail('not-an-email')).toBe(false);
    expect(validators.validateEmail('missing@domain')).toBe(false);
  });
});
