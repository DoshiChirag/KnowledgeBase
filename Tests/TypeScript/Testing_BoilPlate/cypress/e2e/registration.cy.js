describe('Registration E2E', () => {
  before(() => {
    // Ensure server is running at http://localhost:5000 before running tests.
  });

  it('validates inputs and submits the form', () => {
    cy.visit('/');

    cy.get('#username').type('ab');
    cy.get('#email').type('bad-email');
    cy.get('button[type="submit"]').click();

    cy.get('#usernameError').should('contain.text', 'at least 3');
    cy.get('#emailError').should('contain.text', 'valid email');

    cy.get('#username').clear().type('alice');
    cy.get('#email').clear().type('alice@example.com');

    cy.window().then((win) => {
      cy.stub(win, 'alert').as('alert');
    });

    cy.get('button[type="submit"]').click();

    cy.get('@alert').should('have.been.calledOnce');
    cy.get('@alert').its('firstCall.args.0').should('include', 'Registration submitted');
  });
});
