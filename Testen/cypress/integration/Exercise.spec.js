describe('Exercise CRUD operations', () => {
    beforeEach(() => {
        // Log in als een gebruiker
        cy.fixture('user').then((user) => {
            cy.login(user.username, user.password, user.rememberme);
        });

        // Laad de workout fixture en gebruik de juiste Id en Name
        cy.fixture('workout').then((workout) => {
            cy.visit(`https://localhost:3000/exercise/${workout.Id}/${workout.Name}`);
        });

        cy.wait(1000);
    });


    it('Should add a new exercise', () => {
        // Open de modal om een nieuwe oefening toe te voegen
        cy.get('#addexercise-button').click();
        cy.wait(1000);

        // Vul de oefeningsgegevens in en sla op
        const exerciseName = 'Cypress Test Exercise';
        const gewicht = '20';
        const sets = '3';
        const reps = '10';

        cy.get('input[placeholder="Enter exercise name"]').type(exerciseName);
        cy.wait(500);
        cy.get('input[placeholder="Enter weight"]').type(gewicht);
        cy.wait(500);
        cy.get('input[placeholder="Enter sets"]').type(sets);
        cy.wait(500);
        cy.get('input[placeholder="Enter reps"]').type(reps);
        cy.wait(1000);
        cy.get('#toevoegen-button').click();

        // Controleer of de oefening is toegevoegd aan de lijst
        cy.get('tbody tr').should('contain.text', exerciseName);
        cy.contains('Exercise has been added').should('be.visible');
        cy.wait(1000);
    });

    it('Should edit a existing exercise', () => {
        // Zoek de oefening die bewerkt moet worden
        const updatedExerciseName = 'Updated Cypress Exercise';
        cy.contains('Cypress Test Exercise')
            .parent('tr')
            .within(() => {
                cy.get('#editexercise-button').click();
            });

        cy.wait(1000);

        // Bewerk de oefeningsdetails
        cy.get('input[placeholder="Enter exercise name"]').clear().type(updatedExerciseName);
        cy.wait(500);
        cy.get('input[placeholder="Enter weight"]').clear().type('25');
        cy.wait(500);
        cy.get('input[placeholder="Enter sets"]').clear().type('4');
        cy.wait(500);
        cy.get('input[placeholder="Enter reps"]').clear().type('12');
        cy.wait(1000);
        cy.get('#saveexercise-button').click();

        // Controleer of de oefening is bijgewerkt
        cy.get('tbody tr').should('contain.text', updatedExerciseName);
        cy.contains('Exercise has been updated').should('be.visible');
        cy.wait(1000);
    });

    it('Should delete an exercise', () => {
        // Zoek de oefening die verwijderd moet worden
        cy.contains('Updated Cypress Exercise')
            .parent('tr')
            .within(() => {
                cy.get('#deleteexercise-button').click();
            });

        // Controleer of de oefening is verwijderd
        cy.get('tbody tr').should('not.contain.text', 'Updated Cypress Exercise');
        cy.contains('Exercise has been deleted').should('be.visible');
        cy.wait(1000);
    });
});
