const { defineConfig } = require('cypress')

module.exports = defineConfig({
  projectId: '6ox71g',
    e2e: {
        setupNodeEvents(on, config) {
            // implement node event listeners here
        },
        specPattern: 'cypress/integration/*.spec.js',
    },
})
