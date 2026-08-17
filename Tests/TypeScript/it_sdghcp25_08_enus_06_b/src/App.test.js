import React from 'react';
import { render, screen } from '@testing-library/react';
import App from './App';

test('renders Skillsoft Weight Tracker heading', () => {
  render(<App />);
  const headingElement = screen.getByText(/Skillsoft Weight Tracker/i);
  expect(headingElement).toBeInTheDocument();
});
