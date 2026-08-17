import { employee, weekDays } from './index';

describe('integration: enum consumption', () => {
  test('employee.payDay uses weekDays enum', () => {
    expect(employee.payDay).toBe(weekDays.Friday);
    expect(Object.values(weekDays)).toContain(employee.payDay);
  });
});
