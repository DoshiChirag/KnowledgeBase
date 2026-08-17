import employee from './index';

describe('employee (Jest)', () => {
  test('has correct properties', () => {
    expect(employee.empName).toBe('John Doe');
    expect(employee.dependents).toBe(2);
    expect(employee.committees[0]).toBe('Philanthropy');
    expect(employee.committees[1]).toBe(true);
  });
});
