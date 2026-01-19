# Nx-Utilitarios
Utilitários em C# para automação no Siemens NX via NX Open API.

## Objetivo
Automatizar tarefas repetitivas na manufatura: listagem de operações, pós-processadores, geração de processos e validação automática de regras de negócio.

## Principais funcionalidades
- `listar_op.cs`: Extrai e lista operações (operations) de peças, assemblies ou CAM setups.
- `listar_post.cs`: Lista pós-processadores disponíveis no ambiente NX.
- `PosProcessa_5maquinas/`: Ferramenta para pós-processamento batch em 5 máquinas CNC diferentes (customizável para mais).

## Como usar
1. Abra o Visual Studio com NX Open assemblies referenciados (vem com instalação do NX).
2. Compile como NX Journal ou add-in.
3. Rode dentro do NX (File > Execute > NX Open).

## Requisitos
- Siemens NX (versão compatível com NX Open .NET)
- .NET Framework ou .NET 6+ (dependendo da versão NX)

## Próximos passos
- Transformar em Class Library reutilizável
- Adicionar extração de BOM e relatórios PDF/Excel
- Integração com API web (ASP.NET Core)

Contribuições bem-vindas!