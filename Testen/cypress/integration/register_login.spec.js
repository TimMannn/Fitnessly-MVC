describe('User Registration and Login', () => {

    const uniqueUser = `testuser_${new Date().getTime()}`

    it('should allow a user to register', () => {

        cy.intercept('POST', 'https://localhost:7187/api/Account/register').as('registerRequest')

        cy.visit('https://localhost:3000/register')
        cy.get('#username').type(uniqueUser)
        cy.get('#email').type('testuser@example.com')
        cy.get('#password').type('Testpassword123!')
        cy.get('#confirmPassword').type('Testpassword123!')
        cy.get('#register-button').click()

        cy.wait('@registerRequest').then((interception) => { expect(interception.response.statusCode).to.equal(200) })
    })

    it('should allow a user to login', () => {

        cy.intercept('POST', 'https://localhost:7187/api/Account/login').as('loginRequest')

        cy.visit('https://localhost:3000/login')
        cy.get('#username').type(uniqueUser)
        cy.get('#password').type('Testpassword123!')
        cy.get('#login-button').click()

        cy.wait('@loginRequest').then((interception) => { expect(interception.response.statusCode).to.equal(200) })
    })
})
