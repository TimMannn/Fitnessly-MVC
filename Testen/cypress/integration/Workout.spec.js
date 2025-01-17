describe('Workout CRUD operations', () => {
    beforeEach(() => {
        cy.fixture('user').then((user) => {
            cy.login(user.username, user.password, user.rememberme);
        });
    });

    it('Should add a new workout', () => {
        cy.visit('https://localhost:3000/workout');
        cy.wait(1000);
        cy.get('#addworkout-button').click();
        cy.wait(1000);

        const workoutName = 'Cypress Test Workout';
        cy.get('input[placeholder="Enter workout name"]').type(workoutName);
        cy.wait(1000);
        cy.contains('Save Changes').click();

        cy.get('tbody tr').should('contain.text', workoutName);
        cy.contains('Workout has been added').should('be.visible');
        cy.wait(1000);
    });

    it('Should edit a existing workout', () => {
        cy.visit('https://localhost:3000/workout');
        cy.wait(1000);
        const updatedWorkoutName = 'Updated Cypress Workout';
        cy.contains('Cypress Test Workout')
            .parent('tr')
            .within(() => {
                cy.get('#edit-button').click();
            });
        cy.wait(1000);

        cy.get('input[placeholder="Enter workout name"]')
            .clear()
            .type(updatedWorkoutName);
        cy.wait(1000);
        cy.contains('Save Changes').click();

        cy.get('tbody tr').should('contain.text', updatedWorkoutName);
        cy.contains('Workout has been updated').should('be.visible');
        cy.wait(1000);
    });

    it('Should delete a workout', () => {
        cy.visit('https://localhost:3000/workout');
        cy.wait(1000);
        cy.contains('Updated Cypress Workout')
            .parent('tr')
            .within(() => {
                cy.get('#delete-button').click();
            });

        cy.get('tbody tr').should('not.contain.text', 'Updated Cypress Workout');
        cy.contains('Workout has been deleted').should('be.visible');
        cy.wait(1000);
    });
});
