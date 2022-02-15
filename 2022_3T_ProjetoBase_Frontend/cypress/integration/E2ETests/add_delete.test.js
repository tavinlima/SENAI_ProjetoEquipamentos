describe('Cadastrar e Deletar - Equipamento', () => {

    beforeEach(() => {
        cy.visit('http://localhost:3000/')
    })

    it('Deve logar, cadastarar equipamento, ler OCR e deletar equipamento', () => {

        cy.get('.cabecalhoPrincipal-nav-login').should('exist');

        cy.get('.cabecalhoPrincipal-nav-login').click();

        cy.get('.input__login').first().type('paulo@email.com');

        cy.get('.input__login').last().type('123456789');

        cy.get('.btn__login').click();

        // Cadastro de equipamentos
        // Nome do equipamento
        cy.wait(3000);
        cy.get('#nomePatrimonio').first().type('Jogo de panelas');

        // Código do equipamento
        cy.get('input[type=file]').first().selectFile('src/assets/tests/equipamento_test.jpeg');

        // Produto ativo
        cy.get("input[type=checkbox]").check();

        // Imagem do equipamento
        cy.get('#arquivo').selectFile('src/assets/tests/jogodepanelas.jpg');

        // Verificação de valores dos inputs
        cy.wait(3000);
        cy.get('#codigoPatrimonio').should('have.value', '1202362');
        cy.get('#nomePatrimonio').should('have.value', 'Jogo de panelas');

        // Botão de Cadastrar
        cy.get('.btn__cadastro').click();

        // Botão de Deletar
        cy.wait(2000);
        cy.get('h4').last().should('have.text', 'Jogo de panelas').get('.excluir').last().click();

    })
})