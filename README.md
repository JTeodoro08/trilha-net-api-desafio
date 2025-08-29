# DIO - Trilha .NET - API e Entity Framework

[www.dio.me](http://www.dio.me)

## Desafio concluído

Este projeto consiste em um sistema gerenciador de tarefas, construído utilizando **.NET 7** e **Entity Framework Core**, seguindo as práticas recomendadas de Web API. O sistema permite criar, atualizar, obter e deletar tarefas, com dados consistentes no banco e exibidos corretamente na API e Swagger.

## Funcionalidades implementadas

* CRUD completo para tarefas.
* Data armazenada no banco sem hora (apenas `yyyy-MM-dd`).
* Status da tarefa armazenado como string (`Pendente` ou `Finalizado`).
* Endpoints testáveis via Swagger.
* Migrations criadas e aplicadas para atualização do banco.
* Atualização de registros antigos para refletir status corretamente.

## Estrutura da Classe Tarefa

A classe principal do sistema possui as seguintes propriedades:

![Diagrama da classe Tarefa](diagrama.png)

## csharp
public class Tarefa
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime Data { get; set; }
    public EnumStatusTarefa Status { get; set; }
}
```

## Endpoints Disponíveis

| Verbo  | Endpoint               | Parâmetro | Body          |
| ------ | ---------------------- | --------- | ------------- |
| GET    | /Tarefa/{id}           | id        | N/A           |
| PUT    | /Tarefa/{id}           | id        | Schema Tarefa |
| DELETE | /Tarefa/{id}           | id        | N/A           |
| GET    | /Tarefa/ObterTodos     | N/A       | N/A           |
| GET    | /Tarefa/ObterPorTitulo | titulo    | N/A           |
| GET    | /Tarefa/ObterPorData   | data      | N/A           |
| GET    | /Tarefa/ObterPorStatus | status    | N/A           |
| POST   | /Tarefa                | N/A       | Schema Tarefa |

## Schema de Tarefa

```json
{
  "id": 0,
  "titulo": "string",
  "descricao": "string",
  "data": "2025-08-29",
  "status": "Pendente"
}
```

## Ajustes e Melhorias Implementadas

1. **Controller Tarefa**: adicionado método `FormatarTarefa` para garantir que a data e o status sejam exibidos corretamente.
2. **Migrations**:

   * `Inicial` – Criação da tabela `Tarefas`.
   * `InicialNovaDB` – Inicialização do banco `AgendaTrilhaNet`.
   * `AjusteDataStatus` – Ajuste das colunas `Data` (tipo `date`) e `Status` (tipo string).
3. **Atualização de registros antigos**: código aplicado para atualizar status das tarefas já existentes no banco.
4. **Swagger**: endpoints atualizados para exibir corretamente a data e o status.

## Atualização de registros antigos

Para padronizar os registros existentes:

## csharp
foreach (var tarefa in context.Tarefas.ToList())
{
    if (tarefa.Status.ToString() == "0")
        tarefa.Status = EnumStatusTarefa.Pendente;
    else if (tarefa.Status.ToString() == "1")
        tarefa.Status = EnumStatusTarefa.Finalizado;
}
context.SaveChanges();
```

> Todos os registros antigos passam a exibir status corretamente após execução deste código.



