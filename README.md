# e-AGENDA MÉDICA

## Visão Geral

O projeto **e-AGENDA MÉDICA** é uma aplicação web desenvolvida para gerenciar o cronograma de atividades em uma clínica médica. Os médicos podem agendar consultas e cirurgias, com regras específicas para o agendamento e períodos de recuperação.

## Funcionalidades

1. **Agendamento de Atividades**
   - *Descrição:* Permite o agendamento de atividades para médicos, incluindo informações como horários de início e término, tipo de atividade e médico (ou lista de médicos) envolvidos.

2. **Períodos de Recuperação**
   - *Descrição:* Após realizar uma cirurgia, é necessário um período de recuperação de 4 horas. Após uma consulta, o período de recuperação é de 20 minutos.

3. **Modificação e Exclusão de Atividades**
   - *Descrição:* Oferece a capacidade de modificar os horários de uma atividade existente e excluir atividades já agendadas.

4. **Detecção de Conflitos de Horário**
   - *Descrição:* Indica quando a atividade de um médico entra em conflito com outras atividades do mesmo médico, permitindo ajustes nos horários para resolver conflitos.

5. **Ranking de Médicos**
   - *Descrição:* Apresenta uma lista dos 10 médicos que mais horas trabalharam dentro de um período específico.

## Dados Iniciais

- **Descrição:** O aplicativo já contém dados iniciais para testes, como informações sobre os médicos e algumas atividades atribuídas.
- **Para usar os dados iniciais, utilize a conta de testes para login:**
  - **Nome de usuário:** testes@gmail.com
  - **Senha:** Teste@123

## Tecnologias Utilizadas

- **Linguagens:** C#, TypeScript
- **Frameworks:** ASP.NET Core, Entity Framework Core
- **Banco de Dados:** SQL Server
- **Testes:** MSTest, Moq
- **Frontend:** Angular, HTML, CSS
