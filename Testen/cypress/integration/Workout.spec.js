describe('Workout CRUD operations', () => {
    beforeEach(() => {
        // Gebruik de login-command
        cy.fixture('user').then((user) => {
            cy.login(user.username, user.password, user.rememberme);
        });
    });

    it('Should add a new workout', () => {
        // Bezoek de workout pagina
        cy.visit('https://localhost:3000/workout');
        // Open de modal om een nieuwe workout toe te voegen
        cy.get('#addworkout-button').click();
        cy.wait(1000);

        // Vul workout details in en sla op
        const workoutName = 'Cypress Test Workout';
        cy.get('input[placeholder="Enter workout name"]').type(workoutName);
        cy.wait(1000);
        cy.contains('Save Changes').click();

        // Controleer of de workout is toegevoegd aan de lijst
        cy.get('tbody tr').should('contain.text', workoutName);
        cy.contains('Workout has been added').should('be.visible');
        cy.wait(1000);
    });

    it('Should edit a existing workout', () => {
        // Bezoek de workout pagina
        cy.visit('https://localhost:3000/workout');
        cy.wait(1000);
        // Zoek de workout die bewerkt moet worden
        const updatedWorkoutName = 'Updated Cypress Workout';
        cy.contains('Cypress Test Workout')
            .parent('tr')
            .within(() => {
                cy.get('#edit-button').click();
            });
        cy.wait(1000);

        // Bewerk de workout details
        cy.get('input[placeholder="Enter workout name"]')
            .clear()
            .type(updatedWorkoutName);
        cy.wait(1000);
        cy.contains('Save Changes').click();

        // Controleer of de workout is bijgewerkt
        cy.get('tbody tr').should('contain.text', updatedWorkoutName);
        cy.contains('Workout has been updated').should('be.visible');
        cy.wait(1000);
    });

    it('Should delete a workout', () => {
        // Bezoek de workout pagina
        cy.visit('https://localhost:3000/workout');
        cy.wait(1000);
        // Zoek de workout die verwijderd moet worden
        cy.contains('Updated Cypress Workout')
            .parent('tr')
            .within(() => {
                cy.get('#delete-button').click();
            });

        // Controleer of de workout is verwijderd
        cy.get('tbody tr').should('not.contain.text', 'Updated Cypress Workout');
        cy.contains('Workout has been deleted').should('be.visible');
        cy.wait(1000);
    });
});
