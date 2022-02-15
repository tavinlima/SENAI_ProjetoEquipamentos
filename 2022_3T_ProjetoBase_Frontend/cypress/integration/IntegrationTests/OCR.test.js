describe('Integração - OCR', () => {

    beforeEach(() => {
        cy.visit('http://localhost:3000/')
    });

    it('Deve logar e inserir a imagem ocr retornando o valor correto da mesma', () => {

        cy.get('.cabecalhoPrincipal-nav-login').should('exist');
        cy.get('.cabecalhoPrincipal-nav-login').click();

        cy.get('.input__login').first().type('paulo@email.com');
        cy.get('.input__login').last().type('123456789');
        cy.get('.btn__login').click();

        cy.get('input[type=file]').first().selectFile('src/assets/tests/equipamento_test.jpeg');

        cy.wait(3000)
        cy.get('#codigoPatrimonio').should('have.value', '1202362');

    })
})