import React from "react";
import { render, screen } from "@testing-library/react";
import userEvent from "@testing-library/user-event";
import Home from "./Home";

describe("Home component", () => {
  test("renders header and main heading", () => {
    render(<Home />);
    expect(screen.getByAltText(/logo/i)).toBeInTheDocument();
    expect(screen.getByText(/welcome to the home page/i)).toBeInTheDocument();
  });

  test("shows message after clicking the button", async () => {
    const user = userEvent.setup();
    render(<Home />);
    expect(screen.queryByText(/you clicked the button/i)).not.toBeInTheDocument();
    await user.click(screen.getByRole('button', { name: /click me/i }));
    expect(screen.getByText(/you clicked the button/i)).toBeInTheDocument();
  });
});
