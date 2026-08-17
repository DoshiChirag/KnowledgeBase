import React from "react";
import { render, screen, fireEvent } from "@testing-library/react";
import Home from "./Home";

describe("Home component", () => {
  test("renders header logo and title", () => {
    render(<Home />);
    // header logo image
    expect(screen.getByAltText(/logo/i)).toBeInTheDocument();
    // header title text
    expect(screen.getByText(/skillsoft weight tracker/i)).toBeInTheDocument();
  });

  test("renders main heading and container", () => {
    const { container } = render(<Home />);
    // Main heading from Main.js
    expect(screen.getByText(/how to participate in the program/i)).toBeInTheDocument();
    // Container div with id 'container'
    expect(container.querySelector('#container')).toBeInTheDocument();
  });

  test("renders aside and footer content", () => {
    render(<Home />);
    expect(screen.getByText(/health news/i)).toBeInTheDocument();
    expect(screen.getByText(/copyright/i)).toBeInTheDocument();
  });
});
