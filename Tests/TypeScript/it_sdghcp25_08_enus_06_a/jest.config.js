module.exports = {
  testEnvironment: 'jsdom', // Use jsdom for React component testing
  testMatch: ['**/__tests__/**/*.test.js', '**/?(*.)+(spec|test).js'],
  verbose: true,
  setupFilesAfterEnv: ['<rootDir>/src/setupTests.js'], // Setup React Testing Library matchers
  transform: {
    '^.+\\.[jt]sx?$': 'babel-jest',
  },
  moduleNameMapper: {
    // Mock static assets (images, etc.)
    '\\.(gif|jpg|jpeg|png|svg|ico|bmp|webp|mp4|webm|wav|mp3|m4a|aac|oga)$': '<rootDir>/__mocks__/fileMock.js',
    '\\.(css|less|scss|sass)$': 'identity-obj-proxy',
  },
};