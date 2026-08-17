module.exports = {
  preset: 'ts-jest',
  testEnvironment: 'node',
  // Only run files named *.jest.test.ts to avoid picking up Vitest tests
  testMatch: ['**/*.jest.test.ts']
};
